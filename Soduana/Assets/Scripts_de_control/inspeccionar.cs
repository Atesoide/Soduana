using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inspeccionar : MonoBehaviour
{
    private Camera camaraComponente;

    private Transform PosObjetoInspeccionado;

    public float rotacionDeltaX;
    public float rotacionDeltaY;

    public float velRotacion;

    // Start is called before the first frame update
    void Start()
    {
        camaraComponente = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;

            if (CameraToMouseRay(Input.mousePosition, out rayHit))
            {
                if (rayHit.transform.gameObject.tag == "inspeccionable" && rayHit.transform.gameObject.GetComponent<Botella_main>().verificarInspeccion())
                {
                    PosObjetoInspeccionado = rayHit.transform;
                }
                
            }
            
        }
        rotacionDeltaX = -Input.GetAxis("Mouse X");
        rotacionDeltaY = Input.GetAxis("Mouse Y");
        if (Input.GetMouseButton(1) && PosObjetoInspeccionado && PosObjetoInspeccionado.GetComponent<Botella_main>().verificarInspeccion())
        {
            PosObjetoInspeccionado.rotation = 
                Quaternion.AngleAxis(rotacionDeltaX * velRotacion, transform.up) *
                Quaternion.AngleAxis(rotacionDeltaY * velRotacion, transform.right) *
                PosObjetoInspeccionado.rotation;
        }
    }
    private bool CameraToMouseRay(Vector2 posMouse, out RaycastHit RayHit)
    {
        Ray ray = camaraComponente.ScreenPointToRay(posMouse);

        return Physics.Raycast(ray, out RayHit);
    }
}
