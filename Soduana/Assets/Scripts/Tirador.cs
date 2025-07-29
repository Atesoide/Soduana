using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirador : MonoBehaviour
{
    public GameObject limiteSup, limiteInf;
    public float velocidadEndemoniada, velocidadRetractil;
    private float velRetHolder, y, velEndHolder;
    private bool fuera;
    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
        velRetHolder = 0;
        velEndHolder = 0;
        fuera = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fuera)
        {
            y += velEndHolder * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
            if (y >= limiteSup.transform.position.y)
            {
                fuera = false;
                velRetHolder = velocidadRetractil;
            }
        }
        else
        {
            y -= velRetHolder * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
            if (y <= limiteInf.transform.position.y)
            {
                velRetHolder = 0;
            }
        }
    }
    public void salir()
    {
        fuera = true;
        velEndHolder = velocidadEndemoniada;
    }
}
