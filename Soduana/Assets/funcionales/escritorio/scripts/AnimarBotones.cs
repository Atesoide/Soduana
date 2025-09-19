using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimarBotones : MonoBehaviour
{
    private Animator animador;
    public GameObject audio;

    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>();   
    }
    public void botonVerde()
    {
        animador.SetTrigger("verde");
        clickSonido();
    }
    public void botonRojo()
    {
        animador.SetTrigger("rojo");
        clickSonido();
    }
    private void clickSonido()
    {
        Instantiate(audio, transform.position, transform.rotation);
    }
}
