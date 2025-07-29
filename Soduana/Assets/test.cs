using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Vector3 pos;
    private Vector3 rota;
    private Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        pos = Vector3.zero;
        rota = Vector3.zero;
        vel = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        vel.x = Input.GetAxisRaw("Vertical") * 2;
        if (vel.x > 0)
        {
            rota.x = 15;
        }
        else if (vel.x < 0)
        {
            rota.x = -15;
        }
        else
        {
            rota.x = 0;
        }

        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(rota), 500 * Time.deltaTime);

    }
}
