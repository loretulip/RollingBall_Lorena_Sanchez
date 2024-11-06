using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.ShaderData;

public class Jugador : MonoBehaviour
{
    [Header("Movimiento")]
    Rigidbody rb;
    [SerializeField] float velocidad, x, z;
    [SerializeField] int fuerzaSalto, fuerzaMove;
    [SerializeField] Vector3 direcciónSalto;
    [SerializeField] float distanciaDetecciónSuelo;
    [SerializeField] LayerMask queEsSuelo;
    Vector3 direccionMove, direccionRay;

    [Header("Vida y puntuación")]
    [SerializeField] int vida = 100;
    [SerializeField] int puntuacion;

    [Header("Texto")]
    [SerializeField] TMP_Text textoPuntuacion;
    [SerializeField] TMP_Text textoVida;

    [Header("Cámaras")]
    [SerializeField] GameObject camaraB;
    [SerializeField] GameObject camaraRampa;

    [Header("Audio")]
    [SerializeField] AudioClip sonidoMoneda;
    [SerializeField] AudioManager manager;

    [Header("Menus")]
    [SerializeField] private GameObject menuPausa;
    bool pausa = false;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

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
        ActualizarHUD();
    }
    private void FixedUpdate()
    {
        Movimiento();
    }
    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(DetectarSuelo()==true)
            {
                rb.AddForce(direcciónSalto * fuerzaSalto, ForceMode.Impulse);
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
    void ActualizarHUD()
    {
        textoPuntuacion.text = "Puntos: " + puntuacion;
    }
  
}
