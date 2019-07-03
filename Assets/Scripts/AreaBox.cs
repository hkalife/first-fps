using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaBox : MonoBehaviour
{

    [SerializeField]
    private Text areaTexto;

    public float segundos = 10.0f;

    [SerializeField]
    private GameObject negativo;

    private int okCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        okCoroutine = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            //Debug.Log("Player está na " + this.gameObject.name);
            areaTexto.text = this.gameObject.name;
            if (okCoroutine == 1)
            {
                okCoroutine = 0;
                StartCoroutine(contaSegundos(segundos));
                negativo.SetActive(false);
            }
            
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Player está na " + this.gameObject.name);
            areaTexto.text = this.gameObject.name;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //negativo.SetActive(false);
    }

    IEnumerator contaSegundos(float seg)
    {
        yield return new WaitForSeconds(seg);
        negativo.SetActive(true);
    }

}
