using UnityEngine;
using System.Collections;

public class CatapultFire : MonoBehaviour {

    public GameObject Arm;
    public GameObject Stone;
    public GameObject FireCenter;
    public GameObject RotatePoint;
    public static bool fire;
    public float angle;

	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManeger.script.CatapultFireLock) return;

        if (fire || Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newStone = (GameObject)Instantiate(Stone,FireCenter.transform.position,Quaternion.identity);
            newStone.GetComponent<StoneNav>().targetPosition = new Vector3(GameManeger.script.distance + Stone.transform.position.x + 40, 1, 0);

            CameraPosition.script.isAcrive = true;
            CameraPosition.script.FollowObject = newStone;

            iTween.RotateTo(Arm, iTween.Hash("y", 60, "time", 0.25, "easetype", iTween.EaseType.easeInSine  ,"islocal" , true));
            iTween.RotateTo(Arm, iTween.Hash("y", 0, "time", 0.25, "delay", 0.25, "easetype", iTween.EaseType.easeInSine, "islocal" , true));
            fire = false;
            GameManeger.script.CatapultFireLock = true;
        }


            
     
    
	}


}
