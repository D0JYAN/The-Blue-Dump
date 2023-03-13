using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;

    private Movimiento_Buzo movimiento;

    private void Start()
    {
        movimiento = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento_Buzo>();
        movimiento.muerteBuzo += activarMenu;
    }

    private void activarMenu(object sender, EventArgs e)
    {
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
        UnityEditor.EditorApplication.isPlaying = false;//detiene la ejecucion del juego en el editor Unity
        Application.Quit();
    }
}
