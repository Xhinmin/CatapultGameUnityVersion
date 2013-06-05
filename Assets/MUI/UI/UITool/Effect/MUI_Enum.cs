using UnityEngine;
using System.Collections;

public class MUI_Enum : MonoBehaviour
{
    //�������A
    public enum MUIType { Lable, Texture2D};
    //��r���A
    public enum TextType { INT, FLOAT, STRING };
    //�U��Ease���覡
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
    //Itween���`���覡
    public enum loopType { none, pingPong, loop }
    //�Ǥ߰ʧ@�Ҧ�
    public enum CursorActionType { KeyDown, KeyUp, KeyDownAndUp, DoubleKeyDown }

    //�S�ĵ����� �O�_ �^��쥻���A �Ҧ�
    public enum ResetWhenEffectDone { False, True, True_ReDefinePreviousState }
    //����QDisable�ɬO�_�^��쥻���A �Ҧ�
    public enum ResetWhenDisable { False, True, True_ReDefinePreviousState }
    //�S�ĵ����� ����Disable �Ҧ�
    public enum DisableWhenEffectDone { False, True }

    // �S���ܼ� structure
    public struct EffectStruct
    {
        //��m�P�j�p
        public Rect rect;

        //��r�j�p
        public int fontSize;

        //��r�C��
        public Color color;

        //��j���v
        public Vector2 scale;

        //����ɶ�
        public float time;

        //����ɶ�
        public float delay;

        //�`���覡
        public loopType looptype;

        //���ܨ禡
        public EaseType easeType;

        //�O�_��TimeScale�v�T
        public bool ignoretimescale;

        //HashCode - Hex
        public string hashcode;

    }

    /// <summary>
    /// ����S��Struct
    /// </summary>
    public struct StopEffectStruct
    {
        //�O�_���m��}�l���A
        public bool isReset;

        //�O�_��s���m��T
        public bool reDefinePreviousState;

        //HashCode - Hex
        public string hashcode;

        //��m�P�j�p
        public Rect rect;

        //��r�j�p
        public int fontSize;

        //��r�C��
        public Color color;

        //��j���v
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
