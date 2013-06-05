using UnityEngine;
using System.Collections;

/// <summary>
/// 設定ScaleTo動畫效果變數
/// </summary>
public class ScaleTo : MonoBehaviour
{
    public MUI_Enum.EffectStruct _effectStruct;
    public MUI_Enum.StopEffectStruct _stopEffectStruct;

    //位置與大小
    //public Rect rect;
    //顏色變化
    //public Color color;
    //放大倍率
    public Vector2 scale = new Vector2(1, 1);
    //持續時間
    public float time;
    //延遲時間
    public float delay;
    //Ease方式
    public MUI_Enum.EaseType easeType;
    //循環方式
    public MUI_Enum.loopType looptype;

    //特效開始延遲時間
    public float EffectStartDelay;

    //物件被Disable時是否回到原本狀態
    public MUI_Enum.ResetWhenDisable _resetWhenDisable;
    //特效結束時 是否 回到原本狀態
    public MUI_Enum.ResetWhenEffectDone _resetWhenEffectDone;
    //特效結束時 是否 回到原本狀態 的 時間偏移量
    public float ResetWhenEffectDone_TimeOffset;
    //特效結束時 物件Disable
    public MUI_Enum.DisableWhenEffectDone _disableWhenEffectDone;

    //是否無視TimeScale
    private bool ignoretimescale;

    // Use this for initialization
    void Start()
    {

    }

    //錯誤修正與避免
    void BugFix()
    {
        //* 根據 Issue 72 
        //ITween使用delay時IgnoreTimeScale無效 ， 所以當delay大於0 會使用被TimeScale影響的函式 
        //https://code.google.com/p/itween/issues/detail?id=72

        if (delay > 0)
            ignoretimescale = false;
        else
            ignoretimescale = true;
    }
    void OnEnable()
    {
        //錯誤修正
        BugFix();
        //建立特效協程
        SetEffectStartCoroutine();
        //建立當特效結束協程
        SetEffectDoneCoroutine();
    }

    void OnDisable()
    {
        if (_resetWhenDisable == MUI_Enum.ResetWhenDisable.True)
            ResetOrDefine();
    }

    /// <summary>
    /// 特效開始協程
    /// </summary>
    void SetEffectStartCoroutine()
    {
        StartCoroutine(WhenEffectStart(this.EffectStartDelay));
    }


    /// <summary>
    /// 特效結束協程
    /// </summary>
    void SetEffectDoneCoroutine()
    {
        float delaytime = time + delay;
        if (looptype == MUI_Enum.loopType.pingPong) delaytime *= 2;
        StartCoroutine(WhenEffectDone(delaytime + ResetWhenEffectDone_TimeOffset + this.EffectStartDelay));
    }


    IEnumerator WhenEffectStart(float delay)
    {
        yield return new WaitForSeconds(delay);

        _effectStruct.scale = this.scale;
        _effectStruct.time = this.time;
        _effectStruct.delay = this.delay;
        _effectStruct.easeType = this.easeType;
        _effectStruct.looptype = this.looptype;
        _effectStruct.ignoretimescale = this.ignoretimescale;
        _effectStruct.hashcode = string.Format("{0:X}", this.GetHashCode());

        this.transform.parent.SendMessage("ScaleTo", _effectStruct, SendMessageOptions.DontRequireReceiver);

    }

    IEnumerator WhenEffectDone(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (_resetWhenEffectDone == MUI_Enum.ResetWhenEffectDone.True)
            ResetOrDefine();
        if (_disableWhenEffectDone == MUI_Enum.DisableWhenEffectDone.True)
        {
            ResetOrDefine();
            this.gameObject.SetActive(false);
        }

    }

    void ResetOrDefine()
    {

        _stopEffectStruct.isReset = this.isReset();
        _stopEffectStruct.reDefinePreviousState = this.isReDefinePreviousState();
        _stopEffectStruct.hashcode = string.Format("{0:X}", this.GetHashCode());
        this.transform.parent.SendMessage("StopScaleTo", _stopEffectStruct, SendMessageOptions.DontRequireReceiver);

    }



    bool isReset()
    {
        if (_resetWhenEffectDone >= MUI_Enum.ResetWhenEffectDone.True ||
            _resetWhenDisable >= MUI_Enum.ResetWhenDisable.True)
            return true;
        else
            return false;
    }

    bool isReDefinePreviousState()
    {
        if (_resetWhenEffectDone == MUI_Enum.ResetWhenEffectDone.True_ReDefinePreviousState ||
            _resetWhenDisable == MUI_Enum.ResetWhenDisable.True_ReDefinePreviousState)
            return true;
        else
            return false;
    }




}