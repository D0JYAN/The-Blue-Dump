using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class IdiomaManager : MonoBehaviour
{
    private static bool idiomaAplicado = false;

    void Awake()
    {
        if (!idiomaAplicado)
        {
            int idiomaGuardado = PlayerPrefs.GetInt("idioma", 0); // español por defecto
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[idiomaGuardado];
            idiomaAplicado = true;
        }
    }
}

