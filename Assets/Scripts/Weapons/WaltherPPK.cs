using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaltherPPK : MonoBehaviour
{

    private Animator anim;
    private bool isAiming = false;
    private bool isReloading = false;

    [SerializeField]
    private GameObject muzzleFlash;

    public AudioClip shootSound;
    public AudioClip reloadSound;

    [SerializeField]
    private AudioSource weaponAudio;

    public GameObject crosshair;

    [SerializeField]
    private GameObject hitMarker;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        weaponAudio = GetComponent<AudioSource>();
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
        if (Input.GetKeyDown(KeyCode.W) && (isReloading == false)) //walk
        {
            anim.Play("walther walk");
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.W)) //stop walking
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && (isReloading == false)) //sprint
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
            StartCoroutine(SetMuzzleFlash());
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(Mathf.Lerp(0f, 1f, 0.50f), Mathf.Lerp(0f, 1f, 0.50f), 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.transform.name);
                Instantiate(hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }

            weaponAudio.PlayOneShot(shootSound, 0.7f);
        }
    }

    void Aim()
    {
        if (Input.GetMouseButtonDown(1) && (isReloading == false)) //is aiming
        {
            Debug.Log("Is aiming.");
            isAiming = true;

            crosshair.SetActive(false);

            anim.SetBool("aimGun", true);
        }
        if (Input.GetMouseButtonUp(1))// stopped aiming
        {
            Debug.Log("Stopped aiming.");
            isAiming = false;

            crosshair.SetActive(true);

            anim.SetBool("aimGun", false);
        }

        if ((isAiming == true) && Input.GetMouseButtonDown(0) && (isReloading == false)) //shoot while aiming
        {
            Debug.Log("Shooting with aiming.");
            anim.Play("walther aim shoot");
            weaponAudio.PlayOneShot(shootSound, 0.7f);
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.transform.name);
                Instantiate(hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
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
        if (Input.GetKeyDown(KeyCode.R) && (isReloading == false))
        {
            isReloading = true;
            anim.Play("walther reload");
            weaponAudio.PlayOneShot(reloadSound, 0.7f);
            Debug.Log("Started Reloading");
            yield return new WaitForSeconds(1f);
            isReloading = false;
            Debug.Log("Finished reloading");
        }
    }

    IEnumerator SetMuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(.1f);
        muzzleFlash.SetActive(false);
    }

}
