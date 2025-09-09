using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Geiger : MonoBehaviour
{
    public TMP_Text textoRads;
    private float radioactividad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void recibirRadioactividad(float rads)
    {
        radioactividad = rads;
    }
    public void resetDisplay()
    {
        textoRads.text = "0 Gy";
    }
    public void mostrarRadiacion()
    {
        textoRads.text = $"{radioactividad} Gy";
    }
}
