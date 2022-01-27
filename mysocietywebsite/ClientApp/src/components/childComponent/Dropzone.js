import React, { useEffect, useRef, useState } from 'react'
import { useHistory } from 'react-router-dom';
import { getToken } from '../../helper/tokenAuth';
import styles from '../styles/dropzone.module.css'
import DisplayFile from './Filelist';
import Loading from './Loading';

const DropZone = (props) => {
    const [selectedFiles, setSelectedFiles] = useState([]);
    const [validFiles, setValidFiles] = useState([]);
    const history = useHistory()
    const dragOver = (e) => {
        e.preventDefault();
    }
    const dragEnter = (e) => {
        e.preventDefault();
    }
    const removeFile = (name) => {
        // find the index of the item
        // remove the item from array

        const validFileIndex = validFiles.findIndex(e => e.name === name);
        validFiles.splice(validFileIndex, 1);
        // update validFiles array
        setValidFiles([...validFiles]);
        const selectedFileIndex = selectedFiles.findIndex(e => e.name === name);
        selectedFiles.splice(selectedFileIndex, 1);
        // update selectedFiles array
        setSelectedFiles([...selectedFiles]);
    }
    const dragLeave = (e) => {
        e.preventDefault();
    }
    useEffect(() => {
        let filteredArray = selectedFiles.reduce((file, current) => {
            const x = file.find(item => item.name === current.name);
            if (!x) {
                return file.concat([current]);
            } else {
                return file;
            }
        }, []);
        setValidFiles([...filteredArray]);

    }, [selectedFiles]);
    const fileDrop = (e) => {
        e.preventDefault();
        const files = e.dataTransfer.files;
        if (files.length) {
            handleFiles(files);
            }
    }
    const handleFiles = (files) => {
        for (let i = 0; i < files.length; i++) {
            if (validateFile(files[i])) {
                setSelectedFiles(prevArray => [...prevArray, files[i]]);
                // add to an array so we can display the name of file
            } else {
                files[i]['invalid'] = true;

                setSelectedFiles(prevArray => [...prevArray, files[i]]);
                // add a new property called invalid
                // add to the same array so we can display the name of the file
                // set error message
            }
        }
    }
    const validateFile = (file) => {
        const validTypes = ['image/jpeg', 'image/jpg', 'image/png', 'image/gif', 'image/x-icon'];
        if (validTypes.indexOf(file.type) === -1) {
            return false;
        }
        return true;
    }
    const openImageModal = (file) => {
        const reader = new FileReader();
        modalRef.current.style.display = "block";
        reader.readAsDataURL(file);
        reader.onload = function (e) {
            modalImageRef.current.style.backgroundImage = `url(${e.target.result})`;
        }
    }
    const modalImageRef = useRef();
    const modalRef = useRef();
    const closeUploadModal = () => {
        uploadModalRef.current.style.display = 'none';
    }
    const uploadModalRef = useRef();
    const uploadRef = useRef();
    const progressRef = useRef();
    const uploadFiles = () => {
        uploadModalRef.current.style.display = 'block';
        uploadRef.current.innerHTML = 'File(s) Uploading...';
        const formData = new FormData();
        for (let i = 0; i < validFiles.length; i++) {
        
        formData.append('files', validFiles[i]);
           
        }
            fetch(`/api/media/upload`, {
                method: 'POST',
                headers: {
                    'Authorization': `Bearer ${getToken().token}`
                },
                body: formData
            })
            .then(res => {
                progressRef.current.innerHTML = `50%`;
                progressRef.current.style.width = `50%`;
                return res
            })
                .then(json => {
                    if (json.status === 200) {
                        progressRef.current.innerHTML = `100%`;
                        progressRef.current.style.width = `100%`;
                        console.log(json)
                        history.push('/home');
                    }
                    else {
                        // If error, display a message on the upload modal
                        uploadRef.current.innerHTML = `<span class="error">Error Uploading File(s)</span>`;
                        // set progress bar background color to red
                        progressRef.current.style.backgroundColor = 'red';
                        uploadModalRef.current.style.display = 'none';
                    }
            })
            .catch(err => {
                console.log(err)
                // If error, display a message on the upload modal
                uploadRef.current.innerHTML = `<span class="error">Error Uploading File(s)</span>`;
                // set progress bar background color to red
                progressRef.current.style.backgroundColor = 'red';

                //uploadModalRef.current.style.display = 'none';
                //uploadRef.current.innerHTML = '';
            })
    }
    const fileInputRef = useRef()
    const fileInputClicked = () => {
        fileInputRef.current.click();
    }
    const filesSelected = () => {
        if (fileInputRef.current.files.length) {
            handleFiles(fileInputRef.current.files);
        }
    }
    const closeModal = () => {
        modalRef.current.style.display = "none";
        modalImageRef.current.style.backgroundImage = 'none';
    }
    return (
        <div>
            {/*<p className={styles.title}>Drag and Drop Image To Upload</p>*/}
            <div className={ styles.content}>
                <div className={ styles.container}>
                    <div
                        onClick={fileInputClicked }
                        className={styles.dropContainer}
                        onDragOver={dragOver}
                        onDragEnter={dragEnter}
                        onDragLeave={dragLeave}
                        onDrop={fileDrop}
                    >
                        <div className={styles.dropMessage}>
                            <div className={styles.uploadIcon}></div>
                            Drag & Drop files here or click to upload
                        </div>
                        <input
                            ref={fileInputRef}
                            className={styles.fileInput}
                            type="file"
                            multiple
                            onChange={filesSelected}
                        />
                    </div>
                    {
                        validFiles.length >0 && <div style={{ overflowY: 'scroll', height: '200px', }}>
                            {
                                validFiles.map((e, i) => {
                                    return (
                                        <DisplayFile key={i} file={e} removeFile={removeFile} openImageModal={openImageModal} />
                                    )
                                })
                            }
                        </div>
                    }
                </div>
                <div className={styles.modal} ref={modalRef}>
                    <div className={styles.overlay}></div>
                    <span className={styles.close} onClick={closeModal}>X</span>
                    <div className={styles.modalImage} ref={modalImageRef}></div>
                </div>
               
            </div>
            {validFiles.length > 0?<button className={styles.fileUploadBtn} onClick={uploadFiles}>Upload Files</button>:null}
            <Loading closeUploadModal={closeUploadModal} progressRef={progressRef} uploadModalRef={uploadModalRef} uploadRef={uploadRef } />
        </div>
    )
}
export default DropZone

