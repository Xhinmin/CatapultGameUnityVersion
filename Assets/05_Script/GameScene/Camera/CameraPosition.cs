using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour {

    //照相機跟隨石塊飛行行為
    public static  CameraPosition script;
    //是否啟動
    public bool isAcrive;
    //跟隨的物體
    public GameObject FollowObject;
	// Use this for initialization
	void Start () {
        script = this;
	}
	
	// Update is called once per frame
	void Update () {

        if (isAcrive)
        {
            //如果有跟隨物體
            if (FollowObject)
            {
                //且座標>-25
                if(FollowObject.transform.position.x > -25)
                    this.transform.position = new Vector3(FollowObject.transform.position.x, this.transform.position.y, this.transform.position.z);
            }
            else
                isAcrive = false;
        }
        else//座標回到-25
            this.transform.position = new Vector3(-25, this.transform.position.y, this.transform.position.z);


	}
}
