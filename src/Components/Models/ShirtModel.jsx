
import React, { useRef } from "react";
import { useGLTF } from "@react-three/drei";
import { useState } from "react";
import { useEffect } from "react";

export function ShirtModel(props) {
  const { nodes, materials } = useGLTF("/models/shirt.glb");


  return (
    <group {...props} dispose={null}>
      <mesh
        name="HG_TSHIRT_Male001"
        castShadow
        receiveShadow
        geometry={nodes.HG_TSHIRT_Male001.geometry}
        material={materials[".HG_TSHIRT.003"]}
        material-color = {props.color}
        morphTargetDictionary={nodes.HG_TSHIRT_Male001.morphTargetDictionary}
        morphTargetInfluences={nodes.HG_TSHIRT_Male001.morphTargetInfluences}
      />
    </group>
  );
}

useGLTF.preload("/models/shirt.glb");