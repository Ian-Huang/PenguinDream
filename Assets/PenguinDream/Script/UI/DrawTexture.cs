using UnityEngine;
using System.Collections;

/// <summary>
/// UI設計-繪製一張貼圖素材
/// </summary>
public class DrawTexture : MonoBehaviour
{
    public Color color;
    public GameManager.UIChoose UIchoose;
    public int GUIdepth;            //貼圖深度(值越小越後畫)
    public Texture TextureResoure;  //貼圖素材
    public Vector2 TexturePosition; //貼圖位置
    public GUIStyle TextureStyle;   //貼圖style

    void OnGUI()
    {
        if (this.TextureResoure != null)
        {
            GUI.color = color;
            GUI.depth = this.GUIdepth;
            if (GUI.Button(new Rect(this.TexturePosition.x * GameManager.WidthOffset,
                    this.TexturePosition.y * GameManager.HeightOffset,
                    this.TextureResoure.width * GameManager.WidthOffset,
                    this.TextureResoure.height * GameManager.HeightOffset),
                string.Empty,
                this.TextureStyle))
            {
                GameManager.UIButtonClick(this.UIchoose);
            }
            
        }
    }
}
