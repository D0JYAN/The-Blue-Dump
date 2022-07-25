using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basura : MonoBehaviour
{
    [SerializeField] private float Cantidad_Puntos;
    [SerializeField] private Puntaje Puntaje;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Puntaje.Sumar_Puntos(Cantidad_Puntos);
            Destroy(gameObject);
        }
    }
}
