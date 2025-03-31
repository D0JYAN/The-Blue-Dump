using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel_1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ControladorDatosJuego controlador = FindObjectOfType<ControladorDatosJuego>();
            if (controlador != null)
            {
                controlador.GuardarDatos();
                Carga_Nivel_2.nivel_Carga_2("Nivel_1");
                Debug.Log("Punto de partida guardado");
            }
            else
            {
                Debug.LogError("No se encontró ControladorDatosJuego en la escena.");
            }
        }
    }
}
