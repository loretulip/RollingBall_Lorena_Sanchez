using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploVectores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Para hacer tp en esta posición
        transform.position = new Vector3(3, 5, 0);
        transform.eulerAngles = new Vector3(45, 30, 90);
        transform.localScale = new Vector3(2, 4, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
