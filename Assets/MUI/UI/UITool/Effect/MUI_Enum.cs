using UnityEngine;
using System.Collections;

public class MUI_Enum : MonoBehaviour
{
    //介面型態
    public enum MUIType { Lable, Texture2D};
    //文字型態
    public enum TextType { INT, FLOAT, STRING };
    //各種Ease的方式
    public enum EaseType
    {
        easeInQuad,
        easeOutQuad,
        easeInOutQuad,
        easeInCubic,
        easeOutCubic,
        easeInOutCubic,
        easeInQuart,
        easeOutQuart,
        easeInOutQuart,
        easeInQuint,
        easeOutQuint,
        easeInOutQuint,
        easeInSine,
        easeOutSine,
        easeInOutSine,
        easeInExpo,
        easeOutExpo,
        easeInOutExpo,
        easeInCirc,
        easeOutCirc,
        easeInOutCirc,
        linear,
        spring,
        /* GFX47 MOD START */
        //bounce,
        easeInBounce,
        easeOutBounce,
        easeInOutBounce,
        /* GFX47 MOD END */
        easeInBack,
        easeOutBack,
        easeInOutBack,
        /* GFX47 MOD START */
        //elastic,
        easeInElastic,
        easeOutElastic,
        easeInOutElastic,
        /* GFX47 MOD END */
        punch
    }
    //Itween的循環方式
    public enum loopType { none, pingPong, loop }
    //準心動作模式
    public enum CursorActionType { KeyDown, KeyUp, KeyDownAndUp, DoubleKeyDown }

    //特效結束時 是否 回到原本狀態 模式
    public enum ResetWhenEffectDone { False, True, True_ReDefinePreviousState }
    //物件被Disable時是否回到原本狀態 模式
    public enum ResetWhenDisable { False, True, True_ReDefinePreviousState }
    //特效結束時 物件Disable 模式
    public enum DisableWhenEffectDone { False, True }

    // 特效變數 structure
    public struct EffectStruct
    {
        //位置與大小
        public Rect rect;

        //文字大小
        public int fontSize;

        //文字顏色
        public Color color;

        //放大倍率
        public Vector2 scale;

        //持續時間
        public float time;

        //延遲時間
        public float delay;

        //循環方式
        public loopType looptype;

        //漸變函式
        public EaseType easeType;

        //是否受TimeScale影響
        public bool ignoretimescale;

        //HashCode - Hex
        public string hashcode;

    }

    /// <summary>
    /// 停止特效Struct
    /// </summary>
    public struct StopEffectStruct
    {
        //是否重置到開始狀態
        public bool isReset;

        //是否更新重置資訊
        public bool reDefinePreviousState;

        //HashCode - Hex
        public string hashcode;

        //位置與大小
        public Rect rect;

        //文字大小
        public int fontSize;

        //文字顏色
        public Color color;

        //放大倍率
        public Vector2 scale;
    }


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


    }
}
