using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;


public class MenuGameOver : MonoBehaviour
{
    [SerializeField] public GameObject menuGameOver;

    private Movimiento_Buzo movimiento;

    public Puntaje scriptPuntaje;

    private void Start()
    {
        movimiento = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento_Buzo>();
        movimiento.muerteBuzo += activarMenu;
    }

    private void activarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);           // Mostrar el menú Game Over
        ActualizarRanking();                    // Asegúrate de guardar el puntaje actual en el ranking

        TextMeshProUGUI textoRanking = this.transform.Find("MenuGameOver").Find("Ranking").GetComponent<TextMeshProUGUI>();

        float top1 = PlayerPrefs.GetFloat("top1", 0);
        float top2 = PlayerPrefs.GetFloat("top2", 0);
        float top3 = PlayerPrefs.GetFloat("top3", 0);

        textoRanking.text = "\n";
        textoRanking.text += "1. " + top1 + "\n";
        textoRanking.text += "2. " + top2 + "\n";
        textoRanking.text += "3. " + top3;
    }

    public void reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void salir()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Detiene la ejecución en el editor de Unity
        #else
        Application.Quit(); // Sale de la aplicación en el dispositivo
        #endif
    }

    private void ActualizarRanking()
    {
        float nuevoPuntaje = PlayerPrefs.GetFloat("Puntos", 0);

        float top1 = PlayerPrefs.GetFloat("top1", 0);
        float top2 = PlayerPrefs.GetFloat("top2", 0);
        float top3 = PlayerPrefs.GetFloat("top3", 0);

        if (nuevoPuntaje > top1)
        {
            PlayerPrefs.SetFloat("top3", top2);
            PlayerPrefs.SetFloat("top2", top1);
            PlayerPrefs.SetFloat("top1", nuevoPuntaje);
        }
        else if (nuevoPuntaje > top2)
        {
            PlayerPrefs.SetFloat("top3", top2);
            PlayerPrefs.SetFloat("top2", nuevoPuntaje);
        }
        else if (nuevoPuntaje > top3)
        {
            PlayerPrefs.SetFloat("top3", nuevoPuntaje);
        }

        PlayerPrefs.Save();
    }

}