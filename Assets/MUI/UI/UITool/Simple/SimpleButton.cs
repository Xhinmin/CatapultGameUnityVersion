using UnityEngine;
using System.Collections;

/// <summary>
/// 簡易按鈕
/// </summary>
public class SimpleButton : MonoBehaviour {

    //視窗大小
    private Vector2 _ScreenSize;

    //介面皮膚
    public GUISkin guiSkin;

    //按鈕的Rectangle
    public Rect ButtonRect;

    //按鈕上的文字
    public string ButtonText;

    //文字大小 - 依據1280為基準
    public int FontSize;

    //按鈕的回饋，使用GameObject做物件觸發
    public GameObject Event;

	// Use this for initialization
	void Start () {
        _ScreenSize = new Vector2(Screen.width, Screen.height);
        if (FontSize == 0)      Debug.LogWarning(this.name + "-FontSize" + "-Unset");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (guiSkin)
            GUI.skin = this.guiSkin;

        Rect rect = new Rect(ButtonRect.x * _ScreenSize.x
                        , ButtonRect.y * _ScreenSize.y
                        , ButtonRect.width * _ScreenSize.x
                        , ButtonRect.height * _ScreenSize.y);

        GUI.skin.button.fontSize = (int)((_ScreenSize.x / 1280) * FontSize);

        //如果按下按鈕
        if (GUI.Button(rect, ButtonText))
        {
            GameObject newEvent = (GameObject)Instantiate(Event);
            newEvent.SetActive(true);
           // Destroy(newEvent);
        }
    }

}
