using UnityEngine;
using System.Collections;

/// <summary>
/// �]�wTextureTo�ĪG�ܼ�
/// </summary>
public class TextureTo : MonoBehaviour
{
    private Texture_2D texture_2D;
    private Texture textur_2D_backup;
    public Texture Texture2d;

    //����QDisable�ɬO�_�^��쥻���A
    public bool ResetAfterDisable;

    void Awake()
    {
        if (this.gameObject.GetComponent<Texture_2D>())
            texture_2D = this.gameObject.GetComponent<Texture_2D>();
        else if (this.transform.parent.GetComponent<Texture_2D>())
            texture_2D = this.transform.parent.GetComponent<Texture_2D>();
    }
    // Use this for initialization
    void Start()
    {

    }

    void OnEnable()
    {
        textur_2D_backup = this.texture_2D.Texture2d;
        this.texture_2D.Texture2d = Texture2d;
    }

    void OnDisable()
    {
        if (ResetAfterDisable)
            this.texture_2D.Texture2d = textur_2D_backup;
    }

}