using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraTop : MonoBehaviour
{
    [Header("Cámaras")]
    [SerializeField] GameObject camaraB;
    [SerializeField] GameObject camaraRampa;
    // Start is called before the first frame update
    void Start()
    {
        camaraB.SetActive(true);
        camaraRampa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto con el que chocamos tiene el tag "CamaraTop"
        if (other.CompareTag("CamaraTop"))
        {
            // Cambiamos a la cámara de la rampa
            camaraB.SetActive(false);
            camaraRampa.SetActive(true);
            Debug.Log("Trigger");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Cuando el jugador salga del trigger, volvemos a la cámara principal
        if (other.CompareTag("CamaraTop"))
        {
            camaraB.SetActive(true);
            camaraRampa.SetActive(false);
        }
    }
}
