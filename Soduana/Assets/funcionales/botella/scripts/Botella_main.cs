using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botella_main : MonoBehaviour
{
    public Vector3 posInspeccion, rotacionDefault;
    GameObject posCloseUp;
    public GameObject etiqueta, botella, tapa;
    public Material[] brands;
    public Material[] liquidos;
    public string[] marcas;

    //Propiedades principales
    private Material brand, colorLiquido;
    private bool modoInspeccion;
    void Start()
    {
        posCloseUp = GameObject.Find("posInspeccion");
        modoInspeccion = false;
        seleccionarMarca();
        pintar();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Este condicional es de Debug, RECORDAR DE QUITAR!
            seleccionarMarca();
            pintar();
        }
        if (modoInspeccion)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inspeccionarToggle();
            }
        }
    }
    private void seleccionarMarca()// Función que determina la marca que tendrá la botella
    {
        string seleccion = marcas[Random.Range(0, marcas.Length)];
        Debug.Log(seleccion);
        switch (seleccion)
        {
            case "Bubbly":
                brand = brands[0];
                colorLiquido = liquidos[0];
                break;
            case "Uva":
                brand = brands[1];
                colorLiquido = liquidos[1];
                break;
            case "Mango":
                brand = brands[2];
                colorLiquido = liquidos[2];
                break;
            default:
                break;
        }
    }
    private void pintar()//Esta funcion pinta el modelo de la botella por completo y le quita la tapa
    {
        etiqueta.GetComponent<Renderer>().material = brand;
        botella.GetComponent<Renderer>().material = colorLiquido;
        tapa.GetComponent<MeshRenderer>().enabled = false;
    }
    public void tapar() // Esta funcion le pone la tapa a la botella
    {
        tapa.GetComponent<MeshRenderer>().enabled = true;
    }
    public void inspeccionarToggle()
    {
        if (!modoInspeccion)
        {
            modoInspeccion = true;
            transform.position = posCloseUp.transform.position;
            //transform.position = new Vector3(transform.position.x, transform.position.y-0.1f, transform.position.z);
            GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            modoInspeccion = false;
            transform.position = posInspeccion;
            transform.rotation = Quaternion.Euler(rotacionDefault);
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = false; // Cambia esta linea a False para algo muy divertido
        }
        Debug.Log("Click?");
        
    }
    public bool verificarInspeccion()
    {
        return modoInspeccion;
    }
}
