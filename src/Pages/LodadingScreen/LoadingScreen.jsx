import React from 'react';
import styles from './loading.module.scss'
import DVDLogoAnimation from "react-dvd-player-animation";
import {useEffect,useState} from "react";
function getWindowDimensions() {
    const { innerWidth: width, innerHeight: height } = window;
    return {
        width,
        height
    };
}
const LoadingScreen = () => {

    const [windowDimensions, setWindowDimensions] = useState(getWindowDimensions());

    useEffect(() => {
        function handleResize() {
            setWindowDimensions(getWindowDimensions());
        }

        window.addEventListener('resize', handleResize);
        return () => window.removeEventListener('resize', handleResize);
    }, []);


    return (
        <div className={styles.background}>
                <h1 className={styles.title}>Добро пожаловать</h1>
                <h2 className={styles.subtitle}>Идет загрузка...</h2>

            <DVDLogoAnimation
                height={windowDimensions.height}
                width={windowDimensions.width}
                logoHeight={20}
                logoWidth={160}
            >
                <path d="M63.6396 194.369V46.9893H5.5096C1.2296 67.3393 1.39961 94.0093 0.849609 120.679C1.39961 147.349 1.2296 174.019 5.5096 194.369H63.6396Z" fill="white"/>
                <path d="M104.98 194.369H142.41C172.94 194.369 189.99 176.259 189.99 152.679C189.99 150.889 189.88 149.139 189.67 147.429C189.51 146.149 189.29 144.889 189.01 143.659C188.82 142.839 188.61 142.029 188.37 141.229C188.01 140.039 187.59 138.869 187.11 137.729C186.47 136.209 185.72 134.739 184.85 133.329C181.4 127.669 176.19 122.879 169.14 119.199C182.19 112.039 187.88 100.459 187.88 86.9893C187.88 64.4593 171.46 46.9893 142.19 46.9893H104.97H76.3398V194.369H104.98Z" fill="white"/>
                <path d="M223.63 18.4696C206.88 0.00960541 164.15 0.979609 121.43 0.0996094C78.6998 0.979609 35.9798 0.00960541 19.2198 18.4696C12.2798 24.7696 8.08977 34.7296 5.50977 46.9896H63.6398V194.37H5.50977C8.08977 206.62 12.2798 216.59 19.2198 222.88C35.9698 241.34 78.6998 240.37 121.42 241.25C164.15 240.37 206.87 241.34 223.63 222.88C242.09 206.13 241.12 163.4 242 120.68C241.12 77.9496 242.09 35.2296 223.63 18.4696ZM142.41 194.37H104.98H76.2998V46.9896H76.3398H104.97H142.19C171.45 46.9896 187.88 64.4696 187.88 86.9896C187.88 100.46 182.19 112.04 169.14 119.2C176.19 122.88 181.4 127.67 184.85 133.33C185.71 134.74 186.46 136.21 187.11 137.73C187.59 138.87 188.01 140.04 188.37 141.23C188.61 142.03 188.82 142.84 189.01 143.66C189.29 144.89 189.51 146.15 189.67 147.43C189.88 149.14 189.99 150.89 189.99 152.68C190 176.26 172.94 194.37 142.41 194.37Z" />
                <path d="M104.98 194.369H142.41C172.94 194.369 189.99 176.259 189.99 152.679C189.99 176.259 172.93 194.369 142.41 194.369H104.98H76.3496V46.9893H76.3096V194.369H104.98Z" fill="#1A1A1A"/>

            </DVDLogoAnimation>
        </div>
    );
};

export default LoadingScreen;