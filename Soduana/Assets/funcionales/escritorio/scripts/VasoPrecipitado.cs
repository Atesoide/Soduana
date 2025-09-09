using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VasoPrecipitado : MonoBehaviour
{
    public float velocidadLlenado, volumenMaximo, velocidadVaciado;
    public GameObject liquido;
    private Vector3 volumenLiquido;

    void Start()
    {
        volumenLiquido = liquido.transform.localScale;
        liquido.transform.localScale = new Vector3(volumenLiquido.x, 0.01f, volumenLiquido.z);
        liquido.SetActive(false);
    }
    public void llenar()
    {
        StartCoroutine(Llenar());
    }
    public void vaciar()
    {
        StartCoroutine(Vaciar());
    }
    IEnumerator Llenar()
    {
        liquido.SetActive(true);
        while (liquido.transform.localScale.y < volumenMaximo)
        {
            liquido.transform.localScale = new Vector3(volumenLiquido.x, volumenLiquido.y + velocidadLlenado * Time.deltaTime, volumenLiquido.z);
            volumenLiquido = liquido.transform.localScale;
            yield return null;
        }
    }
    IEnumerator Vaciar()
    {
        while (liquido.transform.localScale.y > 0.01f)
        {
            liquido.transform.localScale = new Vector3(volumenLiquido.x, volumenLiquido.y - velocidadVaciado * Time.deltaTime, volumenLiquido.z);
            volumenLiquido = liquido.transform.localScale;
            yield return null;
        }
        liquido.SetActive(false);
    }
}
