using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoRebotador : MonoBehaviour
{
    public float velocidad = 3f;
    private Vector2 direccion = Vector2.right;

    private void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        // Rebotar dependiendo de la normal de la colisión
        Vector2 normal = colision.contacts[0].normal;
        direccion = Vector2.Reflect(direccion, normal).normalized;
    }
}

