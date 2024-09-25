using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class CambioIdioma : MonoBehaviour
{

   private int idioma;

    private void Start()
    {
        CargarDatos();
        Invoke(nameof(CargaLocal), 0.1f);
    }

    private void CargaLocal()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[idioma];
    }

   public void CambiarIdioma(int indiceIdioma)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[indiceIdioma];
        idioma = indiceIdioma;
        GuardarDatos();
    }

    private void GuardarDatos()
    {
        PlayerPrefs.SetInt("idioma", idioma);
    }

    private void CargarDatos()
    {
        idioma = PlayerPrefs.GetInt("idioma");
    }

}
