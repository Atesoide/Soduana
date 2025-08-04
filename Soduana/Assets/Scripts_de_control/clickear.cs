using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class clickear : MonoBehaviour
{
    public int prueba;
    public Item[] objetos;
    private void OnMouseDown()
    {
        foreach (var obj in objetos)
        {
            obj.llamarAccion();
        }
        
    }
    public class Item
    {
        [SerializeField] private UnityEvent trigger;
        public void llamarAccion()
        {
            trigger.Invoke();
        }
    }
}

