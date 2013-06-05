using UnityEngine;
using System.Collections;

public class CatapultFire : MonoBehaviour {

    public GameObject Arm;
    public GameObject Stone;
    public static bool fire;


	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManeger.script.CatapultFireLock) return;

        if (fire || Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newStone = (GameObject)Instantiate(Stone);
            newStone.GetComponent<StoneNav>().targetPosition = new Vector3(GameManeger.script.distance + Stone.transform.position.x + 20, 1, 0);

            CameraPosition.script.isAcrive = true;
            CameraPosition.script.FollowObject = newStone;

            iTween.RotateTo(Arm, iTween.Hash("y", 40, "time", 0.5, "easetype", iTween.EaseType.easeInSine  ,"islocal" , true));
            iTween.RotateTo(Arm, iTween.Hash("y", -20, "time", 0.5, "delay", 0.5, "easetype", iTween.EaseType.easeInSine, "islocal" , true));
            fire = false;
            GameManeger.script.CatapultFireLock = true;
        }



	}
}
