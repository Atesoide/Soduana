using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endGameScripts : MonoBehaviour
{
    public static int dinero;

    public GameObject panelCortina;
    public Image cortina;
    public float velocidadFade;
    private Color alfa; //A pesar de que es una estructura de color debe usarse EXCLUSIVAMENTE para el alfa
    // Start is called before the first frame update
    void Start()
    {
        alfa = cortina.color;
        fadeIn();
    }

    public void fadeIn()
    {
        StartCoroutine(FadeIn());
    }
    public void fadeOut()
    {
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(2f);
        do
        {
            alfa.a -= velocidadFade * Time.deltaTime;
            cortina.color = alfa;
            yield return null;
        } while (alfa.a > 0);
        panelCortina.SetActive(false);
    }
    IEnumerator FadeOut()
    {
        panelCortina.SetActive(true);
        yield return new WaitForSeconds(2f);
        do
        {
            alfa.a += velocidadFade * Time.deltaTime;
            cortina.color = alfa;
            yield return null;
        } while (alfa.a < 1);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Menus>().irAlFinal();
    }
}
