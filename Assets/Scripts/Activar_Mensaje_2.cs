using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar_Mensaje_2 : MonoBehaviour
{
    //Esta linea llama el objeto del con el cual queremos que interactue el trigger
    [SerializeField] private GameObject Mensaje_2;
    private SpriteRenderer spr;

    private void Start()
    {
        //Con este fragmento de codigo, llamamos la pripiedad de SpriteRender de nuestro objeto, para obtener su color y trasparencia.
        spr = Mensaje_2.GetComponent<SpriteRenderer>();
        Color Color_Mensaje_2 = spr.material.color;
        Color_Mensaje_2.a = 0.0f;
        spr.material.color = Color_Mensaje_2;
    }

    //Este condicional sirven para detectar cuando el Player colisiona con el trigger que creamos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("FadeIn");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //La corrutinas son funciones que se van a ejecutar a la par de los FixedUpdate o los Update
            //y son independientes de toda la programacion del mismo juego.
            StartCoroutine("FadeOut");
        }
    }

    IEnumerator FadeIn()
    {
        for (float i = 0.0f; i <= 1; i += 0.02f)
        {
            Color Color_Mensaje_2 = spr.material.color;
            Color_Mensaje_2.a = i;
            spr.material.color = Color_Mensaje_2;
            yield return (0.05f);
        }
    }

    IEnumerator FadeOut()
    {
        for (float i = 1; i >= 0; i -= 0.02f)
        {
            Color Color_Mensaje_2 = spr.material.color;
            Color_Mensaje_2.a = i;
            spr.material.color = Color_Mensaje_2;
            yield return (0.05f);
        }
    }
}
//Prueba del workflow 5
