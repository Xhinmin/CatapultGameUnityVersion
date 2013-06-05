using UnityEngine;
using System.Collections;

/// <summary>
/// 介面 - 輸入文字框
/// 13/05/05 繼承 UIBase 
/// 13/05/09 根據CenterPosition給予繪製中心點
/// </summary>
public class TextField : UIBase
{
    //文字
    public string Text = "";
    //文字大小
    public int FontSize = 10;
    //文字對準方式
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
    /// 清除字串
    /// </summary>
    public void Clear()
    {
        Text = "";
    }
}
