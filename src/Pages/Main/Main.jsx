import React from 'react';
import styles from './main.module.scss'
import test from '../../Img/test.png'
import character from '../../Img/char.png'
import Product from "../../Components/Main/Product";
import SearchItem from "../../Components/Main/SearchItem";
import {
    BrowserRouter as Router,
    Link,
} from 'react-router-dom';
const Main = () => {
    const menuItems = ["футболки","штаны","ботинки","худи","свитшоты","юбки"]
    const massiv = ["1", "1", "1","1","1","1","1","1","1"]
    return (
        <div className={styles.items}>
            <div>
                <div>
                    <h1 className={styles.title}>Настройки поиска:</h1>
                    <ul className={styles.search}>
                        {
                            menuItems.map((item,index)=>{
                                return (<SearchItem item={item}/>)
                            })
                        }
                    </ul>
                    <button className={styles.search_more}>больше настроек</button>
                    <hr className={styles.line}/>
                </div>
                <div className={styles.products}>
                    <h1 className={styles.title}>Товары:</h1>
                    <ul className={styles.products_list}>
                        {

                            massiv.map((item,index)=>{
                                return (

                                    <Link  to="/item" className={styles.product}>
                                        <Product/>
                                    </Link>

                                )
                            })
                        }
                    </ul>
                </div>
            </div>

            <div className={styles.character}>
                <img src={character} className={styles.character_img} alt=""/>
            </div>

        </div>
    );
};

export default Main;