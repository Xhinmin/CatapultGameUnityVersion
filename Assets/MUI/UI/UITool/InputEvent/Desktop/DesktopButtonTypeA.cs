using UnityEngine;
using System.Collections;

/// <summary>
/// ·Æ¹««öÁä¦b°»´ú½d³ò¸Ì­±«öÁäªº¯S®Ä
/// </summary>
public class DesktopButtonTypeA : MDesktopButton
{
    //µù¥U«¬Button
    //µù¥Uª¬ºA
    public static bool submit;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //¨ú±o°»´ú½d³ò
        rect = (Rect)(DisplayObject.GetType().GetField("_rect").GetValue(DisplayObject));


        if (rect.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)))
        {
            if (!submit)
            {
                if (Input.GetKey(keyCode))
                {
                    if (EffectObjectWhenPress) EffectObjectWhenPress.SetActive(true);
                    if (EffectObjectWhenRelease) EffectObjectWhenRelease.SetActive(false);
                    pressDown = true;
                    submit = true;
                }
            }

                if (pressDown)
                {
                    if (Input.GetKeyUp(keyCode))
                    {
                        if (Event)
                        {
                            GameObject newGameObject = (GameObject)Instantiate(Event);
                            newGameObject.SetActive(true);
                        }
                        if (EffectObjectWhenPress) EffectObjectWhenPress.SetActive(false);
                        if (EffectObjectWhenRelease) EffectObjectWhenRelease.SetActive(true);
                        submit = false;
                    }
                }
            
        }
        else
        {
            if (pressDown)
            {
                if (Input.GetKeyUp(keyCode))
                {
                    if (EffectObjectWhenPress) EffectObjectWhenPress.SetActive(false);
                    if (EffectObjectWhenRelease) EffectObjectWhenRelease.SetActive(true);
                    pressDown = false;
                    submit = false;
                }
            }
        }
    }
}
