using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manecillas : MonoBehaviour
{
    private float rotZ;
    public float velRotacion;
    // Start is called before the first frame update
    void Start()
    {
        velRotacion *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        //LA VUELTA COMPLETA ES A -270 GRADOS
        rotZ += velRotacion * Time.deltaTime;
        Quaternion rotacion = Quaternion.Euler(0, 0, rotZ);
        transform.rotation = rotacion;
    }
}
