using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class click2 : MonoBehaviour
{
    public Item[] objetos;
    private void OnMouseDown()
    {
        foreach (var obj in objetos)
        {
            obj.llamarAccion();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    public class Item
    {
        [SerializeField] private UnityEvent trigger;
        public void llamarAccion()
        {
            trigger.Invoke();
        }
    }
}
