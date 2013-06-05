using UnityEngine;
using System.Collections;

/// <summary>
/// ���� - ��ܹϤ�
/// </summary>
public class Texture_2D : UIBase
{
    //�Ϥ��Y��覡
    public ScaleMode scaleMode;
    //Texture
    public Texture Texture2d;

    // Use this for initialization
    void Start()
    {
        UIBase_Start();
        LogWarning();
    }

    void LogWarning()
    {
        if (!Texture2d) Debug.LogWarning(this.name + "-Texture2d" + "-Unset");
    }

    // Update is called once per frame
    void Update()
    {
        //UIBase auto update
        UIBase_Update();
    }

    void OnGUI()
    {
        GUI.color = color;
        GUI.depth = depth;

        GUIUtility.RotateAroundPivot(angle, CenterPosition);

        if (scale != Vector2.zero)
            GUIUtility.ScaleAroundPivot(scale, CenterPosition);

        if (Texture2d)
        {
            GUI.BeginGroup(new Rect(_rect.x, _rect.y, _rect.width * offset.x, _rect.height * offset.y));
            {
                GUI.DrawTexture(new Rect(0, 0, _rect.width, _rect.height), Texture2d, scaleMode);
            }
            GUI.EndGroup();
        }
    }


}
