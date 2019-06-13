using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _controlePersonagem;

    [SerializeField]
    private float _speed = 7.0f;
    private float _gravity = 9.81f;

    private bool accelerated = false;

    private Rigidbody rb;

    private float jumpForce = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _controlePersonagem = gameObject.GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) //correr
        {
            _speed = _speed * 2f;
            accelerated = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        { //se soltar botão de corrida
            if (accelerated == true)
            {
                _speed = _speed / 2f;
                accelerated = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        CalculatePlayerMovement();
    }

    void CalculatePlayerMovement()
    {
        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(inputHorizontal, 0, inputVertical);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity);
        _controlePersonagem.Move(velocity * Time.deltaTime);

    }

}
