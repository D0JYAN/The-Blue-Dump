using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarProgreso : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Puedes cambiar la tecla si lo deseas
        {
            if (ControladorDatosJuego.instancia != null)
            {
                ControladorDatosJuego.instancia.GuardarDatos();
                Debug.Log("Progreso guardado desde GuardarProgreso.cs");
            }
            else
            {
                Debug.LogError("No se encontró la instancia de ControladorDatosJuego.");
            }
        }
    }
}
