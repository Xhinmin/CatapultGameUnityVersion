using UnityEngine;
using System.Collections;

//引導線
//引導線物件
public class NavLine : MonoBehaviour {

    public GameObject prefab;
    public Vector3 targetPos;
    public float interalTime;
    private float time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time >= time + interalTime)
        {
            if (prefab)
            {
                GameObject newGameObject = (GameObject)Instantiate(prefab);
                newGameObject.GetComponent<StoneNav>().targetPosition = new Vector3(GameManeger.script.distance, 1, 0);
            }
            time = Time.time;
        }
	}
}
