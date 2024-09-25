using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    public float Puntos;//Controlar los puntos que tenemos.
    public TextMeshProUGUI textMesh;//Contola el componente de texto.

    public void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        textMesh.text = Puntos.ToString("0");
    }

    public void Sumar_Puntos(float Puntos_Entrada)
    {
        Puntos += Puntos_Entrada;
        Debug.Log("Ganar Puntos " + Puntos);
    }
}
