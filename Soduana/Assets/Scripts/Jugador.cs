using System;
//using Mathematics.Geometry;
using UnityEngine;
using UnityEngine.Rendering;

public class Jugador : MonoBehaviour
{
    Vector3 rotacion;
    public GameObject objetoPuntoOrigenRayo;

    Vector3 posicion;
    Vector3 velocidad;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicion = Vector3.zero;
        velocidad = Vector3.zero;
        rotacion = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        velocidad.x = Input.GetAxisRaw("Horizontal")*2;
        velocidad.z = Input.GetAxisRaw("Vertical")*2;
        if (velocidad.x > 0 && velocidad.z == 0)
        {
            rotacion.y = 90;
        }
        else if (velocidad.x < 0 && velocidad.z == 0)
        {
            rotacion.y = 270;
        }
        else if (velocidad.z > 0 && velocidad.x == 0)
        {
            rotacion.y = 0;
        }
        else if (velocidad.z < 0 && velocidad.x == 0)
        {
            rotacion.y = 180;
        }

        // Movimientos diagonales
        else if (velocidad.x > 0 && velocidad.z > 0)
        {
            rotacion.y = 45;
        }
        else if (velocidad.x < 0 && velocidad.z > 0)
        {
            rotacion.y = 315;
        }
        else if (velocidad.x > 0 && velocidad.z < 0)
        {
            rotacion.y = 135;
        }
        else if (velocidad.x < 0 && velocidad.z < 0)
        {
            rotacion.y = 225;
        }


        posicion += velocidad * Time.deltaTime;

        this.transform.position = posicion;

        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(rotacion), 500 * Time.deltaTime);

        

    }
    public float checarVelocidad()
    {
        float velocidadFlotante = Mathf.Abs(velocidad.x) + Mathf.Abs(velocidad.z);
        return velocidadFlotante;
    }


}
