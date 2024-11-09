using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaFin : MonoBehaviour
{
    [SerializeField] private GameObject pantallaFin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            pantallaFin.SetActive(true);
        }
    }
}
