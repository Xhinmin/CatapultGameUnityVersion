using UnityEngine;
using System.Collections;

/// <summary>
/// Rect �ʱ�
/// ���ܡ@Texture2D�@�Ρ@Label �� Rect ��
///  * �HKey���覡�M��ʱ�Dictionary���������
/// </summary>
public class MUI_RectMonitor : MUI_Monitor
{
    private Rect rect;

    // Use this for initialization
    void Start()
    {
        //�HKey���r����U�@�ӯ���
        if (Key != "") MonitorDictionary.Add(Key + "x", 0);
        if (Key != "") MonitorDictionary.Add(Key + "y", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isValid(Key + "x")) Percentage.x = MonitorDictionary[Key + "x"];
        if (isValid(Key + "y")) Percentage.y = MonitorDictionary[Key + "y"];
        rect.x = Mathf.Lerp(From.x, To.x, Percentage.x / 100);
        rect.y = Mathf.Lerp(From.y, To.y, Percentage.y / 100);


        //�����ܤ�
        if (this.GetComponent<Texture_2D>()) this.GetComponent<Texture_2D>().rect = rect;
        if (this.GetComponent<Label>()) this.GetComponent<Label>().rect = rect;
    }
}
