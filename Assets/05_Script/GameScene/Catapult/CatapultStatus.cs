using UnityEngine;
using System.Collections;

public class CatapultStatus : MonoBehaviour {

    public int MaxHP;
    public static int CurrentHP;

    public GameObject ArmRotateCenter;
	// Use this for initialization
	void Start () {
        CurrentHP = MaxHP;
	}
	
	// Update is called once per frame
	void Update () {
        
        ArmRotateCenter.transform.localPosition = new Vector3 (
            Mathf.Lerp(0, 2, GameManeger.script.distance / 40),
            ArmRotateCenter.transform.localPosition.y,
            ArmRotateCenter.transform.localPosition.z)
            ;
            
	}
}
