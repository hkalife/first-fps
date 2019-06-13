using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{

    [SerializeField]
    private GameObject FPSWeapons;

    [SerializeField]
    private GameObject flashlight;

    [SerializeField]
    private bool isFlashlightOn = false; //starts turned off - false

    [SerializeField]
    private GameObject waltherPPK;

    [SerializeField]
    private GameObject ak47;


    // Start is called before the first frame update
    void Start()
    {
        flashlight.SetActive(false);
        waltherPPK.SetActive(false);
        ak47.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F)) //call flashlight
        {
            if (!isFlashlightOn) //if it is turned off - false
            {
                isFlashlightOn = true;
                flashlight.SetActive(true);
            }
            else
            {
                isFlashlightOn = false;
                flashlight.SetActive(false);
            }
        }
        if (Input.GetKey(KeyCode.Alpha1)) //call Walther PPK
        {
            ak47.SetActive(false);
            waltherPPK.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha2)) //call Machine Gun, if available
        {
            waltherPPK.SetActive(false);
            ak47.SetActive(true);
        }
    }

}
