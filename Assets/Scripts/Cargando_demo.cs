using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Localization;

public class Cargando_demo : MonoBehaviour
{
    public Text texto;
    public string claveTextoContinuar = "presione"; // Clave de la tabla de Localización
    public string nombreTabla = "Opciones"; // Nombre de la tabla en Localization

    private void Start()
    {
        // Tomamos la escena desde el sistema de salto de demo
        string nivelADemo = Cargar_Demo.Pantalla_demo;

        if (string.IsNullOrEmpty(nivelADemo))
        {
            texto.text = "Error: Escena inválida.";
            return;
        }

        StartCoroutine(Iniciar_Carga_2(nivelADemo));
    }

    IEnumerator Iniciar_Carga_2(string nivel)
    {
        yield return new WaitForSeconds(2f);
        AsyncOperation operacion = SceneManager.LoadSceneAsync(nivel);
        operacion.allowSceneActivation = false;

        while (!operacion.isDone)
        {
            if (operacion.progress >= 0.9f)
            {
                // Traducción dinámica
                LocalizedString textoContinuar = new LocalizedString(nombreTabla, claveTextoContinuar);
                textoContinuar.StringChanged += (valorTraducido) =>
                {
                    if (texto != null)
                    {
                        texto.text = valorTraducido;
                    }
                };

                if (Input.anyKey)
                {
                    operacion.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
