using UnityEngine;
using System.Collections;
using Phidgets;

public class PhidgetsScript : MonoBehaviour {

    InterfaceKit ifKit;
    public int[] PhidgetsValue;
	// Use this for initialization
    void Start()
    {
        ifKit = new InterfaceKit();
        ifKit.open();
        ifKit.waitForAttachment(1000);
        PhidgetsValue = new int[8];
    }
	
	// Update is called once per frame
	void Update () {
        if (ifKit != null)
        {
            for (int i = 0; i <= 7; i++)
                PhidgetsValue[i] = ifKit.sensors[i].Value;           
        }
    }




	
}
