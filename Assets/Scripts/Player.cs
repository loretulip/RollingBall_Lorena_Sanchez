using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int vel;
     Vector3 direccionB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h =  Input.GetAxisRaw("Horizontal"); //h= -1 (A, <-) ||| h= 1 (D, ->) ||| h=0 (NADA)
        float v=  Input.GetAxisRaw("Vertical"); //v= -1 S, abajo ||| v= 1 (W, arriba) ||| v=0 (NADA)
        direccionB.x = h;
        direccionB.y = v;
        transform.Translate(new Vector3(h,0,v).normalized*vel*Time.deltaTime);
        //transform.Translate(direccion*velocidad*Time.deltaTime);
    }
}
