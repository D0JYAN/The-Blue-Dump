using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cargando_2 : MonoBehaviour
{
    public Text texto;

    private void Start()
    {
        string nivel_A_Cargar_2 = Carga_Nivel_2.siguiente_Nivel_2;
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
                texto.text = "Presiona una tecla para continuar.";
                if (Input.anyKey)
                {
                    Operacion.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
