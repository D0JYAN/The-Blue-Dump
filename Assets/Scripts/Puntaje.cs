using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    public static Puntaje instancia;
    public float Puntos; // Controlar los puntos que tenemos.
    public TextMeshProUGUI textMesh; // Controla el componente de texto.

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Mantener entre escenas
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        if (textMesh == null)
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        ActualizarTextoPuntaje();
    }

    private void Update()
    {
        ActualizarTextoPuntaje();
    }

    public void Sumar_Puntos(float puntosEntrada)
    {
        Puntos += puntosEntrada;
        ActualizarTextoPuntaje();
        Debug.Log("Ganar Puntos " + Puntos);
    }

    public void ActualizarTextoPuntaje()
    {
        if (textMesh != null)
        {
            textMesh.text = Puntos.ToString("0");
        }
    }
}
