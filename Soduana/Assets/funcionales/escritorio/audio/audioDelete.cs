using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioDelete : MonoBehaviour
{
    private AudioSource ASObjeto;

    void Start()
    {
        ASObjeto = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ASObjeto.isPlaying) //Verifica si el sonido se terminó de repeoducir
        {
            Destroy(this.gameObject);
        }
    }
}
