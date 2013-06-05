//************************************
// key2Label 關鍵字找值輸出成Lable
// * 使用PlayerPrefs
//****************************

using UnityEngine;
using System.Collections;

public class keyToLabel : MonoBehaviour
{
    //解析度 - 依據1280為基準
    public int Resolution = 1280;

    //視窗大小
    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);

    //介面皮膚
    public GUISkin guiSkin;

    //位置與大小
    public Rect rect;

    //角度
    public int angle;

    //倍率
    public Vector2 scale = new Vector2(1, 1);

    //文字
    public string Text = "Type Text here";

    //文字大小
    public int FontSize = 10;
    
    //文字顏色
    public Color TextColor = Color.white;

    //文字對準方式
    public TextAnchor Alignment;
    
    //介面深度 - 正值越前面
    public int depth;

    /// 文字形式
    public MUI_Enum.TextType textType = MUI_Enum.TextType.INT;

    //用字串當作金鑰來取得資料
    public string Key;


    //備份資訊 (BackUp)
    private Rect _rect_backup;
    private Color _textColor_backup;
    private int _fontSize_backup;


    // Use this for initialization
    void Start()
    {
        if (!guiSkin) Debug.LogWarning(this.name + "-guiSkin" + "-Unset");
        if (FontSize == 0) Debug.LogWarning(this.name + "-FontSize" + "-Unset");
        
        //Set Backup
        _rect_backup = rect;
        _textColor_backup = TextColor;
        _fontSize_backup = FontSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (angle >= 360 || angle <= -360)
            angle = 0;
    }

    void OnGUI()
    {
        if (guiSkin)
            GUI.skin = this.guiSkin;

        Rect _rect = new Rect(rect.x * _ScreenSize.x
                        , rect.y * _ScreenSize.y
                        , rect.width * _ScreenSize.x
                        , rect.height * _ScreenSize.y);

        GUI.skin.label.fontSize = (int)((_ScreenSize.x / Resolution) * FontSize);
        GUI.skin.label.normal.textColor = TextColor;
        GUI.skin.label.alignment = Alignment;
        GUI.depth = depth;
        GUIUtility.RotateAroundPivot(angle, new Vector2(_rect.x + _rect.width / 2, _rect.y + _rect.height / 2));
        GUIUtility.ScaleAroundPivot(scale, new Vector2(_rect.x + _rect.width / 2, _rect.y + _rect.height / 2));



        switch (textType)
        {
            case MUI_Enum.TextType.INT:
                Text = PlayerPrefs.GetInt(Key).ToString();
                break;
            case MUI_Enum.TextType.FLOAT:
                Text = PlayerPrefs.GetFloat(Key).ToString();
                break;
            case MUI_Enum.TextType.STRING:
                Text = PlayerPrefs.GetString(Key).ToString();
                break;
        }
        GUI.Label(_rect, Text);


        
    }




    void Init()
    {

    }


    #region #特效系統

    /// <summary>
    /// 製造Rect動畫效果 (Create)
    /// Name - RectTo
    /// </summary>
    /// <param name="effect">特效結構</param>
    void RectTo(MUI_Enum.EffectStruct effect)
    {

        iTween.ValueTo(gameObject, iTween.Hash(
            "from", rect,
            "to", effect.rect,
            "delay", effect.delay,
            "time", effect.time,
            "easetype", effect.easeType.ToString(),
            "onupdate", "updateRect",
             "loopType", effect.looptype.ToString(),
             "name", "RectTo"));
    }

    /// <summary>
    /// 製造Color動畫效果 (Create)
    /// Name - RectTo
    /// </summary>
    /// <param name="effect">特效結構</param>
    void ColorTo(MUI_Enum.EffectStruct effect)
    {
        iTween.ValueTo(gameObject, iTween.Hash(
           "from", TextColor,
           "to", effect.color,
           "delay", effect.delay,
           "time", effect.time,
           "easetype", effect.easeType.ToString(),
           "onupdate", "updateColor",
           "loopType", effect.looptype.ToString(),
           "name", "ColorTo"));
        

    }

    /// <summary>
    /// 製造FontSize動畫效果 (Create)
    /// Name - RectTo
    /// </summary>
    /// <param name="effect">特效結構</param>
    void FontSizeTo(MUI_Enum.EffectStruct effect)
    {
        iTween.ValueTo(gameObject, iTween.Hash(
           "from", FontSize,
           "to", effect.fontSize,
           "delay", effect.delay,
           "time", effect.time,
           "easetype", effect.easeType.ToString(),
           "onupdate", "updateFontSize",
           "loopType", effect.looptype.ToString(),
           "name", "FontSizeTo"));

    }


    void StopRectTo()
    {
        rect = _rect_backup;
        iTween.StopByName(this.gameObject, "RectTo");
    }
    void StopColorTo()
    {
        TextColor = _textColor_backup;
        iTween.StopByName(this.gameObject, "ColorTo");
    }

    void StopFontSizeTo()
    {
        FontSize = _fontSize_backup;
        iTween.StopByName(this.gameObject, "FontSizeTo");
    }



    // Update callback for iTween
    void updateRect(Rect input)
    {
        rect = input;
    }
    void updateColor(Color input)
    {
        TextColor = input;
    }
    void updateFontSize(int input)
    {
        FontSize = input;
    }

    #endregion 特效系統
}
