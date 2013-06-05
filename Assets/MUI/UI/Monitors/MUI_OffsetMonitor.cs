using UnityEngine;
using System.Collections;

/// <summary>
/// �D�n�\��G�i�H�ǥѥ~�����ܤ����ܼ�
/// Offset �ʱ�
/// ���ܡ@Texture2D�@�Ρ@Label �� Offset ��
///  * �HKey���覡�M��ʱ�Dictionary���������
/// </summary>
public class MUI_OffsetMonitor : MUI_Monitor
{
    private Vector2 offset;
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
        offset.x = Mathf.Lerp(From.x, To.x, Percentage.x / 100);
        offset.y = Mathf.Lerp(From.y, To.y, Percentage.y / 100);

        //�����ܤ�
        if (this.GetComponent<Texture_2D>()) this.GetComponent<Texture_2D>().offset = offset;
        if (this.GetComponent<Label>()) this.GetComponent<Label>().offset = offset;


    }
}
