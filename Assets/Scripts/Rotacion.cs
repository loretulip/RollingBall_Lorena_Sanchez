using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    [SerializeField] int vel,fuerzaGiro;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(dir * fuerzaGiro, ForceMode.VelocityChange);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
