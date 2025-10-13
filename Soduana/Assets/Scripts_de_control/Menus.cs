using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Librer�a encargada de el control de escenas

public class Menus : MonoBehaviour
{
    public GameObject[] paneles;
    /*-----Indexaci�n-------
     * ----Men� principal------
     * (REVISAR ARREGLO EN EL GAME MANAGER EN LA ESCENA DE "Menu_principal")
     * 
     *[0] Panel del men� principal
     *[1] Panel de los cr�ditos
     *
     *----Escena principal-----
     *[0] Panel de inspeccionables
     *[1] Panel pausa
     *[2] HUD principal (vac�o)
    */
    public void iniciarJuego()//Funci�n que nos mandar� la escena principal
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
    public void volverMenu()//Funci�n que nos mandar� la escena principal
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void cerrarJuego()//Funci�n para cerrar la aplicaci�n
    {
        Application.Quit();
    }
    public void irAlFinal()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    public void habilitarPanel(int index) //funci�n que muestra el panel que nosotros definamos desde el editor
    {
        foreach (GameObject panel in paneles)
        {
            panel.SetActive(false);
        }
        paneles[index].SetActive(true);
    }

}
