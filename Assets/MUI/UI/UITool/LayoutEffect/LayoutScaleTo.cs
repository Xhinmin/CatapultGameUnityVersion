using UnityEngine;
using System.Collections;
//居然給我跑N*N次 //需要修正
/// <summary>
/// 設定MoveTo動畫效果變數
/// 與RectTo不同的是，MoveTo是給予一個移動變量
/// * 供 Layout 使用 與 Texture2D、Lable 同一層
/// * 對 Parent物件 Disable 可以觸發 同層物件的 OnDisable()
/// </summary>
public class LayoutScaleTo : MonoBehaviour
{
    public MUI_Enum.EffectStruct _effectStruct;
    public MUI_Enum.StopEffectStruct _stopEffectStruct;


    //移動向量
    public Vector2 scaleV2;
    //移動向量
    //public Vector2 rect;
    //顏色變化
    //public Color color;
    //放大倍率
    //public Vector2 scale;
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
    private Rect newRect;

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
        foreach (Transform child in this.transform.parent.transform)
        {
            if (ChkObjectisUI(child))
            {
                if (_resetWhenDisable == MUI_Enum.ResetWhenDisable.True)
                    ResetOrDefine();
            }
        }
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
        foreach (Transform child in this.transform.parent)
        {
            if (ChkObjectisUI(child))
            {
                yield return new WaitForSeconds(delay);
                _effectStruct.scale = scaleV2;
                _effectStruct.time = this.time;
                _effectStruct.delay = this.delay;
                _effectStruct.easeType = this.easeType;
                _effectStruct.looptype = this.looptype;
                _effectStruct.ignoretimescale = this.ignoretimescale;
                _effectStruct.hashcode = string.Format("{0:X}", this.GetHashCode());

                child.SendMessage("ScaleTo", _effectStruct, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    IEnumerator WhenEffectDone(float delay)
    {
        yield return new WaitForSeconds(delay);
        foreach (Transform child in this.transform.parent.transform)
        {
            if (ChkObjectisUI(child))
            {
                if (_resetWhenEffectDone == MUI_Enum.ResetWhenEffectDone.True)
                    ResetOrDefine();
                if (_disableWhenEffectDone == MUI_Enum.DisableWhenEffectDone.True)
                {
                    ResetOrDefine();
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    void ResetOrDefine()
    {
        foreach (Transform child in this.transform.parent.transform)
        {
            if (ChkObjectisUI(child))
            {
                _stopEffectStruct.isReset = this.isReset();
                _stopEffectStruct.reDefinePreviousState = this.isReDefinePreviousState();
                _stopEffectStruct.hashcode = string.Format("{0:X}", this.GetHashCode());
                child.SendMessage("StopScaleTo", _stopEffectStruct, SendMessageOptions.DontRequireReceiver);
            }
        }
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

    /// <summary>
    /// 判斷物件是否為UI物件
    /// </summary>
    /// <param name="Object">物件</param>
    /// <returns>T/F</returns>
    bool ChkObjectisUI(Transform Object)
    {
        if (Object.GetComponent<Texture_2D>() ||
            Object.GetComponent<Label>())
            return true;
        else
            return false;
    }

}