import { useEffect, useState } from "react";
import { PantsModel } from "./Pants";
import { PersonModel } from "./PersonModel";
import { ShirtModel } from "./ShirtModel";
import { useFrame, useThree } from "react-three-fiber";
import { Sweatshirt } from "./Sweatshirt";

 
const CATEGORIES = {
    1: "Футболка",
    2: "Джинсы",
    5: "Свитшот"
};

export function Character(props) {

    const [position, setPosition] = useState();
    const [selectedCategoryId, setSelectedCategoryId] = useState(1)

    useEffect(() => {
        setPosition(props.position)
    }, [props.position])

    useEffect(() => {
        setSelectedCategoryId(props.selectedCategoryId);
    }, [props.selectedCategoryId]);


    return( 
        <>
            <PersonModel position = {position} scale ={[1 * 3, 1 * 3, 1 * 3]}/>

            <PantsModel position = {position} color = {props.bottomColor ? props.bottomColor : "#000"} scale ={[1 * 3, 1 * 3, 1 * 3]}/>
            
            {
            props.top === "tshirt" ?
            <ShirtModel position = {position}   color={ props.topColor? props.topColor : "#000"} scale ={[1 * 3, 1 * 3, 1.075 * 3]}/>
            :
            <Sweatshirt position = {position}  color={ props.topColor? props.topColor : "#000"} scale ={[1.01 * 3, 1 * 3, 1.085 * 3]}/>
            }
        </>
    )
}