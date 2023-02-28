using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cargando : MonoBehaviour
{
    public Text texto;

    private void Start()
    {
        string nivel_A_Cargar = Carga_Nivel.siguiente_Nivel;
        StartCoroutine(Iniciar_Carga(nivel_A_Cargar));
    }

    IEnumerator Iniciar_Carga(string nivel)
    {
        yield return new WaitForSeconds(2f);
        AsyncOperation Operacion = SceneManager.LoadSceneAsync(nivel);
        Operacion.allowSceneActivation = false;

        while(!Operacion.isDone)
        {
            if(Operacion.progress >= 0.9f)
            {
                texto.text = "Presiona la pantalla para continuar.";
                if(Input.anyKey)
                {
                    Operacion.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
