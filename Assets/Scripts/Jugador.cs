using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    [Header("Movimiento")]
    Rigidbody rb;
    [SerializeField] float velocidad, x, z;
    [SerializeField] int fuerzaSalto, fuerzaMove;
    [SerializeField] Vector3 direcciónSalto;
    [SerializeField] float distanciaDetecciónSuelo;
    [SerializeField] LayerMask queEsSuelo;

    Vector3 direccionMove, direccionRay, inicio;

    [Header("Vida y puntuación")]
    [SerializeField] public int puntuacion;

    [Header("Texto")]
    [SerializeField] TMP_Text textoPuntuacion;
    [SerializeField] TMP_Text textoVida;
       

    [Header("Audio")]
    [SerializeField] AudioClip sonidoMoneda;
    [SerializeField] AudioManager manager;

    [Header("Menus")]
    [SerializeField] private GameObject menuPausa;
    [SerializeField] public GameObject pantallaMuerte;
    [SerializeField] public GameObject pantallaHUD;

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
            if (DetectarSuelo() == true)
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
            puntuacion += 5;
            textoPuntuacion.SetText("Puntuacion: " + puntuacion);
            Debug.Log("Coleccionable");
        }
        if (other.CompareTag("Muerte"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0.3f;
            Debug.Log("Muerte");
            puntuacion = 0;
            pantallaMuerte.SetActive(true);
            pantallaHUD.SetActive(false);
        }


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
    void Muerte()
    {
        if (CompareTag("Muerte"))
        {
            pantallaMuerte.SetActive (true);
        }
    }

  
}
