using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptInnecesario : MonoBehaviour
{
    public float vel;
    private float z;
    private Vector3 posInicial;
    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(posInicial);
        z += vel * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
    public void repos()
    {
        z = posInicial.z;
        Debug.Log("trigger");
    }
}
