import React, {useState} from 'react';
import styles from "./item.module.scss"
import tshirt from "../../Img/tshirt.png"
import character from "../../Img/character_tshirt.png"
import star from "../../Img/star.svg";
import black from "../../Img/colors/black.png"
import yellow from "../../Img/colors/yellow.png"
import red from "../../Img/colors/red.png"
import green from "../../Img/colors/green.png"
import size_type from "../../Img/size_type.svg"
const Item = () => {
    const [fit,setFit] = useState(false)
    const sizes = [40,42,44,46,48,50,52,54,56,58]
    return (
        <div className={styles.items}>
            <div className={styles.character}>
                {fit? <img src={character} className={styles.character_img} alt=""/>:<img src={tshirt} className={styles.character_tshirt} alt=""/>}
            </div>
            <div className={styles.description}>
                <h1 className={styles.description_title}>Кайфовая футболка </h1>
                <div className={styles.description_subtitle}>
                    <button className={styles.description_rating}>
                        <img className={styles.description_rating_star} src={star} alt="a"/>
                        5.0
                    </button>
                    <p className={styles.article}>
                        #35-6723-4457-8993
                    </p>
                </div>
                <p className={styles.description_info}>Кайфовая футболка из кайфовой ткани для дикого кайфа,можно кайфово носить, кафово стирать, кайфово кайфовать</p>
                <p className={styles.description_color}>Цвет:</p>
                <div className={styles.colors}>
                    <img src={green} className={styles.color}/>
                    <img src={yellow} className={styles.color}/>
                    <img src={red} className={styles.color}/>
                    <img src={black}  className={styles.color}/>
                </div>
                <div className={styles.description_size}>
                    <h2 className={styles.sizes_title}>Размер:</h2>
                    <img src={size_type} className={styles.sizes_type}>
                    </img>
                </div>
                <div className={styles.sizes_container}>
                    {
                        sizes.map((size,index)=>{
                            return <div className={styles.sizes_container_item}>{size}</div>
                        })
                    }
                </div>
                <button className={styles.button} onClick={(e)=>{
                    setFit((prev)=>{
                        return !prev
                    })
                }}>{fit?"Отменить примерку":"Примерить"}</button>
                <div className={styles.buy }>
                    <button className={styles.buy_button}>Купить</button>
                    <div className={styles.buy_price}>1500Р</div>
                </div>
            </div>


        </div>


    );
};

export default Item;