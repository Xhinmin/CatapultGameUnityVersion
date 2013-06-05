using UnityEngine;
using System.Collections;

public class PlayerHitPoint : MonoBehaviour {

    public int playerHitPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetInt("PlayerHitPoints", playerHitPoint);
	}
}
