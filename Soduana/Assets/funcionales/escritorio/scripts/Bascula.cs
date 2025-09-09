using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bascula : MonoBehaviour
{
    public TMP_Text textoPeso;
    public float intervaloDisplay;
    private int peso;

    public void recibirPeso(int gramos)
    {
        peso = gramos;
    }
    public void mostrarPeso()
    {
        StartCoroutine(pesar());
    }
    public void resetDisplay()
    {
        textoPeso.text = "0 g";
    }
    IEnumerator pesar()
    {
        int display = 0;
        do
        {
            display += Random.Range(50, 75);
            if (display >= peso)
            {
                display = peso;
            }
            textoPeso.text = $"{display} g";
            yield return new WaitForSeconds(intervaloDisplay);
        } while (display != peso);
    }
}
