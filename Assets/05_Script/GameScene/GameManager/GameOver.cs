using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public GameObject GameOverUI;
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (CatapultStatus.CurrentHP == 0)
        {
            GameOverUI.SetActive(true);
            Time.timeScale = 0.000001F;
            if (Input.anyKeyDown)
                Application.LoadLevel("GameScene");
        }
	}
}
