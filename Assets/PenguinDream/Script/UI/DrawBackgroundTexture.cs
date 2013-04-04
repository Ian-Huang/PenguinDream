using UnityEngine;
using System.Collections;

/// <summary>
/// UI設計-繪製一張貼圖素材(背景專用-滿版)
/// </summary>
public class DrawBackgroundTexture : MonoBehaviour
{
    public int GUIdepth;                //貼圖深度(值越小越後畫)
    public Texture BackgroundTexture;   //貼圖素材

    void OnGUI()
    {
        if (this.BackgroundTexture != null)
        {
            GUI.depth = this.GUIdepth;
            GUI.DrawTexture(
                new Rect(0, 0, Screen.width, Screen.height),
                this.BackgroundTexture,
                ScaleMode.StretchToFill);
        }
    }
}
