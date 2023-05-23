using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AccesibilityLabel : MonoBehaviour
{
    public string accessibilityLabel = "Etiqueta de Accesibilidad";
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = accessibilityLabel;
    }
}
