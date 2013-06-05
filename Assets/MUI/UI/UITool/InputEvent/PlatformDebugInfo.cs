using UnityEngine;
using System.Collections;

public class PlatformDebugInfo : MonoBehaviour
{

    public int fontSize;
    void OnGUI()
    {
        GUI.skin.label.fontSize = fontSize;

        GUI.Label(new Rect(0, 0, 500, 50), "TouchCount¡G" + Input.touchCount.ToString());
        GUI.Label(new Rect(0, 60, 500, 50), "Acceleration¡G" + Input.acceleration.ToString());

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).fingerId >= 0)
                GUI.Label(new Rect(0, 100 + fontSize * i, 500, 50), "fingerId" + i.ToString() + "¡G" + Input.GetTouch(i).fingerId.ToString());
        }
        for (int i = Input.touchCount; i < 4; i++)
        {
            GUI.Label(new Rect(0, 100 + fontSize * i, 500, 50), "fingerId" + i.ToString() + "¡G" + "NULL");
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            GUI.Label(new Rect(0, 200 + fontSize * i, 500, 50), "TouchCount" + i.ToString() + "¡G" + Input.GetTouch(i).position.x.ToString() + "   " +
                                                    (Screen.height - Input.GetTouch(i).position.y).ToString());
        }

        for (int i = Input.touchCount; i < 4; i++)
        {
            GUI.Label(new Rect(0, 200 + fontSize * i, 500, 50), "TouchCount" + i.ToString() + "¡G" + "NULL");
        }



    }
}
