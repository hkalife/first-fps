using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaltherPPK : MonoBehaviour
{

    private Animator anim;
    private bool isAiming = false;
    private bool isReloading = false;


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
        StartCoroutine(Reload());
        Move();
    }

    void Move()
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
        if (Input.GetMouseButtonDown(0) && (isAiming == false) && (isReloading == false))
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
        if (Input.GetMouseButtonDown(1)) //is aiming
        {
            Debug.Log("Is aiming.");
            isAiming = true;

            anim.SetBool("aimGun", true);
        }
        if (Input.GetMouseButtonUp(1))// stopped aiming
        {
            Debug.Log("Stopped aiming.");
            isAiming = false;

            anim.SetBool("aimGun", false);
        }

        if ((isAiming == true) && Input.GetMouseButtonDown(0)) //shoot while aiming
        {
            Debug.Log("Shooting with aiming.");
            anim.Play("walther aim shoot");

            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.transform.name);
            }

        }
        if ((isAiming == true) && Input.GetMouseButtonUp(0))
        {
            Debug.Log("Shooting with aiming, part 2.");
            anim.SetBool("isShootingAim", false);
        }


    }

    IEnumerator Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isReloading = true;
            anim.Play("walther reload");

            Debug.Log("Started Reloading");
            yield return new WaitForSeconds(1f);
            isReloading = false;
            Debug.Log("Finished reloading");
        }
    }

}
