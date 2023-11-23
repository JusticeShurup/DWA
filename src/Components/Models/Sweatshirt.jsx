import React, { useRef } from "react";
import { useGLTF } from "@react-three/drei";

export function Sweatshirt(props) {
  const { nodes, materials } = useGLTF("Models/sweatshirt.glb");
  
  return (
    <group {...props} dispose={null}>
      <mesh
        name="HG_Sweater_1_Male001"
        castShadow
        receiveShadow
        geometry={nodes.HG_Sweater_1_Male001.geometry}
        material={materials[".HG_Sweater1"]}
        material-color = {props.color}
        morphTargetDictionary={nodes.HG_Sweater_1_Male001.morphTargetDictionary}
        morphTargetInfluences={nodes.HG_Sweater_1_Male001.morphTargetInfluences}
      />
    </group>
  );
}

useGLTF.preload("Models/sweatshirt.glb");