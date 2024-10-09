using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float velocidad,x, z;
    [SerializeField] int fuerzaSalto, fuerzaMove;
    [SerializeField] Vector3 direcciónSalto;
    [SerializeField] int vida = 100;
    int puntuacion;
    [SerializeField] TMP_Text textoPuntuacion,textoVida;
    Vector3 direccionMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal"); 
        z = Input.GetAxisRaw("Vertical");
        Saltar();

       
    }
    private void FixedUpdate()
    {
       Movimiento();
    }
    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(direcciónSalto * fuerzaSalto, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            Destroy(other.gameObject);
            puntuacion++;
            textoPuntuacion.SetText("Puntuacion: " + puntuacion);
        }
        //if (other.gameObject.CompareTag("Trampa"))
        //{
        //    vida-=10;
        //    textoVida.SetText("Vida: "+vida);
        //}
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Movimiento()
    {
        direccionMove = new Vector3(x, 0, z);
        rb.AddForce((direccionMove).normalized * fuerzaMove, ForceMode.Force);
    }
}
