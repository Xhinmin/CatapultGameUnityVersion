using UnityEngine;
using System.Collections;

/// <summary>
/// ���� - ��J��r��
/// 13/05/05 �~�� UIBase 
/// 13/05/09 �ھ�CenterPosition����ø�s�����I
/// </summary>
public class TextField : UIBase
{
    //��r
    public string Text = "";
    //��r�j�p
    public int FontSize = 10;
    //��r��Ǥ覡
    public TextAnchor Alignment;

    // Use this for initialization
    void Start()
    {
        if (!guiSkin) Debug.LogWarning(this.name + "-guiSkin" + "-Unset");
        if (FontSize == 0) Debug.LogWarning(this.name + "-FontSize" + "-Unset");
        UIBase_Start();
    }

    // Update is called once per frame
    void Update()
    {
        UIBase_Update();
    }



    void OnGUI()
    {
        if (guiSkin)
            GUI.skin = this.guiSkin;

        GUI.skin.textField.fontSize = (int)((_ScreenSize.x / Resolution) * FontSize);
        GUI.color = color;
        GUI.depth = depth;
        GUIUtility.RotateAroundPivot(angle, CenterPosition);
        GUIUtility.ScaleAroundPivot(scale, CenterPosition);

        Rect newRect = new Rect(CenterPosition.x, CenterPosition.y, _rect.width, _rect.height);

        Text = GUI.TextField(newRect, Text);

    }

    /// <summary>
    /// �M���r��
    /// </summary>
    public void Clear()
    {
        Text = "";
    }
}
