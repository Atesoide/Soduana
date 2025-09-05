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
    public void cerrarJuego()//Función para cerrar la aplicación
    {
        Application.Quit();
    }
    public void mostrarCreditos()//Función para abrir panel de créditos
    {
        paneles[1].SetActive(true);
        inhabilitarMenu();
    }
    public void habilitarMenu()//Función para cerrar cualquier otro panel que no sea el de menú principal
    {
        foreach (var panel in paneles)
        {
            panel.SetActive(false);
        }
        paneles[0].SetActive(true);
    }
    private void inhabilitarMenu()//Función para cerrar el panel de menú principal
    {
        paneles[0].SetActive(false);
    }
    public void ejemplo(int numero)
    {

    }
}
