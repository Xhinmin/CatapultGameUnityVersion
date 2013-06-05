using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MUI_Monitor : MonoBehaviour {

    //�R�A�ƥ�
    public static MUI_Monitor script;
    //�Ѽƺʱ�Dictionary
    public static Dictionary<string,float> MonitorDictionary = new Dictionary<string,float>();

    public Vector2 From;
    public Vector2 To;
    public string Key;

    public Vector2 Percentage;

    [HideInInspector]
    public MUI_Enum.MUIType MUI_Type;

    public bool dump;
	// Use this for initialization
	void Start () {
        script = this;
	}
	
	// Update is called once per frame
	void Update () {

        if(dump)
        {
            DumpAll();
                dump = false;
        }
	}


    /// <summary>
    /// ��X������T
    /// </summary>
    public void DumpAll()
    {
        foreach (var md in MonitorDictionary)
            print("Key�G" + md.Key + "Value�G" + md.Value);
    }

    /// <summary>
    /// �O�_�s�b
    /// </summary>
    /// <param name="key">Key�r��</param>
    /// <returns></returns>
    public bool isValid(string key)
    {
        if (MonitorDictionary.ContainsKey(key))
            return true;
        else
            return false;
    }

    /// <summary>
    /// ���o�ƭ�
    /// </summary>
    /// <param name="key">Key�r��</param>
    /// <returns></returns>
    public float GetValue(string key)
    {
        if (MonitorDictionary.ContainsKey(key))
            return MonitorDictionary[key];
        else
            return 0;
    }

    /// <summary>
    /// �]�w�ƭ�
    /// </summary>
    /// <param name="key">Key�r��</param>
    /// <param name="newValue">���N���ƭ�</param>
    public void SetValue(string key , float newValue)
    {
        if (MonitorDictionary.ContainsKey(key))
            MonitorDictionary[key] = newValue;
    }

}
