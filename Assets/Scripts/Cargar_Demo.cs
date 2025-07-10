using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cargar_Demo : MonoBehaviour
{
    public static string Pantalla_demo;

    public static void nivel_Carga_demo(string demo)
    {
        Pantalla_demo = demo;
        SceneManager.LoadScene("Pantalla_Carga_demo");
    }
}
