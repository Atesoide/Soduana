using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manecillas : MonoBehaviour
{
    private GameObject gameManager;
    public int vueltas;

    private float rotZ, rotacionReal;
    public float velRotacion;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        rotZ = transform.rotation.z;
        velRotacion *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        //LA VUELTA COMPLETA ES A -270 GRADOS
        rotZ += velRotacion * Time.deltaTime;
        rotacionReal += velRotacion * Time.deltaTime;
        Quaternion rotacion = Quaternion.Euler(0, 0, rotZ+90);
        transform.rotation = rotacion;

        /*La siguiente condicional va a averigüar si la manecilla del reloj ya dió las vueltas requeridas,
         de ser así, entonces terminará la jornada. Las vueltas se definen desde el editor*/
        if (rotacionReal <= vueltas * (-360))
        {
            velRotacion = 0;
            finalizarJornada();
        }
    }
    private void finalizarJornada()
    {
        gameManager.GetComponent<endGameScripts>().fadeOut();
    }
}
