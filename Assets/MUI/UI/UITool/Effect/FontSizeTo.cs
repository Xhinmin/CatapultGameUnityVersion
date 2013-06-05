using UnityEngine;
using System.Collections;

public class FontSizeTo : MonoBehaviour
{
    public MUI_Enum.EffectStruct _effectStruct;

    //位置與大小
    //public Rect rect;
    //持續時間
    public float time;
    //是否循環
    public MUI_Enum.loopType looptype;
    //顏色變化
    //public Color color;
    //延遲時間
    public float delay;


    public MUI_Enum.EaseType easeType;


    public int fontSize;

    public bool isRecover;
    public float RecoverTime;
    // Use this for initialization
    void Start()
    {
        _effectStruct.time = this.time;
        _effectStruct.delay = this.delay;
        _effectStruct.looptype = this.looptype;
        _effectStruct.fontSize = this.fontSize;
        _effectStruct.easeType = this.easeType;
        this.SendMessage("FontSizeTo", _effectStruct, SendMessageOptions.DontRequireReceiver);


        StartCoroutine(Recover(RecoverTime));
    }



    // Update is called once per frame
    void Update()
    {       

    }

    IEnumerator Recover(float delay)
    {
        yield return new WaitForSeconds(delay);
        if(isRecover)
        this.SendMessage("StopFontSizeTo", _effectStruct, SendMessageOptions.DontRequireReceiver);
        Destroy(this);
    }

    
}