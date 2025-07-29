using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawnear : MonoBehaviour
{
    public GameObject spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "inspeccionable")
        {
            Destroy(other.gameObject);
            spawner.GetComponent<spawnear>().producir();
        }
    }
}
