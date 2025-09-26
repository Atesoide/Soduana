using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Librería encargada de el control de escenas

public class Menus : MonoBehaviour
{
    public GameObject[] paneles;
    /*-----Indexación-------
     * (REVISAR ARREGLO EN EL GAME MANAGER EN LA ESCENA DE "Menu_principal")
     * 
     *[0] Panel del menú principal
     *[1] Panel de los créditos
    */
    public void iniciarJuego()//Función que nos mandará la escena principal
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void volverMenu()//Función que nos mandará la escena principal
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void cerrarJuego()//Función para cerrar la aplicación
    {
        Application.Quit();
    }

    public void habilitarPanel(int index) //función que muestra el panel que nosotros definamos desde el editor
    {
        foreach (GameObject panel in paneles)
        {
            panel.SetActive(false);
        }
        paneles[index].SetActive(true);
    }

}
