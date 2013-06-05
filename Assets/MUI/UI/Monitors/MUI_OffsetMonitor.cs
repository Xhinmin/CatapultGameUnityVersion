using UnityEngine;
using System.Collections;

/// <summary>
/// 主要功能：可以藉由外部改變內部變數
/// Offset 監控
/// 改變　Texture2D　或　Label 的 Offset 值
///  * 以Key的方式尋找監控Dictionary對應的資料
/// </summary>
public class MUI_OffsetMonitor : MUI_Monitor
{
    private Vector2 offset;
    // Use this for initialization
    void Start()
    {
        //以Key為字串註冊一個索引
        if (Key != "") MonitorDictionary.Add(Key + "x", 0);
        if (Key != "") MonitorDictionary.Add(Key + "y", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isValid(Key + "x")) Percentage.x = MonitorDictionary[Key + "x"];
        if (isValid(Key + "y")) Percentage.y = MonitorDictionary[Key + "y"];
        offset.x = Mathf.Lerp(From.x, To.x, Percentage.x / 100);
        offset.y = Mathf.Lerp(From.y, To.y, Percentage.y / 100);

        //介面變化
        if (this.GetComponent<Texture_2D>()) this.GetComponent<Texture_2D>().offset = offset;
        if (this.GetComponent<Label>()) this.GetComponent<Label>().offset = offset;


    }
}
