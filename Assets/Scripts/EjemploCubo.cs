using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploCubo : MonoBehaviour
{
    //NO se puede referenciar desde un prefab nada que haya en la escena
    [SerializeField] private GameObject copiaCubo1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(copiaCubo1.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
