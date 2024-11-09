using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MenuPausa : MonoBehaviour

{
    [SerializeField] private GameObject menuPausa;
    [SerializeField] public Volume globalVolume;
    private UnityEngine.Rendering.Universal.DepthOfField depthOfField;


    private float normalFocusDistance = 2.06f;
    private float pausaFocusDistance = 0f;


    bool pausa = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        if (globalVolume.profile.TryGet(out depthOfField))
        {
            // Inicialmente, establece el valor normal
            depthOfField.focusDistance.value = normalFocusDistance;
        }
        else
        {
            Debug.LogError("Depth of Field no encontrado en el perfil del Volume.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Pausa();
        FondoBorrosoPausa();
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
    public void FondoBorrosoPausa()
    {       
        if (Time.timeScale == 0)
        {
            depthOfField.focusDistance.value = pausaFocusDistance;
        }
        else
        {
            depthOfField.focusDistance.value = normalFocusDistance;
        }
    }
   

}
