using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comandos_teclado : MonoBehaviour
{
    private bool pausado;
    private Menus scriptMenus;
    // Start is called before the first frame update
    void Start()
    {
        pausado = false;
        scriptMenus = GetComponent<Menus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (toglePausa())
            {
                scriptMenus.habilitarPanel(1);
            }
            else
            {
                scriptMenus.habilitarPanel(2);
            }
        }
    }
    public bool toglePausa()
    {
        if (pausado)
        {
            pausado = false;
            Time.timeScale = 1;
        }
        else
        {
            pausado = true;
            Time.timeScale = 0;
        }
        return pausado;
    }
    public void toggleP()
    {
        if (pausado)
        {
            pausado = false;
            Time.timeScale = 1;
        }
        else
        {
            pausado = true;
            Time.timeScale = 0;
        }
    }
}
