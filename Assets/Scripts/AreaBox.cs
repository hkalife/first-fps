using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaBox : MonoBehaviour
{

    [SerializeField]
    private Text areaTexto;

    [SerializeField]
    public bool colidindo = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player está na " + this.gameObject.name);
            areaTexto.text = this.gameObject.name;
            colidindo = true;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player está na " + this.gameObject.name);
            areaTexto.text = this.gameObject.name;
            colidindo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        colidindo = false;
    }

}
