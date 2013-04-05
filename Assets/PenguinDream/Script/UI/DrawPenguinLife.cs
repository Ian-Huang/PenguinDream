using UnityEngine;
using System.Collections;

/// <summary>
/// UI�]�p-ø�s���Z���ͩR��
/// </summary>
public class DrawPenguinLife : MonoBehaviour
{
    public int currentLife;                 //��e�ͩR��
    public Color color;                     //����
    public int GUIdepth;                    //�K�ϲ`��(�ȶV�p�V��e)
    public Texture PenguinLifeTexture;      //�K�ϯ���
    public Texture PenguinDeadTexture;      //�K�ϯ���
    public Vector2 TexturePosition;         //�K�Ϧ�m
    public GUIStyle TextureStyle;           //�K��style

    void Start()
    {
        this.currentLife = GameManager.TotalLife;
    }

    void OnGUI()
    {
        for (int i = 0; i < GameManager.TotalLife; i++)
        {
            if (this.currentLife > i)
            {
                GUI.Box(new Rect((this.TexturePosition.x + (this.PenguinLifeTexture.width * i)) * GameManager.WidthOffset,
                            this.TexturePosition.y * GameManager.HeightOffset,
                            this.PenguinLifeTexture.width * GameManager.WidthOffset,
                            this.PenguinLifeTexture.height * GameManager.HeightOffset),
                        this.PenguinLifeTexture,
                        this.TextureStyle);
            }
            else
            {
                GUI.Box(new Rect((this.TexturePosition.x + (this.PenguinDeadTexture.width * i)) * GameManager.WidthOffset,
                            this.TexturePosition.y * GameManager.HeightOffset,
                            this.PenguinDeadTexture.width * GameManager.WidthOffset,
                            this.PenguinDeadTexture.height * GameManager.HeightOffset),
                        this.PenguinDeadTexture,
                        this.TextureStyle);
            }
        }
    }
}