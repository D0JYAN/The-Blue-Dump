using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoTrigger : MonoBehaviour
{
    [SerializeField] private GameObject texto; // El objeto de texto que quieres mostrar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            texto.SetActive(true); // Mostrar texto
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            texto.SetActive(false); // Ocultar texto
        }
    }
}

