using UnityEngine;
using System.Collections;
using Phidgets;

public class PhidgetsValue : MonoBehaviour {


    InterfaceKit ifKit;
    public int[] _PhidgetsValue;
    // Use this for initialization
    void Start()
    {
        ifKit.close();
        ifKit = new InterfaceKit();
        ifKit.open();
        ifKit.waitForAttachment(1000);
        _PhidgetsValue = new int[8];
    }

    // Update is called once per frame
    void Update()
    {
        if (ifKit != null)
        {
            for (int i = 0; i <= 7; i++)
                _PhidgetsValue[i] = ifKit.sensors[i].Value;
        }

        //力道感測
        if (_PhidgetsValue[0] > 500)
        {
            CatapultFire.fire = true;
        }
        //距離感測
        GameManeger.script.distance = _PhidgetsValue[1]/10;
    }

    void OnDestroy()
    {
        ifKit.close();
    }


}
