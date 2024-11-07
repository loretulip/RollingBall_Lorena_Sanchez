using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroCubos : MonoBehaviour
{
    [SerializeField] GameObject camaraNormal;          // C�mara normal
    [SerializeField] GameObject camaraLenta;          // C�mara para el efecto de c�mara lenta
    public float tiempoC�maraLenta = 2f; // Tiempo que la c�mara estar� lenta

    private Transform[] cubos;           // Array para almacenar los cubos (ahora usaremos Transform)

    private float timeSlowedTimer = 0f; // Temporizador para el efecto de c�mara lenta
    private Collider muroCollider;      // El collider del muro para desactivarlo

    void Start()
    {
        // Obtener todos los cubos como hijos de este objeto
        cubos = GetComponentsInChildren<Transform>();

        // Obtener el collider del muro
        muroCollider = GetComponent<Collider>();

        // Desactivar la f�sica de los cubos inicialmente (hacer que sean kinem�ticos)
        foreach (Transform cubo in cubos)
        {
            // Asegurarse de que solo se seleccionan los cubos, no el objeto "muro" en s�
            if (cubo != transform)
            {
                Rigidbody rb = cubo.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true; // Mantener kinematic para que no se muevan al principio
                }
            }
        }
    }

    void Update()
    {
        if (timeSlowedTimer > 0f)
        {
            timeSlowedTimer -= Time.unscaledDeltaTime;

            // Si el tiempo de c�mara lenta ha pasado, volver a la normalidad
            if (timeSlowedTimer <= 0f)
            {
                // Volver a la c�mara normal
                camaraNormal.SetActive(true);
                camaraLenta.SetActive(false);

                // Restaurar la velocidad normal del tiempo
                Time.timeScale = 1f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el jugador choca con el muro
        if (other.gameObject.CompareTag("Player"))
        {
            // Cambiar la f�sica de los cubos para que caigan
            foreach (Transform cubo in cubos)
            {
                if (cubo != transform) // Asegurarse de que no estamos intentando mover el muro (el contenedor)
                {
                    Rigidbody rb = cubo.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = false;  // Hacer que los cubos puedan moverse con la f�sica
                    }
                }
            }

            // Activar la c�mara lenta y las dem�s l�gicas
            camaraNormal.SetActive(false);
            camaraLenta.SetActive(true);
            Time.timeScale = 0.5f;

            // Iniciar el temporizador para la c�mara lenta
            timeSlowedTimer = tiempoC�maraLenta;

            // Desactivar el collider para evitar que vuelva a activar la c�mara lenta
            muroCollider.enabled = false;
        }
    }
}
