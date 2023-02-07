using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Carga_Nivel 
{
    public static string siguiente_Nivel;

    public static void nivel_Carga(string nombre)
    {
        siguiente_Nivel = nombre;
        SceneManager.LoadScene("Pantalla_Carga");
    }
}
