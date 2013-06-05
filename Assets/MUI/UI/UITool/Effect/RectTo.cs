using UnityEngine;
using System.Collections;

/// <summary>
/// �]�wRectTo�ʵe�ĪG�ܼ�
/// �ثe�H�o���D ��L�C�C�ק�
/// �|�ݸѨM ResetWhenEffectDone ����ƻP��ڹB���Ƥ��@�P
/// </summary>
public class RectTo : MonoBehaviour
{
    public MUI_Enum.EffectStruct _effectStruct;
    public MUI_Enum.StopEffectStruct _stopEffectStruct;

    //��m�P�j�p
    public Rect rect;
    //�C���ܤ�
    //public Color color;
    //��j���v
    //public Vector2 scale;
    //����ɶ�
    public float time;
    //����ɶ�
    public float delay;
    //Ease�覡
    public MUI_Enum.EaseType easeType;
    //�`���覡
    public MUI_Enum.loopType looptype;

    //�S�Ķ}�l����ɶ�
    public float EffectStartDelay;

    //����QDisable�ɬO�_�^��쥻���A
    public MUI_Enum.ResetWhenDisable _resetWhenDisable;
    //�S�ĵ����� �O�_ �^��쥻���A
    public MUI_Enum.ResetWhenEffectDone _resetWhenEffectDone;
    //�S�ĵ����� �O�_ �^��쥻���A �� �ɶ������q
    public float ResetWhenEffectDone_TimeOffset;
    //�S�ĵ����� ����Disable
    public MUI_Enum.DisableWhenEffectDone _disableWhenEffectDone;

    //�O�_�L��TimeScale
    private bool ignoretimescale;


    private bool EffectDone;

    public GameObject link;
    void Update()
    {
        if(EffectDone)
            if (this.transform.parent.GetComponent<iTween>().percentage >= 1)
            {
                if (_resetWhenEffectDone == MUI_Enum.ResetWhenEffectDone.True)
                    ResetOrDefine();
                if (_disableWhenEffectDone == MUI_Enum.DisableWhenEffectDone.True)
                {
                    ResetOrDefine();
                    this.gameObject.SetActive(false);
                }
                EffectDone = false;
                link.SetActive(true);
            }
    }
    //���~�ץ��P�קK
    void BugFix()
    {
        //* �ھ� Issue 72 
        //ITween�ϥ�delay��IgnoreTimeScale�L�� �A �ҥH��delay�j��0 �|�ϥγQTimeScale�v�T���禡 
        //https://code.google.com/p/itween/issues/detail?id=72

        if (delay > 0)
            ignoretimescale = false;
        else
            ignoretimescale = true;
    }
    void OnEnable()
    {
        //���~�ץ�
        BugFix();
        //�إ߯S�Ĩ�{
        SetEffectStartCoroutine();
        //�إ߷�S�ĵ�����{
        SetEffectDoneCoroutine();
    }

    void OnDisable()
    {
        if (_resetWhenDisable == MUI_Enum.ResetWhenDisable.True)
            ResetOrDefine();
    }

    /// <summary>
    /// �S�Ķ}�l��{
    /// </summary>
    void SetEffectStartCoroutine()
    {
        StartCoroutine(WhenEffectStart(this.EffectStartDelay));
    }


    /// <summary>
    /// �S�ĵ�����{
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

        _effectStruct.rect = this.rect;
        _effectStruct.time = this.time;
        _effectStruct.delay = this.delay;
        _effectStruct.easeType = this.easeType;
        _effectStruct.looptype = this.looptype;
        _effectStruct.ignoretimescale = this.ignoretimescale;
        _effectStruct.hashcode = string.Format("{0:X}", this.GetHashCode());

        this.transform.parent.SendMessage("RectTo", _effectStruct, SendMessageOptions.DontRequireReceiver);

    }

    IEnumerator WhenEffectDone(float delay)
    {
        yield return new WaitForSeconds(delay);
        EffectDone = true;


    }

    void ResetOrDefine()
    {

        _stopEffectStruct.isReset = this.isReset();
        _stopEffectStruct.reDefinePreviousState = this.isReDefinePreviousState();
        _stopEffectStruct.hashcode = string.Format("{0:X}", this.GetHashCode());
        this.transform.parent.SendMessage("StopRectTo", _stopEffectStruct, SendMessageOptions.DontRequireReceiver);

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