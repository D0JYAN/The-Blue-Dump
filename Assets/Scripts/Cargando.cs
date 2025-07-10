using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;


public class Cargando : MonoBehaviour
{
    public Text texto;
    public string claveTextoContinuar = "presione"; // Debe coincidir con la clave en la tabla
    public string nombreTabla = "Opciones"; // Nombre de tu tabla

    private void Start()
    {
        string nivel_A_Cargar = Carga_Nivel.siguiente_Nivel;

        if (string.IsNullOrEmpty(nivel_A_Cargar))
        {
            texto.text = "Error: Escena inválida.";
            return;
        }

        StartCoroutine(Iniciar_Carga(nivel_A_Cargar));
    }

    IEnumerator Iniciar_Carga(string nivel)
    {
        yield return new WaitForSeconds(2f);
        AsyncOperation Operacion = SceneManager.LoadSceneAsync(nivel);
        Operacion.allowSceneActivation = false;

        while (!Operacion.isDone)
        {
            if (Operacion.progress >= 0.9f)
            {
                // 🔽 Aquí cargamos el texto traducido
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
                    Operacion.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}

