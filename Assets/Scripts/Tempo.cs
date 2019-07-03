using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tempo : MonoBehaviour
{

    [SerializeField]
    private Text tempoTexto;

    private int tempoInicial = 10;

    private int tempoAtual;

    private AreaBox areaBox;

    // Start is called before the first frame update
    void Start()
    {
        tempoAtual = tempoInicial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator atualizaTempo () {
        string stringTempo = tempoAtual.ToString();
        tempoTexto.text = stringTempo;
        yield return new WaitForSeconds(1f);
        tempoAtual = tempoAtual - 1;
    }

}
