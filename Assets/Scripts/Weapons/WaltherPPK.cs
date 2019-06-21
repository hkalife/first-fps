using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaltherPPK : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Aim();
        Reload();
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
            Debug.Log("Aim");
        }
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Return to normal position");
        }
    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reload");
        }
    }
}
