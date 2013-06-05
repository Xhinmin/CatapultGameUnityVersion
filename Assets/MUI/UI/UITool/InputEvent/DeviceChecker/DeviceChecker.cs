using UnityEngine;
using System.Collections;

public class DeviceChecker : MonoBehaviour {

    public Object DesktopInput;
    public Object AndroidInput;
	// Use this for initialization
    void Start()
    {

//Check if Platform Set Android
#if UNITY_ANDROID
        ((MButton)AndroidInput).enabled = true;
        ((MButton)DesktopInput).enabled = false;
#endif

//Check if use editor mode to SIMULATE At the END - 
#if UNITY_EDITOR
        ((MButton)AndroidInput).enabled = false;
        ((MButton)DesktopInput).enabled = true;
#endif


    }
	
}
