using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorGuardado : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ControladorDatosJuego controlador = FindObjectOfType<ControladorDatosJuego>();
            if (controlador != null)
            {
                controlador.GuardarDatos();
                Debug.Log("Punto de partida guardado");
            }
            else
            {
                Debug.LogError("No se encontró ControladorDatosJuego en la escena.");
            }
        }
    }
}
