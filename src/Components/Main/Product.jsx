import React from 'react';
import styles from "../../Pages/Main/main.module.scss";
import test from "../../Img/test.png";
import star from "../../Img/star.svg"
import {Link} from "react-router-dom";
const Product = ({img,id}) => {
    return (
        <li className={styles.product}>
            <Link to={`/item/${id}`}>
                <img src={img} alt="" className={styles.product_img}/>
            </Link>

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