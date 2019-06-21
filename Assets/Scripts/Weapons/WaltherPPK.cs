using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaltherPPK : MonoBehaviour
{

    private Animator anim;
    private bool isAiming;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Aim();
        Reload();
        Move();
    }

    void Move ()
    {
        if (Input.GetKeyDown(KeyCode.W)) //walk
        {
            anim.Play("walther walk");
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.W)) //stop walking
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) //sprint
        {
            anim.Play("walther run");
            anim.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) //stop sprinting
        {
            anim.SetBool("isRunning", false);
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && (isAiming == false))
        {
            anim.Play("walther shoot");
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.transform.name);
            }
        }
    }

    void Aim()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isAiming = true;
            Debug.Log("Aim");
            anim.Play("walther aim");
        }
        if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
            Debug.Log("Return to normal position");
            anim.SetBool("isShootingAim", false);
            anim.Play("walther aim return");
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("walther aim shoot");
            anim.SetBool("isShootingAim", true);
        }
    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reload");
            anim.Play("walther reload");
        }
    }
}
