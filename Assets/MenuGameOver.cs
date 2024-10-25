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
        this.ActualizarRanking();
        this.transform.Find("MenuGameOver").transform.Find("Ranking").GetComponent<TextMeshProUGUI>().text = "";
        for (int i = 1; i < 3; i++)
        {
            string textoAnterior = this.transform.Find("MenuGameOver").transform.Find("Ranking").GetComponent<TextMeshProUGUI>().text;
            this.transform.Find("MenuGameOver").transform.Find("Ranking").GetComponent<TextMeshProUGUI>().text = textoAnterior + "\n" + i + ". " + PlayerPrefs.GetInt("top" + i, 0).ToString();
        }
        menuGameOver.SetActive(true);

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
        UnityEditor.EditorApplication.isPlaying = false; // Detiene la ejecuci�n en el editor de Unity
        #else
        Application.Quit(); // Sale de la aplicaci�n en el dispositivo
        #endif
    }

    private void ActualizarRanking()
    {
        if (this.scriptPuntaje == null)
        {
            Debug.LogError("scriptPuntaje es null");
            return;
        }

        float posicionComparada = 1;
        bool seguirBuscando = true;

        while (posicionComparada <= 3 && seguirBuscando)
        {
            if (PlayerPrefs.GetFloat("top" + posicionComparada, -1) < this.scriptPuntaje.Puntos)
            {
                PlayerPrefs.SetFloat("top" + posicionComparada, this.scriptPuntaje.Puntos);
                seguirBuscando = false;
            }
            posicionComparada++;
        }
    }
}