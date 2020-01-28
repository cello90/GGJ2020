using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HexToColorConverter {

    static public Color ReturnColorFromHex(string hex) {
        Color color = new Color();
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }

}