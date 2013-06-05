using UnityEngine;
using System.Collections;

public class PhidgetsValue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //力道感測
	    if(true)
        {
            CatapultFire.fire = true;
        }
        //距離感測
        GameManeger.script.distance = 123;

	}
}
