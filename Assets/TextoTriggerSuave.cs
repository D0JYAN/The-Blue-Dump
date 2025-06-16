using System.Collections;
using UnityEngine;
using TMPro;

public class TextoTriggerSuave : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private float duracion = 1f;

    private Coroutine fadeActual;

    private void Start()
    {
        SetAlpha(0); // Comienza oculto
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (fadeActual != null) StopCoroutine(fadeActual);
            fadeActual = StartCoroutine(FadeTexto(1f)); // Aparecer
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (fadeActual != null) StopCoroutine(fadeActual);
            fadeActual = StartCoroutine(FadeTexto(0f)); // Desaparecer
        }
    }

    private IEnumerator FadeTexto(float alphaObjetivo)
    {
        float alphaInicial = texto.color.a;
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            float t = tiempo / duracion;
            float alpha = Mathf.Lerp(alphaInicial, alphaObjetivo, t);
            SetAlpha(alpha);
            tiempo += Time.deltaTime;
            yield return null;
        }

        SetAlpha(alphaObjetivo);
    }

    private void SetAlpha(float alpha)
    {
        Color color = texto.color;
        color.a = alpha;
        texto.color = color;
    }
}
