using UnityEngine;
using System.Collections;

/// <summary>
/// �T�w�W�v���洫�Ϥ�Script
/// </summary>
public class RegularChangePictures : MonoBehaviour
{
    public Texture[] ChangeTextures;
    public float ChangeTextureTime = 0.1f;             //�洫�ɶ����j

    private int currentTextureIndex { get; set; }
    private float addValue { get; set; }

    // Use this for initialization
    void Start()
    {
        this.Reset();
    }

    /// <summary>
    /// �N�ƭȦ^�_���w�]��
    /// </summary>
    void Reset()
    {
        this.addValue = 0;
        this.currentTextureIndex = 0;
        this.renderer.material.mainTexture = this.ChangeTextures[this.currentTextureIndex];
    }

    // Update is called once per frame
    void Update()
    {

        
            if (this.addValue >= this.ChangeTextureTime)
            {
                this.addValue = 0;

                if ((this.currentTextureIndex + 1) >= this.ChangeTextures.Length)       //�k0�A�`��
                    this.currentTextureIndex = 0;
                else
                    this.currentTextureIndex++;

                this.renderer.material.mainTexture = this.ChangeTextures[this.currentTextureIndex];
            }
            this.addValue += Time.deltaTime;
        }
    
}