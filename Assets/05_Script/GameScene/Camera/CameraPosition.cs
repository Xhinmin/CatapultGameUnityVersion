using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour {

    //�Ӭ۾����H�۶�����欰
    public static  CameraPosition script;
    //�O�_�Ұ�
    public bool isAcrive;
    //���H������
    public GameObject FollowObject;
	// Use this for initialization
	void Start () {
        script = this;
	}
	
	// Update is called once per frame
	void Update () {

        if (isAcrive)
        {
            //�p�G�����H����
            if (FollowObject)
            {
                //�B�y��>-25
                if(FollowObject.transform.position.x > -25)
                    this.transform.position = new Vector3(FollowObject.transform.position.x, this.transform.position.y, this.transform.position.z);
            }
            else
                isAcrive = false;
        }
        else//�y�Ц^��-25
            this.transform.position = new Vector3(-25, this.transform.position.y, this.transform.position.z);


	}
}
