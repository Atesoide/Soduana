using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonBueno : MonoBehaviour
{
    GameObject botella;
    public float fuerzaEmpuje, empujeVertical;

    public dineroVisual dineroScript;
    // Start is called before the first frame update
    void Start()
    {
        dineroScript = GameObject.Find("Dinero").GetComponent<dineroVisual>();
        eliminarBotella();
    }

    // Update is called once per frame
    void Update()
    {
        if (!botella)
        {
            detectarBotella();
        }
    }
    public void detectarBotella()
    {
        botella = GameObject.FindGameObjectWithTag("inspeccionable");
        Debug.Log("Trigger");
    }
    public void eliminarBotella()
    {
        botella = null;
    }
    public void Aprobar()
    {
        if (botella)
        {
            botella.GetComponent<BotellaTransporte>().go();
            
        }
        if (!botella.GetComponent<Botella_main>().revisarError())
        {
            dineroScript.ganarDinero();
            botella.GetComponent<Botella_main>().pagar();
        }
        else
        {
            dineroScript.perderDinero();
            botella.GetComponent<Botella_main>().descontar();
        }

    }
    public void empuoncito()
    {
        if (botella.GetComponent<Botella_main>().revisarError())
        {
            dineroScript.ganarDinero();
            botella.GetComponent<Botella_main>().pagar();
        }
        else
        {
            dineroScript.perderDinero();
            botella.GetComponent<Botella_main>().descontar();
        }
        botella.GetComponent<Rigidbody>().AddForce(0, empujeVertical, fuerzaEmpuje, ForceMode.Impulse);
    }
}
