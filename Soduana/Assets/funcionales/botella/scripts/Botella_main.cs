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
    //Secci�n de errores y neutrales
    public int peso;
    public float radioactividad;
    private bool botellaErronea;

    //Propiedades principales
    private Material brand, colorLiquido;
    private bool modoInspeccion;

    //Displays
    public GameObject basculaDisplay;
    private GameObject camara;
    void Start()
    {
        camara = GameObject.Find("Main Camera");
        basculaDisplay = GameObject.Find("basculaHUD");//Busca la pantalla de la b�scula
        posCloseUp = GameObject.Find("posInspeccion");
        modoInspeccion = false;
        errar();
        asignarError();
        transmitirPeso();
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
    private void seleccionarMarca()// Funci�n que determina la marca que tendr� la botella
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
            GetComponent<Rigidbody>().useGravity = true; // Cambia esta linea a False para algo muy divertido
        }
        Debug.Log("Click?");
        
    }
    public bool verificarInspeccion()
    {
        return modoInspeccion;
    }
    public void errar()//Define si la botella tendr� errores o no
    {
        int probabilidad = Random.Range(0, 100);
        if (probabilidad <= 50)
        {
            botellaErronea = false;
        }
        else
        {
            botellaErronea = true;
        }
    }
    public void asignarError()//Funci�n que verifica que la botella venga con error, de ser as�, pondr� un par�metro incorrecto
    {
        if (botellaErronea)
        {
            malPeso();

        }
    }
    private void malPeso()//Va a asignar un peso mayor o menor al requerido (800gr) sin alterar el volumen
    {
        int mayorOMenor = Random.Range(0, 100);
        if (mayorOMenor <= 50)
        {
            peso = Random.Range(700, 751);
        }
        else
        {
            peso = Random.Range(850, 901);
        }
    }
    //Funciones que transmiten informaci�n a terceros
    public void transmitirPeso()//Esta funcion pasa la informaci�n del peso directo a la b�scula
    {
        basculaDisplay.GetComponent<Bascula>().recibirPeso(peso);
    }
    public void OrdenarInspeccionACamara() //Esta funcion da la orden a la camara del jugador de moverse
    {//(por dios esta funcion ni siquiera deber�a de estar)
        camara.GetComponent<CamaraControl>().moverAInspeccion();
    }
}
