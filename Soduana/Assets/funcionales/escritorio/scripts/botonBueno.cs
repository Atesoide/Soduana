using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonBueno : MonoBehaviour
{
    GameObject botella;
    public float fuerzaEmpuje, empujeVertical;
    // Start is called before the first frame update
    void Start()
    {
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
    }
    public void empuoncito()
    {
        botella.GetComponent<Rigidbody>().AddForce(0, empujeVertical, fuerzaEmpuje, ForceMode.Impulse);
    }
}
