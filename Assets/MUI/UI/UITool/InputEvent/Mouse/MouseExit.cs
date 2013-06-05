using UnityEngine;
using System.Collections;

/// <summary>
/// �ƹ��X�����d��̭����S��
/// </summary>
public class MouseExit : MonoBehaviour {

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
            EffectObject.SetActive(false);
        else
            EffectObject.SetActive(true);

	}
}
