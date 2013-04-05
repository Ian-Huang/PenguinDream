using UnityEngine;
using System.Collections;

/// <summary>
/// UI設計-繪製可自定義圖片的Number list
/// </summary>
public class DrawCustomNumber : MonoBehaviour
{
    public GameManager.GameValue WhichGameValue;    //抓GameManager的值
    public Color color;                 //底色
    public int GUIdepth;                //貼圖深度(值越小越後畫)
    public Texture[] TextureResoure;    //貼圖素材
    public Vector2 TexturePosition;     //貼圖位置
    public GUIStyle TextureStyle;       //貼圖style

    private string numberToString;       //數值轉字串
    private Vector2 textureSize;        //貼圖尺寸
    void Start()
    {
        this.textureSize = new Vector2(this.TextureResoure[0].width, this.TextureResoure[0].height);
    }

    void Update()
    {
        this.numberToString = GameManager.GetGameValue(this.WhichGameValue).ToString();
    }

    void OnGUI()
    {
        GUI.color = color;
        GUI.depth = this.GUIdepth;

        for (int i = 0; i < this.numberToString.Length; i++)
        {
            GUI.Box(new Rect((this.TexturePosition.x + (this.textureSize.x) * i) * GameManager.WidthOffset,
                        this.TexturePosition.y * GameManager.HeightOffset,
                        this.textureSize.x * GameManager.WidthOffset,
                        this.textureSize.y * GameManager.HeightOffset),
                    this.TextureResoure[int.Parse(this.numberToString[i].ToString())],
                    this.TextureStyle);
        }
    }
}