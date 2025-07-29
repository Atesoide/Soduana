using UnityEngine;

public class Animacion : MonoBehaviour
{
    public Animator animador;
    private Jugador scriptJugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animador = GetComponent<Animator>();
        scriptJugador = GetComponent<Jugador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptJugador.checarVelocidad() > 0 || scriptJugador.checarVelocidad() < 0)
        {
            animador.SetTrigger("corriendo");
        }
        else
        {
            animador.SetTrigger("idle");
        }


    }
}
