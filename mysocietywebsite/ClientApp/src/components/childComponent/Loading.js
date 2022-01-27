import React from 'react'
import styles from '../styles/loading.module.css'
const Loading = ({ uploadModalRef, uploadRef, progressRef, closeUploadModal}) => {
    return (
        <div className={styles.uploadModal} ref={uploadModalRef}>
            <div className={ styles.overlay}></div>
            <div className={ styles.close} onClick={(() => closeUploadModal())}>X</div>
            <div className={styles.progressContainer}>
                <span ref={uploadRef}></span>
                <div className={styles.progress}>
                    <div className={styles.progressBar} ref={progressRef}></div>
                </div>
            </div>
        </div>
        )
}

export default Loading