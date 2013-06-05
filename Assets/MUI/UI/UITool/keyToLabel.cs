//************************************
// key2Label ����r��ȿ�X��Lable
// * �ϥ�PlayerPrefs
//****************************

using UnityEngine;
using System.Collections;

public class keyToLabel : MonoBehaviour
{
    //�ѪR�� - �̾�1280�����
    public int Resolution = 1280;

    //�����j�p
    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);

    //�����ֽ�
    public GUISkin guiSkin;

    //��m�P�j�p
    public Rect rect;

    //����
    public int angle;

    //���v
    public Vector2 scale = new Vector2(1, 1);

    //��r
    public string Text = "Type Text here";

    //��r�j�p
    public int FontSize = 10;
    
    //��r�C��
    public Color TextColor = Color.white;

    //��r��Ǥ覡
    public TextAnchor Alignment;
    
    //�����`�� - ���ȶV�e��
    public int depth;

    /// ��r�Φ�
    public MUI_Enum.TextType textType = MUI_Enum.TextType.INT;

    //�Φr���@���_�Ө��o���
    public string Key;


    //�ƥ���T (BackUp)
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


    #region #�S�Ĩt��

    /// <summary>
    /// �s�yRect�ʵe�ĪG (Create)
    /// Name - RectTo
    /// </summary>
    /// <param name="effect">�S�ĵ��c</param>
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
    /// �s�yColor�ʵe�ĪG (Create)
    /// Name - RectTo
    /// </summary>
    /// <param name="effect">�S�ĵ��c</param>
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
    /// �s�yFontSize�ʵe�ĪG (Create)
    /// Name - RectTo
    /// </summary>
    /// <param name="effect">�S�ĵ��c</param>
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

    #endregion �S�Ĩt��
}
