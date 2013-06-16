using UnityEngine;
using System.Collections;

//敵人移動含碰撞反應
public class EnemyMove : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
        speed = Random.Range(-4, -7);
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
	}

    void OnTriggerEnter(Collider obj)
    {
        if (obj.transform.name == "Catapult")
        {
            CatapultStatus.CurrentHP -= 5;
            Destroy(this.gameObject);
        }

        if (obj.transform.name == "Stone" || obj.transform.name == "Stone(Clone)")
        {
            GameManeger.script.hitCount++;
            Destroy(this.gameObject);
            Destroy(obj.gameObject);
            GameManeger.script.CatapultFireLock = false;
        }
    }
}
