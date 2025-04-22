using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorDropDown : MonoBehaviour
{
    public TMP_Dropdown colorModeDropdown; // Asignar desde el Inspector
    public ColorBlindFilter filterScript; // Asignar desde el Inspector

    void Start()
    {
        colorModeDropdown.onValueChanged.AddListener(OnDropdownChanged);

        int savedIndex = PlayerPrefs.GetInt("ColorBlindMode", 0); // 0 es el valor por defecto (Normal)
        colorModeDropdown.value = savedIndex;
        filterScript.mode = (ColorBlindMode)savedIndex;
    }

    void OnDropdownChanged(int index)
    {
        filterScript.mode = (ColorBlindMode)index;

        PlayerPrefs.SetInt("ColorBlindMode", index);
        PlayerPrefs.Save();
    }
}
