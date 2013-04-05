using UnityEngine;
using System.Collections;

/// <summary>
/// UI設計-繪製一張自定義的貼圖素材(背景專用-滿版)
/// </summary>
public class DrawCustomBackgroundTexture : MonoBehaviour
{
    public Color color;                 //底色
    public int GUIdepth;                //貼圖深度(值越小越後畫)
    public Texture BackgroundTexture;   //貼圖素材

    void OnGUI()
    {
        if (this.BackgroundTexture != null)
        {
            GUI.color = color;
            GUI.depth = this.GUIdepth;
            GUI.DrawTexture(
                new Rect(0, 0, Screen.width, Screen.height),
                this.BackgroundTexture,
                ScaleMode.StretchToFill);
        }
    }
}
