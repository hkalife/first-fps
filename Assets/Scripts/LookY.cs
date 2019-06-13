using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 5f;

    void Start()
    {

    }

    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x -= _mouseY * _sensitivity;
        transform.localEulerAngles = newRotation;

        if (transform.localEulerAngles.x > 70 && transform.localEulerAngles.x < 170)
        {
            newRotation.x = 70;
        }
        if (transform.localEulerAngles.x < 290 && transform.localEulerAngles.x > 200)
        {
            newRotation.x = 290;
        }
        if (newRotation.y == 180)
        {
            newRotation.y = 0;
            newRotation.z = 0;
        }

        transform.localEulerAngles = newRotation;

    }
}
