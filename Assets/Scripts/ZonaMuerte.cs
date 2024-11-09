using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public GameObject pantallaMuerte;

    private void Start()
    {
        // Asegura que la pantalla de muerte esté oculta al inicio
        if (pantallaMuerte != null)
            pantallaMuerte.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            // Activa la pantalla de muerte
            if (pantallaMuerte != null)
            {
                pantallaMuerte.SetActive(true);
            }
            Debug.Log("Muerte");

        }
    }
    public void Reiniciar()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuInicial"); 
    }
}
