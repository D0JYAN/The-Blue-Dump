using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer; 

    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta; 
    }

    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }

    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index); 
    }

    public void RegresarMenu()
    {
        SceneManager.LoadScene("NuevoMenu");
    }


}
