using UnityEngine;
using System.Collections;

/// <summary>
/// �ƹ�����b�����d��̭����䪺�S��
/// </summary>
public class MButton : MonoBehaviour
{
    public Object DisplayObject;

    [HideInInspector]
    public Rect rect;

    public GameObject EffectObjectWhenPress;
    public GameObject EffectObjectWhenRelease;

    public GameObject Event;

    [HideInInspector]
    public bool pressDown;
}
