using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangePantsColor : MonoBehaviour
{
    [SerializeField]
    public Color _color;

    [SerializeField]
    public Material _material;

    public void ChangeColor()
    {
        _material.color = _color;
    }

}
