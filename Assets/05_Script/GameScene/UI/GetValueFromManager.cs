using UnityEngine;
using System.Collections;

public class GetValueFromManager : MonoBehaviour
{

    public enum ValueFrom { GameTime, Angle, HitCount };
    public ValueFrom valueFrom;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        switch (valueFrom)
        {
            case ValueFrom.Angle:
                this.GetComponent<Label>().Text = GameManeger.script.distance.ToString();
                break;
            case ValueFrom.GameTime:
                this.GetComponent<Label>().Text = GameManeger.script.gameTime.ToString("0.00");
                break;
            case ValueFrom.HitCount:
                this.GetComponent<Label>().Text = GameManeger.script.hitCount.ToString();
                break;
        }
	}
}
