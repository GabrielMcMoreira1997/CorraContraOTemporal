using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TypeWriterController : MonoBehaviour
{
    public Text textWriter;
    public float delayWriter = 0.1f;
    public string escrevaFrase;

    void Start()
    {
        StartCoroutine("mostrarTexto", escrevaFrase);
    }

    // Update is called once per frame
    IEnumerator mostrarTexto(string texto)
    {
        textWriter.text = "";

        for(int letter =0; letter <= texto.Length; letter++)
        {
            textWriter.text = texto.Substring(0, letter);
            yield return new WaitForSeconds(delayWriter);
        }
    }
}
