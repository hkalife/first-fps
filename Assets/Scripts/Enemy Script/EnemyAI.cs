using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public string hitTag;
    public bool lookingAtPlayer = false;
    public GameObject enemy;
    
    void Update()
    {
        ShootAI();
    }

    void ShootAI()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            hitTag = Hit.transform.tag;
        }
        if (hitTag == "Player")
        {
            enemy.GetComponent<Animator>().SetBool("seePlayer", true);
            lookingAtPlayer = true;
        }
        else
        {
            enemy.GetComponent<Animator>().SetBool("seePlayer", false);
            lookingAtPlayer = false;
        }
    }
}
