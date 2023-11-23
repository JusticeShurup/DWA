import React, {Suspense, useContext, useState} from 'react';
import styles from "./item.module.scss"
import star from "../../Img/star.svg";
import size_type from "../../Img/size_type.svg"
import {useParams} from "react-router-dom";
import {Character} from "../../Components/Models/Character";
import {OrbitControls} from "@react-three/drei";
import {Canvas} from "react-three-fiber";
import {characterContext} from "../../character";
const Item = () => {
    const params = useParams()
    const items = [
        {src:"/tshirts/tshirt",name:"tshirt",id:1,top:true},
        {src:"/jeans/jeans",name:"jeans",id:2,top:false},
        {src:"/boots",name:"boots",id:3,top:false},
        {src:"/hoodie",name:"hoodie",id:4,top:true},
        {src:"/sweatshirts/sweatshirt",name:"sweatshot",top:true},
        {src:"/ubka",name:"ubka",id:6,top:false},
    ]
    const colors = {
        default:{
            hex:"#1C1C1C",
            color:""
        },
        green:{
            hex:"#008000",
            color:"_green"
        },
        red:{
            hex:"#B00000",
            color:"_red"
        },
        blue:{
            hex:"#0000FF",
            color:"_blue"
        },
        white:{
            hex:"#FFFAFA",
            color:"_white"
        },

    }
    const character = useContext(characterContext)
    const [fit,setFit] = useState(false)
    const sizes = [40,42,44,46,48,50,52,54,56,58]
    const [selectedColor,setSelectedColor] = useState(colors.default)
    return (
        <div className={styles.items}>
            <div className={styles.character_model}>
                <Canvas style={{
                    backgroundColor: '#fff'}}>
                    <ambientLight/>
                    <Suspense>
                        <Character position={[0, -3, 0]} rotation={[0, 0, 0]}
                                   top={character.character.top}
                                   topColor={character.character.topColor}
                                   bottom={character.character.bottom}
                                   bottomColor={character.character.bottomColor}
                        />
                    </Suspense>


                    <OrbitControls
                        maxPolarAngle = {-Math.PI / 2}
                        minPolarAngle = {Math.PI / 2}
                        enablePan = {false}
                        enableZoom = {false}
                    />
                </Canvas>
            </div>
            <div className={styles.character}>
                {fit? null:<div className={styles.canvas}><img src={`${items[params.id - 1].src + selectedColor.color}.png`} className={styles.character_item} alt="photo"/></div>}
            </div>
            <div className={styles.description}>
                <h1 className={styles.description_title}>Вещь</h1>
                <div className={styles.description_subtitle}>
                    <button className={styles.description_rating}>
                        <img className={styles.description_rating_star} src={star} alt="a"/>
                        5.0
                    </button>
                    <p className={styles.article}>
                        #35-6723-4457-8993
                    </p>
                </div>
                <p className={styles.description_info}>Описание вещи</p>
                <p className={styles.description_color}>Цвет:</p>
                <div className={styles.colors}>
                    <div className={styles.color} style={{
                        backgroundColor:"#008000"
                    }}
                         onClick={()=> {
                             character.setCharacter((prev)=>{
                                 return items[params.id - 1].top? {
                                     ...prev,

                                     top: items[params.id - 1].name,
                                     topColor:"#008000",
                                 }:{
                                     ...prev,
                                     bottom: items[params.id - 1].name,
                                     bottomColor:"#008000",
                                 }
                    })}}
                    >
                    </div>
                    <div className={styles.color} style={{
                        backgroundColor:"#B00000"
                    }} onClick={()=> {
                        character.setCharacter((prev)=>{
                            return items[params.id - 1].top? {
                                ...prev,

                                top: items[params.id - 1].name,
                                topColor:"#B00000",
                            }:{
                                ...prev,
                                bottom: items[params.id - 1].name,
                                bottomColor:"#B00000",
                            }
                        })}}>
                    </div>
                    <div className={styles.color} style={{
                        backgroundColor:"#0000FF"
                    }} onClick={()=> {
                        character.setCharacter((prev)=>{
                            return items[params.id - 1].top? {
                                ...prev,

                                top: items[params.id - 1].name,
                                topColor:"#0000FF",
                            }:{
                                ...prev,
                                bottom: items[params.id - 1].name,
                                bottomColor:"#0000FF",
                            }
                        })}}>
                    </div>
                    <div className={styles.color} style={{
                        backgroundColor:"#1C1C1C"
                    }} onClick={()=> {
                        character.setCharacter((prev)=>{
                            return items[params.id - 1].top? {
                                ...prev,

                                top: items[params.id - 1].name,
                                topColor:"#1C1C1C",
                            }:{
                                ...prev,
                                bottom: items[params.id - 1].name,
                                bottomColor:"#1C1C1C",
                            }
                        })}}>
                    </div>
                </div>
                <div className={styles.description_size}>
                    <h2 className={styles.sizes_title}>Размер:</h2>
                    <img src={size_type} className={styles.sizes_type}>
                    </img>
                </div>
                <div className={styles.sizes_container}>
                    {
                        sizes.map((size,index)=>{
                            return <div key={index} className={styles.sizes_container_item}>{size}</div>
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