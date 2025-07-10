using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueoPorPuntos : MonoBehaviour
{
    public float puntosNecesarios = 30f;

    private void Update()
    {
        if (Puntaje.instancia != null && Puntaje.instancia.Puntos >= puntosNecesarios)
        {
            Destroy(gameObject); // Destruye este objeto (el bloqueo)
        }
    }
}