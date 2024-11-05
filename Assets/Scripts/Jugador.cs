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
    [SerializeField] GameObject camaraB, camaraRampa;
    [SerializeField] float distanciaDetecciónSuelo;
    [SerializeField] LayerMask queEsSuelo;
    Vector3 direccionMove, direccionRay;

    [SerializeField] AudioClip sonidoMoneda;
    [SerializeField] AudioManager manager;

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
        if (vida <= 0)
        {
            Destroy(gameObject);
        }

    }
    private void FixedUpdate()
    {
        Movimiento();
    }
    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("salto");
            if(DetectarSuelo()==true)
            {
                rb.AddForce(direcciónSalto * fuerzaSalto, ForceMode.Impulse);
                Debug.Log("salto2");
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coleccionable"))
        {
            manager.ReproducirSonido(sonidoMoneda);
            Destroy(other.gameObject);
            puntuacion++;
            textoPuntuacion.SetText("Puntuacion: " + puntuacion);
            Debug.Log("Coleccionable");
        }

        //if (other.gameObject.CompareTag("MuroCamara"))
        //{
        //    Debug.Log("Muro");
        //    camaraB.SetActive(false);
        //    camaraRampa.SetActive(true);
        //}
            //if (other.gameObject.CompareTag("Trampa"))
            //{
            //    vida-=10;
            //    textoVida.SetText("Vida: "+vida);
            //}
          
    }
    void Movimiento()
    {
        direccionMove = new Vector3(x, 0, z);
        rb.AddForce((direccionMove).normalized * fuerzaMove, ForceMode.Force);
    }
    bool DetectarSuelo()
    {
        bool resultado = Physics.Raycast(transform.position, new Vector3(0, -1, 0), distanciaDetecciónSuelo, queEsSuelo);
        return resultado;
    }
}
