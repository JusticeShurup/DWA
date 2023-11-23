import React, {useContext, useState} from 'react';
import styles from './main.module.scss'
import test from '../../Img/test.png'
import character from '../../Img/char.png'
import Product from "../../Components/Main/Product";
import SearchItem from "../../Components/Main/SearchItem";
import {
    BrowserRouter as Router,
    Link,
} from 'react-router-dom';
import { Canvas } from 'react-three-fiber';
import { PersonModel } from '../../Components/Models/PersonModel';
import { OrbitControls } from '@react-three/drei';
import { PantsModel } from '../../Components/Models/Pants';
import { ShirtModel } from '../../Components/Models/ShirtModel';
import { Character } from '../../Components/Models/Character';
import { Suspense } from 'react';
import {characterContext} from "../../character";
const Main = () => {
    const [color, setColor] = useState("#000")
    const character = useContext(characterContext)
    console.log(character)
    const menuItems = ["футболки","штаны","ботинки","худи","свитшоты","юбки" ]
    const items = [
        [
            {src:"./tshirts/tshirt.png",name:"Футболка", color:"#1C1C1C",id:1},
            {src:"./tshirts/tshirt_red.png",name:"Футболка", color:"#B00000",id:1},
            {src:"./tshirts/tshirt_green.png",name:"Футболка", color:"#008000",id:1},
            {src:"./tshirts/tshirt_blue.png",name:"Футболка", color:"#0000FF",id:1}
        ],
        [
            {src:"./jeans/jeans.png",name:"Джинсы",color: "#1C1C1C",id:2},
            {src:"./jeans/jeans_red.png",name:"Джинсы",color: "#008000",id:2},
            {src:"./jeans/jeans_green.png",name:"Джинсы",color: "#008000",id:2},
            {src:"./jeans/jeans_blue.png",name:"Джинсы",color: "#0000FF",id:2},

        ],
        [
            {src:"./boots.png",name:"Ботинки",id:3},
            {src:"./boots.png",name:"Ботинки",id:3},
            {src:"./boots.png",name:"Ботинки",id:3},
            {src:"./boots.png",name:"Ботинки",id:3},
        ],
        [
            {src:"./hoodie.png",name:"Худи",id:4},
            {src:"./hoodie.png",name:"Худи",id:4},
            {src:"./hoodie.png",name:"Худи",id:4},
            {src:"./hoodie.png",name:"Худи",id:4},
            {src:"./hoodie.png",name:"Худи",id:4},
            {src:"./hoodie.png",name:"Худи",id:4},
        ],
        [
            {src:"./sweatshirts/sweatshirt.png",name:"Свитшот",color: "#1C1C1C",id:5},
            {src:"./sweatshirts/sweatshirt_red.png",name:"Свитшот",color: "#008000",id:5},
            {src:"./sweatshirts/sweatshirt_green.png",name:"Свитшот",color: "#008000",id:5},
            {src:"./sweatshirts/sweatshirt_blue.png",name:"Свитшот",color: "#0000FF",id:5},
            {src:"./sweatshirts/sweatshirt.png",name:"Свитшот",color: "#FFFAFA",id:5},

        ],
        [
            {src:"./ubka.png",name:"Юбка",id:6},
            {src:"./ubka.png",name:"Юбка",id:6},
            {src:"./ubka.png",name:"Юбка",id:6},
            {src:"./ubka.png",name:"Юбка",id:6},
            {src:"./ubka.png",name:"Юбка",id:6},
            {src:"./ubka.png",name:"Юбка",id:6},
            {src:"./ubka.png",name:"Юбка",id:6},

        ],
    ]
    const [selectedCategory,setSelectedCategory] = useState(0)

    
    return (
        <div className={styles.items}>
            <div>
                <div>
                    <h1 className={styles.title}>Настройки поиска:</h1>
                    <ul className={styles.search}>
                        {
                            menuItems.map((item,index)=>{
                                 return (<li className={`${styles.search_item} ${selectedCategory === index?styles.active:""}` }
                                             onClick={()=>{
                                                 setSelectedCategory(index)
                                             }}>{item} </li>)
                            })
                        }
                    </ul>
                    <div className={styles.search_more}>
                        <p>
                            больше настроек
                        </p>
                        <img className={styles.search_more_plus} src="./plus.png" alt=""/>
                    </div>
                    <hr className={styles.line}/>
                </div>
                <div className={styles.products}>
                    <h1 className={styles.title}>Товары:</h1>
                    <ul className={styles.products_list}>
                        {
                            items[selectedCategory].map((item,index)=>{
                                return (
                                        <Product img={item.src} id={item.id}/>
                                )
                            })
                        }
                    </ul>
                </div>
            </div>

            <div className={styles.character}>
            <Canvas style={{
                backgroundColor: '#fff'
            }}>
                <ambientLight/>
                <Suspense>
                    <Character position={[0, -3, 0]} rotation={[0, 0, 0]} color={color}
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

        </div>
    );
};

export default Main;