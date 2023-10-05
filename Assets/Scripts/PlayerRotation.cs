using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform _character;

    private float prevMouseCoord = 0;
    public float _rotationSpeed = 1;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton((int)MouseButton.Left))
        {           
            _character.Rotate(0, (-Input.mousePosition.x + prevMouseCoord) * _rotationSpeed, 0);
            prevMouseCoord = Input.mousePosition.x;
        }
    }
}
