using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingTextControllerEssence : MonoBehaviour
{

    public GameObject popupText;
    private static GameObject canvas;
    public static string textt;

    public static void Initialize()
    {
        canvas = GameObject.Find("WorldCanvas");
    }

    public void CreateFloatingText(string text, Transform location)
    {
        textt = text;
        GameObject popup = Instantiate(popupText) as GameObject;
        Vector2 screenPosition = new Vector2(location.position.x, location.position.y + 1);
        popup.transform.SetParent(canvas.transform, false);
        popup.transform.position = screenPosition;
    }
}
