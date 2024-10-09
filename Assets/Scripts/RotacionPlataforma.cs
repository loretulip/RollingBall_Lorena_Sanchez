using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionPlataforma : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    [SerializeField] int vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(dir * vel * Time.deltaTime);

    }
}
