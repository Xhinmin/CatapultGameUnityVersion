using UnityEngine;
using System.Collections;
//�~�M���ڶ]N*N�� //�ݭn�ץ�
/// <summary>
/// �]�wMoveTo�ʵe�ĪG�ܼ�
/// �PRectTo���P���O�AMoveTo�O�����@�Ӳ����ܶq
/// * �� Layout �ϥ� �P Texture2D�BLable �P�@�h
/// * �� Parent���� Disable �i�HĲ�o �P�h���� OnDisable()
/// </summary>
public class LayoutScaleTo : MonoBehaviour
{
    public MUI_Enum.EffectStruct _effectStruct;
    public MUI_Enum.StopEffectStruct _stopEffectStruct;


    //���ʦV�q
    public Vector2 scaleV2;
    //���ʦV�q
    //public Vector2 rect;
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
    private Rect newRect;

    //�O�_�L��TimeScale
    private bool ignoretimescale;

    // Use this for initialization
    void Start()
    {



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
    /// �P�_����O�_��UI����
    /// </summary>
    /// <param name="Object">����</param>
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