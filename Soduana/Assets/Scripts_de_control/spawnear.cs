using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnear : MonoBehaviour
{
    public GameObject Soda;
    // Start is called before the first frame update
    void Start()
    {
        producir();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void producir()
    {
        Instantiate(Soda, transform.position, transform.rotation);
    }
}
