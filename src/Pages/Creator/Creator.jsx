import React, {useState} from 'react';
import styles from "./creator.module.scss"
import Slider from "rc-slider";

import './slider.css';
const Creator = () => {
    const [characteristic,setCharacterisc] = useState(
        {
            gender:"male",
            height:170,
            weight:70,
            shoulders:40,
            waist:75,
            hips:95
        }
    )
    return (
        <div className={styles.creator}>
            <div  className={styles.char}>
                <img src={"./char.png"} className={styles.char_img}/>
            </div>
            <div className={styles.settings}>
                <h1 className={styles.settings_title}>Настройка вашего персонажа </h1>
                <p className={styles.settings_subtitle}>Это ваш персонаж, сделайте его максимально похожим на вас что бы получить максимальный    результат.
                    В будущем вы сможете его изменить.</p>
                <div className={styles.gender}>
                    <p>Пол:</p>
                    <button className={`${styles.gender_button} ${characteristic.gender === "male"?styles.active:""} `} onClick={()=>{
                      setCharacterisc((prev)=>{
                          return {
                              ...prev,
                              gender: "male"
                          }
                      })
                    }}>М</button>
                    <button className={`${styles.gender_button} ${characteristic.gender === "female"?styles.active:""} `} onClick={()=>{
                        setCharacterisc((prev)=>{
                            return {
                                ...prev,
                                gender: "female"
                            }
                        })
                    }}>Ж</button>
                </div>
                <div className={styles.sliders}>
                    <div className={styles.characteristic}>
                        <p className={styles.characteristic_title}>Рост: {characteristic.height}</p>
                        <Slider
                            value={characteristic.height}
                            min={150}
                            max={190}
                            marks={{ 150: 150, 160: 160, 170: 170, 180: 180, 190: 190 }}
                            onChange={(num)=>{
                                console.log(characteristic)
                                setCharacterisc((prev)=>{
                                    return {
                                        ...prev,
                                        height: num
                                    }
                                })
                            }}
                        />
                    </div>
                    <div className={styles.characteristic}>
                        <p  className={styles.characteristic_title}>Вес: {characteristic.weight}</p>
                        <Slider
                            value={characteristic.weight}
                            min={40}
                            max={100}

                            marks={{ 40: 40,50:50,60:60,70:70,80:80,90:90,100: 100 }}
                            onChange={(num)=>{
                                console.log(characteristic)
                                setCharacterisc((prev)=>{
                                    return {
                                        ...prev,
                                        weight: num
                                    }
                                })
                            }}
                        />
                    </div>
                    <div className={styles.characteristic}>
                        <p  className={styles.characteristic_title}>Ширина плеч: {characteristic.shoulders}</p>
                        <Slider
                            min={30}
                            max={50}
                            marks={{ 30:30,35:35,40:40,45:45,50:50}}
                            value={characteristic.shoulders}
                            onChange={(num)=>{
                                console.log(characteristic)
                                setCharacterisc((prev)=>{
                                    return {
                                        ...prev,
                                        shoulders: num
                                    }
                                })
                            }}
                        />
                    </div>
                    <div className={styles.characteristic}>
                        <p  className={styles.characteristic_title}>Обхват талии: {characteristic.waist}</p>
                        <Slider
                            value={characteristic.waist}
                            min={60}
                            max={90}
                            marks={{ 60:60,70:70,80:80,90:90}}
                            onChange={(num)=>{
                                console.log(characteristic)
                                setCharacterisc((prev)=>{
                                    return {
                                        ...prev,
                                        waist: num
                                    }
                                })
                            }}
                        />
                    </div>
                    <div className={styles.characteristic}>
                        <p className={styles.characteristic_title}>Обхват бёдер: {characteristic.hips}</p>
                        <Slider
                            value={characteristic.hips}
                            min={70}
                            max={120}
                            marks={{ 70:70,80:80,90:90,100:100,110:110,120:120}}
                            onChange={(num)=>{
                                console.log(characteristic)
                                setCharacterisc((prev)=>{
                                    return {
                                        ...prev,
                                        hips: num
                                    }
                                })
                            }}
                        />
                    </div>
                </div>
                <button className={styles.submit}>Завершить</button>
            </div>
        </div>
    );
};

export default Creator;