import React from 'react';
import styles from "./welocme.module.scss"
const Welcome = () => {
    return (
        <div className={styles.welcome}>
            <div className={styles.welcome_container}>
                <img className={styles.welcome_container_icon} src="./welcome.png" alt=""/>
                <h1 className={styles.welcome_container_title}>Добро пожаловать</h1>
                <h2 className={styles.welcome_container_subtitle}>идет загрузка</h2>
                <img className={styles.welcome_container_loading} src="./Loading.png" alt=""/>
            </div>
        </div>
    );
};

export default Welcome;