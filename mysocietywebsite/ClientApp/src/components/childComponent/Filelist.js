import React from 'react'
import styles from '../styles/filelist.module.css'

const DisplayFile = ({ file, removeFile, openImageModal }) => {
    const errorMessage = 'File type not permitted';
    const fileType = (fileName) => {
        return fileName.substring(fileName.lastIndexOf('.') + 1, fileName.length) || fileName;
    }
    const fileSize = (size) => {
        if (size === 0) return '0 Bytes';
        const k = 1024;
        const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
        const i = Math.floor(Math.log(size) / Math.log(k));
        return parseFloat((size / Math.pow(k, i)).toFixed(2)) + ' ' + sizes[i];
    }
    return (
        
        <div className={styles.fileDisplayContainer}>
            <div className={styles.fileStatusBar} onClick={!file.invalid ? () => openImageModal(file) : () => removeFile(file.name)}>
                <div>
                    <div className={styles.fileTypeLogo}></div>
                    <div className={styles.fileType}>{fileType(file.name)}</div>
                    <span className={file.invalid?styles.fileError:styles.fileName}>{file.name}</span>
                    <span className={styles.fileSize}>({fileSize(file.size)})</span> {file.invalid && <span className={styles.fileErrorMessage}>({errorMessage})</span>}
                </div>
                <div className={styles.fileRemove} onClick={()=>removeFile(file.name)}>X</div>
                
            </div>
            </div>
         
        )
}
export default DisplayFile