using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class performance : MonoBehaviour
{
    public TMP_Text[] elementos;
    public GameObject[] botones;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var texto in elementos)
        {
            Color alfa = texto.color;
            alfa.a = 0;
            texto.color = alfa;
        }
        elementos[1].text = $"Ganancia: ${endGameScripts.dinero}";
        StartCoroutine(mostrarTodo());
    }

    IEnumerator mostrarTodo()
    {
        yield return new WaitForSeconds(3.5f);
        foreach (var texto in elementos)
        {
            Color alfa = texto.color;
            alfa.a = 1;
            texto.color = alfa;
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(2);
        foreach (var boton in botones)
        {
            boton.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
