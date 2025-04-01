using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Menu2 : MonoBehaviour
{

    private string archivoGuardado;
    private string ultimaEscenaGuardada;

    private void Start()
    {
        archivoGuardado = Application.persistentdataPath + "/datosJuego.json";
        CargarUltimaEscena();
    }

    private void CargarUltimaEscena()
    {
        if (File.Exists(archivoGuardado))
        {
            Debug.Log("📌 Archivo JSON encontrado en: " + archivoGuardado);
            string contenido = File.ReadAllText(archivoGuardado);
            Debug.Log("📌 Contenido del archivo JSON: " + contenido); // Si este mensaje no aparece, el archivo no se está leyendo correctamente

            DatosJuegos datosJuego = JsonUtility.FromJson<DatosJuegos>(contenido);

            if (!string.IsNullOrEmpty(datosJuego.escenaActual))
            {
                ultimaEscenaGuardada = datosJuego.escenaActual;
            }
            else
            {
                ultimaEscenaGuardada = "Tutorial";
            }
        }
        else
        {
            Debug.LogWarning("⚠️ No se encontró el archivo de guardado.");
            ultimaEscenaGuardada = "Tutorial";
        }

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
}
