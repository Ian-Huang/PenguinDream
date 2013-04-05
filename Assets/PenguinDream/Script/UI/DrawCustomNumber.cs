using UnityEngine;
using System.Collections;

/// <summary>
/// UI設計-繪製可自定義圖片的Number list
/// </summary>
public class DrawCustomNumber : MonoBehaviour
{
    public int Number;                  //數值
    public Color color;                 //底色
    public int GUIdepth;                //貼圖深度(值越小越後畫)
    public Texture[] TextureResoure;    //貼圖素材
    public Vector2 TexturePosition;     //貼圖位置
    public GUIStyle TextureStyle;       //貼圖style

    public Vector2 textureSize;
    void Start()
    {
        this.textureSize = new Vector2(this.TextureResoure[0].width, this.TextureResoure[0].height);
    }

    void OnGUI()
    {
        string numberString = this.Number.ToString();

        GUI.color = color;
        GUI.depth = this.GUIdepth;

        for (int i = 0; i < numberString.Length; i++)
        {
            GUI.Box(new Rect((this.TexturePosition.x + (this.textureSize.x) * i) * GameManager.WidthOffset,
                        this.TexturePosition.y * GameManager.HeightOffset,
                        this.textureSize.x * GameManager.WidthOffset,
                        this.textureSize.y * GameManager.HeightOffset),
                    this.TextureResoure[int.Parse(numberString[i].ToString())],
                    this.TextureStyle);
        }
    }
}