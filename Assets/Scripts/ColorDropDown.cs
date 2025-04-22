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
    }

    void OnDropdownChanged(int index)
    {
        // Asegúrate de que el orden de las opciones en el Dropdown coincida con el orden del enum
        filterScript.mode = (ColorBlindMode)index;
    }
}
