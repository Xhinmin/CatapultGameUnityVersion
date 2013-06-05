using UnityEngine;
using System.Collections;

public class CreateEnemy : MonoBehaviour {

    public int interalTime;
    private float time;
    public Transform Enemy;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= time + interalTime)
        {
            if (Enemy)
            {
                interalTime = Random.Range(5, 10);
                Instantiate(Enemy);
            }
            time = Time.time;
        }
    }
}
