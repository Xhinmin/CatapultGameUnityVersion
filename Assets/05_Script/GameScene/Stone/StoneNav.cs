using UnityEngine;
using System.Collections;

public class StoneNav : MonoBehaviour
{

    public Vector3 targetPosition;
    public GameObject target;
    public float speed = 10;
    private float distanceToTarget;
    private bool move = true;
    // Use this for initialization
    void Start()
    {
        distanceToTarget = Vector3.Distance(this.transform.position, targetPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            Vector3 targetPos = targetPosition;
            this.transform.LookAt(targetPos);
            float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * 45;
            this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
            float currentDist = Vector3.Distance(this.transform.position, targetPos);
            if (currentDist < 0.5f)
            {
                move = false;
                Destroy(this.gameObject);
                GameManeger.script.CatapultFireLock = false;
            }
            this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
        }

    }
}
