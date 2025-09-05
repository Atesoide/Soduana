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
    public void cerrarJuego()//Funci�n para cerrar la aplicaci�n
    {
        Application.Quit();
    }
    public void mostrarCreditos()//Funci�n para abrir panel de cr�ditos
    {
        paneles[1].SetActive(true);
        inhabilitarMenu();
    }
    public void habilitarMenu()//Funci�n para cerrar cualquier otro panel que no sea el de men� principal
    {
        foreach (var panel in paneles)
        {
            panel.SetActive(false);
        }
        paneles[0].SetActive(true);
    }
    private void inhabilitarMenu()//Funci�n para cerrar el panel de men� principal
    {
        paneles[0].SetActive(false);
    }
    public void ejemplo(int numero)
    {

    }
}
