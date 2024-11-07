using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour

{
    [SerializeField] private GameObject menuPausa;

    bool pausa = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        Pausa();

    }
    
    public void Pausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pausa == false)
        {
            // SE MUESTRA CURSOR
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            menuPausa.SetActive(true);
            pausa = true;
            Debug.Log("Juego Pausado");

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pausa == true)
        {
            // NO SE MUESTRA CURSOR
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            menuPausa.SetActive(false);
            pausa = false;
            Debug.Log("Juego Reanudado");

        }
    }
    public void Reanudar()
    {
        Cursor.lockState = CursorLockMode.Locked;        
        Time.timeScale = 1f;        
        menuPausa.SetActive(false);
        pausa = false;
        
    }
    public void Reiniciar()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        pausa = false;
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliendo...");
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }    
   

}
