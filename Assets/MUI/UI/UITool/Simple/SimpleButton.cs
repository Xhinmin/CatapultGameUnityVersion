using UnityEngine;
using System.Collections;

/// <summary>
/// ²�����s
/// </summary>
public class SimpleButton : MonoBehaviour {

    //�����j�p
    private Vector2 _ScreenSize;

    //�����ֽ�
    public GUISkin guiSkin;

    //���s��Rectangle
    public Rect ButtonRect;

    //���s�W����r
    public string ButtonText;

    //��r�j�p - �̾�1280�����
    public int FontSize;

    //���s���^�X�A�ϥ�GameObject������Ĳ�o
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

        //�p�G���U���s
        if (GUI.Button(rect, ButtonText))
        {
            GameObject newEvent = (GameObject)Instantiate(Event);
            newEvent.SetActive(true);
           // Destroy(newEvent);
        }
    }

}
