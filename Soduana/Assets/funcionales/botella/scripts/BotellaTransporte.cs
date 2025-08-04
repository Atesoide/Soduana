using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotellaTransporte : MonoBehaviour
{
    Rigidbody rigid;
    private GameObject limite;
    private float x;
    public float vel;
    private float vel2;//Esta variable guarda el valor inicial de velocidad, es un placeHolder
    public Vector3 spawnPos;
    private bool llego; //Variable completamente horrible
    void Start()
    {
        vel2 = vel;
        llego = false;
        GetComponent<BoxCollider>().enabled = false;
        x = transform.position.x;
        transform.position = spawnPos;
        limite = GameObject.FindGameObjectWithTag("limit");
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        x += vel * Time.deltaTime;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        if (x >= limite.transform.position.x && !llego)
        {
            llego = true;
            GetComponent<BoxCollider>().enabled = true;
            vel = 0;
            rigid.useGravity = true;
            rigid.isKinematic = false;
        }
    }
    public void go()
    {
        vel = vel2;
        rigid.useGravity = false;
        rigid.isKinematic = true;
    }
}
