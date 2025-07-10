using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;


public class Cargando_2 : MonoBehaviour
{
    public Text texto;
    public string claveTextoContinuar = "presione"; // Debe coincidir con la clave en la tabla
    public string nombreTabla = "Opciones"; // Nombre de tu tabla

    private void Start()
    {
        string nivel_A_Cargar_2 = Carga_Nivel_2.siguiente_Nivel_2;

        if (string.IsNullOrEmpty(nivel_A_Cargar_2))
        {
            texto.text = "Error: Escena inválida.";
            return;
        }

        StartCoroutine(Iniciar_Carga_2(nivel_A_Cargar_2));
    }

    IEnumerator Iniciar_Carga_2(string nivel_2)
    {
        yield return new WaitForSeconds(2f);
        AsyncOperation Operacion = SceneManager.LoadSceneAsync(nivel_2);
        Operacion.allowSceneActivation = false;

        while (!Operacion.isDone)
        {
            if (Operacion.progress >= 0.9f)
            {
                // Traducción dinámica del texto al 90% de progreso
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