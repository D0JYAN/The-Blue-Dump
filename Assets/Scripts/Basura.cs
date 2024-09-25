using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basura : MonoBehaviour
{
    [SerializeField] public float Cantidad_Puntos;
    [SerializeField] public Puntaje Puntaje;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Puntaje.Sumar_Puntos(Cantidad_Puntos);
            Destroy(gameObject);
            Debug.Log("Ganar Puntos 2");
        }
    }
}
