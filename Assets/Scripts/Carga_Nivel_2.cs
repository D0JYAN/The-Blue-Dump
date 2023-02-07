using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Carga_Nivel_2
{
    public static string siguiente_Nivel_2;

    public static void nivel_Carga_2(string nombre_2)
    {
        siguiente_Nivel_2 = nombre_2;
        SceneManager.LoadScene("Pantalla_Carga_2");
    }
}
