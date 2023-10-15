import React from 'react';
import styles from "../../Pages/Main/main.module.scss";
import test from "../../Img/test.png";
import star from "../../Img/star.svg"
const Product = () => {
    return (
        <li className={styles.product}>
            <img src={test} alt=""/>
            <div className={styles.product_buttons}>
                <button className={styles.product_price}>
                    1500 Р
                </button>
                <button className={styles.product_rating}>
                    <img className={styles.product_rating_star} src={star} alt="a"/>
                    5.0
                </button>
            </div>
        </li>

    );
};

export default Product;