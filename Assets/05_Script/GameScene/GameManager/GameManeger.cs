using UnityEngine;
using System.Collections;

public class GameManeger : MonoBehaviour {

    public static GameManeger script;
    public CatapultStatus CatapultStatus;
    public float gameTime;
    public float distance; //距離(已自動加20)
    public int hitCount;
    public bool CatapultFireLock;
	// Use this for initialization
	void Start () {
        script = this;
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        gameTime += Time.deltaTime;
	    MUI_Monitor.script.SetValue("CHP" + "x", ((float)CatapultStatus.CurrentHP / CatapultStatus.MaxHP) * 100);
	}
}
