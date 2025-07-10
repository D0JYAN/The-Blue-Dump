using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salto_Demo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ControladorDatosJuego controlador = FindObjectOfType<ControladorDatosJuego>();
            if (controlador != null)
            {
                controlador.GuardarDatos();
                Cargar_Demo.nivel_Carga_demo("NuevoMenu");
                Debug.Log("Punto de partida guardado");
            }
            else
            {
                Debug.LogError("No se encontró ControladorDatosJuego en la escena.");
            }
        }
    }
}
