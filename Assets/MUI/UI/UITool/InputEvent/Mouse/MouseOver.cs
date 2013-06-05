using UnityEngine;
using System.Collections;

/// <summary>
/// 滑鼠在偵測範圍裡面的特效
/// </summary>
public class MouseOver : MonoBehaviour {

    public Object DisplayObject;
    private Rect rect;

    public GameObject EffectObject;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        rect = (Rect)(DisplayObject.GetType().GetField("_rect").GetValue(DisplayObject));
        //rect = new Rect((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);


        if (rect.Contains(new Vector2((int)Input.mousePosition.x, (int)(Screen.height - Input.mousePosition.y))))
            EffectObject.SetActive(true);
        else
            EffectObject.SetActive(false);
	}
}
