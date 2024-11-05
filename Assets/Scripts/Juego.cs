using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour
{
    [SerializeField] float vel;
    [SerializeField] Vector3 dir;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        transform.Translate(dir * vel * Time.deltaTime);
        //Debug.Log(timer);
        if (timer >= 1)
        {
            timer = 0;
            dir *= -1;
        }      
        
        

        //if (direccionR=false)
        //{
        //    direccionR=true;
        //}
        //else if (direccionR=true)
        //{
        //    transform.Translate(-dir * vel * Time.deltaTime);
        //    direccionR = false;
        //}
    }
   
}
