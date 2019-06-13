using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 5f;

    private Vector3 newRotation;

    void Start()
    {

    }

    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        newRotation = transform.localEulerAngles;

        newRotation.y += _mouseX * _sensitivity;
        transform.localEulerAngles = newRotation;

    }
}
