using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour
{
    public float Velocidad;
    private float Z;
    public GameObject x;
    public Vector3 posicionIninicial;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = posicionIninicial;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y, Z);
        if (Input.GetKey(KeyCode.S))
        {
            Z += Velocidad * Time.deltaTime;
        }
    }
}
