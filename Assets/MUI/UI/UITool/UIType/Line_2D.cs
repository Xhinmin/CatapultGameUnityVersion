using UnityEngine;
using System.Collections;

/// <summary>
/// 介面 - 繪製 2D 線
/// 13/05/08 建置
/// </summary>
/// * BaseResolution    根據解析度大小重新定義Point數值 (Value 0 to 1)
/// * BasePixel         根據像素大小重新定義Point數值
/// ** 根據 BaseResolution 所算出的結果必須為INT不可為FLOAT
public class Line_2D : MonoBehaviour
{

    public Material m;

    //視窗大小
    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);

    //線的材質
    public Texture2D lineTex;
    public static Texture2D lineTex_static;

    //根據解析度給的Vector數值
    public bool BaseResolution;
    public Vector2 pointStart_BaseResolution;
    public Vector2 pointEnd_BaseResolution;

    //根據Pixel直接給予向量數值
    public Vector2 pointStart_BasePixel;
    public Vector2 pointEnd_BasePixel;

    //AB點的向量
    private Vector2 pointA;
    private Vector2 pointB;

    //鉛筆大小
    public float penSize = 1;

    //顏色
    public Color color = Color.white;

    //介面深度
    public int depth;


    void Awake()
    {
        _ScreenSize = new Vector2(Screen.width, Screen.height);
    }
    // Use this for initialization
    void Start()
    {
        //警告通知
        if (pointStart_BaseResolution != Vector2.zero || pointEnd_BaseResolution != Vector2.zero)
            if (!BaseResolution)
                Debug.LogError("If you want Vectors base on resolution , please set [BaseResolution] TRUE");


    }


    void OnGUI()
    {
        if (BaseResolution)
        {
            pointA.x = (pointStart_BaseResolution.x * _ScreenSize.x);
            pointA.y = (pointStart_BaseResolution.y * _ScreenSize.y);
            pointB.x = (pointEnd_BaseResolution.x * _ScreenSize.x);
            pointB.y = (pointEnd_BaseResolution.y * _ScreenSize.y);
        }
        else
        {
            pointA = pointStart_BasePixel;
            pointB = pointEnd_BasePixel;
        }

        GUI.color = color;
        GUI.depth = depth;
        DrawLine(pointA, pointB, color, penSize);
    }



    // 以 1*1 的 Texture 放大與旋轉並繪出直線
    public void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
    {
        // Save the current GUI matrix, since we're going to make changes to it.
        Matrix4x4 matrix = GUI.matrix;

        // Generate a single pixel texture if it doesn't exist
        if (!lineTex) { lineTex = new Texture2D(1, 1); }

        // Store current GUI color, so we can switch it back later,
        // and set the GUI color to the color parameter
        Color savedColor = GUI.color;
        // GUI.color = color;

        // Determine the angle of the line.
        float angle = Vector3.Angle(pointB - pointA, Vector2.right);

        //get vector2 magnitude
        float magnitude = (pointB - pointA).magnitude;

        //Reset the center position 
        pointA.x = (int)((pointB.x + pointA.x) / 2);
        pointB.x = (int)(pointB.x + pointA.x);

        // Vector3.Angle always returns a positive number.
        // If pointB is above pointA, then angle needs to be negative.
        if (pointA.y > pointB.y) { angle = -angle; }

        // Use ScaleAroundPivot to adjust the size of the line.
        // We could do this when we draw the texture, but by scaling it here we can use
        //  non-integer values for the width and length (such as sub 1 pixel widths).
        // Note that the pivot point is at +.5 from pointA.y, this is so that the width of the line
        //  is centered on the origin at pointA.
        GUIUtility.ScaleAroundPivot(new Vector2(magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));

        // Set the rotation for the line.
        //  The angle was calculated with pointA as the origin.
        GUIUtility.RotateAroundPivot(angle, pointA);

        // Finally, draw the actual line.
        // We're really only drawing a 1x1 texture from pointA.
        // The matrix operations done with ScaleAroundPivot and RotateAroundPivot will make this
        //  render with the proper width, length, and angle.
        GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1, 1), lineTex);

        // We're done.  Restore the GUI matrix and GUI color to whatever they were before.
        GUI.matrix = matrix;
        GUI.color = savedColor;
    }


    public static void Draw(Vector2 pointA, Vector2 pointB, Color color, float width)
    {

        if (!lineTex_static) { lineTex_static = new Texture2D(1, 1); }
        float angle = Vector3.Angle(pointB - pointA, Vector2.right);
        float magnitude = (pointB - pointA).magnitude;
        pointA.x = (pointB.x + pointA.x) / 2;
        pointB.x = pointB.x + pointA.x;
        if (pointA.y > pointB.y) { angle = -angle; }
        GUIUtility.ScaleAroundPivot(new Vector2(magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));
        GUIUtility.RotateAroundPivot(angle, pointA);
        GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1, 1), lineTex_static);
    }
}
