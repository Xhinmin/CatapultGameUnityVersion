using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MUI_Monitor : MonoBehaviour {

    //繰篈捌セ
    public static MUI_Monitor script;
    //把计菏北Dictionary
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
    /// 块场戈癟
    /// </summary>
    public void DumpAll()
    {
        foreach (var md in MonitorDictionary)
            print("Key" + md.Key + "Value" + md.Value);
    }

    /// <summary>
    /// 琌
    /// </summary>
    /// <param name="key">Key﹃</param>
    /// <returns></returns>
    public bool isValid(string key)
    {
        if (MonitorDictionary.ContainsKey(key))
            return true;
        else
            return false;
    }

    /// <summary>
    /// 眔计
    /// </summary>
    /// <param name="key">Key﹃</param>
    /// <returns></returns>
    public float GetValue(string key)
    {
        if (MonitorDictionary.ContainsKey(key))
            return MonitorDictionary[key];
        else
            return 0;
    }

    /// <summary>
    /// 砞﹚计
    /// </summary>
    /// <param name="key">Key﹃</param>
    /// <param name="newValue">计</param>
    public void SetValue(string key , float newValue)
    {
        if (MonitorDictionary.ContainsKey(key))
            MonitorDictionary[key] = newValue;
    }

}
