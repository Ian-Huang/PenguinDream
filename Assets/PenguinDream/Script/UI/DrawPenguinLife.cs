using UnityEngine;
using System.Collections;

/// <summary>
/// UI設計-繪製企鵝的生命值
/// </summary>
public class DrawPenguinLife : MonoBehaviour
{
    public int currentLife;                 //當前生命值
    public Color color;                     //底色
    public int GUIdepth;                    //貼圖深度(值越小越後畫)
    public Texture PenguinLifeTexture;      //貼圖素材
    public Texture PenguinDeadTexture;      //貼圖素材
    public Vector2 TexturePosition;         //貼圖位置
    public GUIStyle TextureStyle;           //貼圖style

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