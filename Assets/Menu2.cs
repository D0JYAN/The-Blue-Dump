using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{
    private string ultimaEscenaGuardada;

    private void Start()
    {
        CargarUltimaEscena();
    }

    private void CargarUltimaEscena()
    {
        // Obtener la última escena guardada o "Tutorial" por defecto
        ultimaEscenaGuardada = PlayerPrefs.GetString("EscenaActual", "Tutorial");
        Debug.Log("📌 Última escena guardada después de cargar: " + ultimaEscenaGuardada);
    }

    public void Play()
    {
        Debug.Log("Cargando escena: " + ultimaEscenaGuardada);
        SceneManager.LoadScene(ultimaEscenaGuardada);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
