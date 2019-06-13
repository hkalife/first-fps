using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintCrouch : MonoBehaviour
{
    private PlayerMove playerMove;

    public float sprintSpeed = 10f;
    public float moveSpeed = 5f;
    public float crouchSpeed = 2f;

    private Transform lookRoot;
    private float standHeight = 0.748f;
    private float crouchHeight = 0.10f;

    private bool isCrouching;

    void Awake()
    {
        playerMove = GetComponent<PlayerMove>();

        lookRoot = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint ()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
        {
            playerMove.speed = sprintSpeed;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            playerMove.speed = moveSpeed;
        }
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            lookRoot.localPosition = new Vector3(0f, crouchHeight, 0f);
            playerMove.speed = crouchSpeed;

            isCrouching = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            lookRoot.localPosition = new Vector3(0f, standHeight, 0f);
            playerMove.speed = moveSpeed;

            isCrouching = false;
        }
    }
}
