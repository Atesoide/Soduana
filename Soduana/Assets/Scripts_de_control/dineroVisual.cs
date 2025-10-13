using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dineroVisual : MonoBehaviour
{
    private Color colorDinero;
    public TMP_Text textoDinero;
    public Vector3[] posiciones;
    public float velocidad, intervaloParpadeo;

    // Start is called before the first frame update
    void Start()
    {
        colorDinero = textoDinero.color;
        transform.position = posiciones[0];
        //colorDinero = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ganarDinero()
    {
        textoDinero.text = "+10";
        colorDinero = new Color(255, 248, 11, 1);
        textoDinero.color = colorDinero;
        StartCoroutine(SubirTexto());
    }
    public void perderDinero()
    {
        textoDinero.text = "-$10";
        colorDinero = new Color(255, 11, 18, 1);
        textoDinero.color = colorDinero;
        StartCoroutine(SubirTexto());
    }
    IEnumerator SubirTexto()
    {
        float paso = 0;
        do
        {
            paso = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, posiciones[1], paso);
            yield return null;
        } while (transform.position != posiciones[1]);
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < 3; i++)
        {
            colorDinero.a = 0;
            textoDinero.color = colorDinero;
            yield return new WaitForSeconds(intervaloParpadeo);
            colorDinero.a = 1;
            textoDinero.color = colorDinero;
            yield return new WaitForSeconds(intervaloParpadeo);
        }
        transform.position = posiciones[0];
        yield return null;
    }
}
