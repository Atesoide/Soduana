using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    private float paso;
    public float velocidad, velocidadRotacion;
    public Vector3[] posiciones;
    private bool modoInspeccion;
    //---INDEXACION------
    //*0: Posicion inicial
    //*1: Posicion del vaso
    //*2: Posición de inspección
    //*3: Posicion del contador geiger
    // Start is called before the first frame update
    void Start()
    {
        transform.position = posiciones[0];
        modoInspeccion = false;
    }

    public void moverAlVaso()
    {
        StartCoroutine("moverAVaso");
    }
    public void moverAGeiger()
    {
        StartCoroutine("MoverAGeiger");
    }
    public void retornarPosicion()
    {
        StartCoroutine("retornar");
    }
    public void moverAInspeccion()
    {
        
        if (!modoInspeccion)
        {
            modoInspeccion = true;
            StartCoroutine(MoverAInspeccion());
        }
        else
        {
            modoInspeccion = false;
            StartCoroutine(retornar());
        }
    }
    IEnumerator moverAVaso()
    {
        do
        {
            paso = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, posiciones[1], paso);
            yield return null;
        } while (transform.position != posiciones[1]);
    }
    IEnumerator MoverAGeiger()
    {
        do
        {
            paso = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, posiciones[3], paso);
            yield return null;
        } while (transform.position != posiciones[3]);
    }
    IEnumerator retornar()
    {
        do
        {
            paso = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, posiciones[0], paso);
            yield return null;
        } while (transform.position != posiciones[0]);
    }
    IEnumerator MoverAInspeccion()
    {
        do
        {
            paso = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, posiciones[2], paso);
            yield return null;
        } while (transform.position != posiciones[2]);
    }
}
