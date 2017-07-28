using UnityEngine;
using UnityEngine.UI;


public static class ExtensionMethods
{
    public static void ChangeButtonColor(this Button button, Color color)
    {
        var colors = button.colors;
        colors.normalColor = color;
        button.colors = colors;
    }
}

