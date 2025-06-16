using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel1_Start : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ControladorDatosJuego controlador = FindObjectOfType<ControladorDatosJuego>();
            if (controlador != null)
            {
                controlador.GuardarDatos();
                Carga_Nivel.nivel_Carga("Estacion");
                Debug.Log("Punto de partida guardado");
            }
            else
            {
                Debug.LogError("No se encontró ControladorDatosJuego en la escena.");
            }
        }
    }
}
