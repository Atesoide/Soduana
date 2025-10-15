using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botella_main : MonoBehaviour
{
    private enum Errores
    {
        Radiacion,
        peso,
        etiquetado
    }
    public int pago;

    public Vector3 posInspeccion, rotacionDefault;
    GameObject posCloseUp, manager;
    public GameObject etiqueta, botella, tapa;
    public Material[] brands, erroresEtiqueta;
    public Material[] liquidos;
    public string[] marcas;
    //Sección de errores y neutrales
    public int peso;
    public float radioactividad;
    private bool botellaErronea;

    //Propiedades principales
    private Material brand, colorLiquido;
    private bool modoInspeccion;

    //Displays
    public GameObject basculaDisplay, geigerDisplay;
    private GameObject camara;
    void Start()
    {
        radioactividad = Mathf.Round(Random.Range(0.1f, 0.26f) * 100f) / 100f;//UNICO valor que se genera al inicio
        camara = GameObject.Find("Main Camera");
        basculaDisplay = GameObject.Find("basculaHUD");//Busca la pantalla de la báscula
        geigerDisplay = GameObject.Find("geigerHUD");//Busca la pantalla del contador Geiger
        posCloseUp = GameObject.Find("posInspeccion");
        manager = GameObject.Find("GameManager");
        modoInspeccion = false;
        seleccionarMarca();
        errar();
        asignarError();
        transmitirPeso();
        transmitirRadioactividad();
        pintar();
        
    }

    void Update()
    {

    }
    private void seleccionarMarca()// Función que determina la marca que tendrá la botella
    {
        string seleccion = marcas[Random.Range(0, marcas.Length)];
        switch (seleccion)
        {
            case "Mango":
                brand = brands[0];
                colorLiquido = liquidos[0];
                break;
            case "Uva":
                brand = brands[1];
                colorLiquido = liquidos[1];
                break;
            case "Bufizz":
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
            manager.GetComponent<Menus>().habilitarPanel(3);
            modoInspeccion = true;
            transform.position = posCloseUp.transform.position;
            //transform.position = new Vector3(transform.position.x, transform.position.y-0.1f, transform.position.z);
            GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            manager.GetComponent<Menus>().habilitarPanel(2);
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
    public void errar()//Define si la botella tendrá errores o no
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
    public void asignarError()//Función que verifica que la botella venga con error, de ser así, pondrá un parámetro incorrecto
    {
        /*Nota personal: System.Enum.GetValues(typeof(Errores)).Lenght 
         * Devuelve un array con todos los valores de un Enum*/
        Errores equivocacion = (Errores)Random.Range(0, System.Enum.GetValues(typeof(Errores)).Length);
        if (botellaErronea)
        {
            switch (equivocacion)
            {
                case Errores.Radiacion:
                    esRadioactivo();
                    break;
                case Errores.peso:
                    malPeso();
                    break;
                case Errores.etiquetado:
                    string seleccion = marcas[Random.Range(0, marcas.Length)];
                    switch (seleccion)
                    {
                        case "Mango":
                            brand = erroresEtiqueta[0];
                            colorLiquido = liquidos[0];
                            break;
                        case "Uva":
                            brand = erroresEtiqueta[1];
                            colorLiquido = liquidos[1];
                            break;
                        case "Bufizz":
                            brand = erroresEtiqueta[2];
                            colorLiquido = liquidos[2];
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
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
    private void esRadioactivo()//Le pondrá una cantidad de grays peligrosamente radioactiva a la botella
    {
        
        float grays = Mathf.Round(Random.Range(0.30f, 0.75f) * 100f) / 100f;
        radioactividad = grays;
        Debug.Log(radioactividad);
    }
    //Funciones que transmiten información a terceros
    public void transmitirPeso()//Esta funcion pasa la información del peso directo a la báscula
    {
        basculaDisplay.GetComponent<Bascula>().recibirPeso(peso);
    }
    public void transmitirRadioactividad()//Pasa la información de los grays directo al contador
    {
        geigerDisplay.GetComponent<Geiger>().recibirRadioactividad(radioactividad);
    }
    public void OrdenarInspeccionACamara() //Esta funcion da la orden a la camara del jugador de moverse
    {//(por dios esta funcion ni siquiera debería de estar)
        camara.GetComponent<CamaraControl>().moverAInspeccion();
    }
    //-------DIVISION DE BIBTACORA NO.8-------
    public void pagar()
    {
        endGameScripts.dinero += pago;
    }
    public void descontar()
    {
        endGameScripts.dinero -= pago;
    }
    public bool revisarError()
    {
        return botellaErronea;
    }
}
