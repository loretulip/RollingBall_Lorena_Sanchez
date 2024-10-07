using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] int vel;
    [SerializeField] Vector3 direccionB;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h =  Input.GetAxisRaw("Horizontal"); //h= -1 (A, <-) ||| h= 1 (D, ->) ||| h=0 (NADA)
        float v=  Input.GetAxisRaw("Vertical"); //v= -1 S, abajo ||| v= 1 (W, arriba) ||| v=0 (NADA)
        rb.AddForce(new Vector3 (h, v, 0).normalized*vel);
        //direccionB.x = h;
        //direccionB.y = v;
        //transform.Translate(new Vector3(h,0,v).normalized*vel*Time.deltaTime);
        //transform.Translate(direccion*velocidad*Time.deltaTime);

       
    }
    private void FixedUpdate()
    {
        rb.AddForce(direccionB * 5, ForceMode.Force);
        Saltar();

        //GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);

    }
    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }

    }
}
