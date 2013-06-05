using UnityEngine;
using System.Collections;

/// <summary>
/// 平板在偵測範圍裡面按鍵的特效
/// </summary>
public class PlatformButtonTypeC : MonoBehaviour
{

    public Object DisplayObject;
    private Rect rect;

    public GameObject EffectObjectWhenPress;
    public GameObject EffectObjectWhenRelease;

    public GameObject Event;

    public KeyCode keyCode;

    private bool pressDown;

    private float intervalTime;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //取得偵測範圍
        rect = (Rect)(DisplayObject.GetType().GetField("_rect").GetValue(DisplayObject));


        if (rect.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)))
        {
            if (Input.GetKey(keyCode))
            {
                if (EffectObjectWhenPress)
                    EffectObjectWhenPress.SetActive(true);
                if (EffectObjectWhenRelease)
                    EffectObjectWhenRelease.SetActive(false);
                pressDown = true;
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
                    if (EffectObjectWhenPress)
                        EffectObjectWhenPress.SetActive(false);
                    if (EffectObjectWhenRelease)
                        EffectObjectWhenRelease.SetActive(true);



                }
            }
        }
        else
        {

            if (EffectObjectWhenPress)
                EffectObjectWhenPress.SetActive(false);

            if (EffectObjectWhenRelease)
                EffectObjectWhenRelease.SetActive(true);

            pressDown = false;

            

        }

    }
}
