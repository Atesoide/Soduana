using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Librer�a encargada de el control de escenas

public class Menus : MonoBehaviour
{
    public GameObject[] paneles;
    /*-----Indexaci�n-------
     * (REVISAR ARREGLO EN EL GAME MANAGER EN LA ESCENA DE "Menu_principal")
     * 
     *[0] Panel del men� principal
     *[1] Panel de los cr�ditos
    */
    public void iniciarJuego()//Funci�n que nos mandar� la escena principal
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void volverMenu()//Funci�n que nos mandar� la escena principal
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void cerrarJuego()//Funci�n para cerrar la aplicaci�n
    {
        Application.Quit();
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
