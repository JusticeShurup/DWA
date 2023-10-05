using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform _character;

    public float _rotationSpeed = 1;

    private float _prevMouseCoord = 0;
    private bool _isTouchStarted = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton((int)MouseButton.Right))
        {           
            if (!_isTouchStarted)
            {
                _prevMouseCoord = Input.mousePosition.x; // When click the button for the first time, the difference (-Input.mousePosition.x + _prevMouseCoord) should be zero
                _isTouchStarted = true;
            }

            _character.Rotate(0, (-Input.mousePosition.x + _prevMouseCoord) * _rotationSpeed, 0);
            _prevMouseCoord = Input.mousePosition.x;
        }
        else
        {
            _isTouchStarted = false;
        }
    }
}
