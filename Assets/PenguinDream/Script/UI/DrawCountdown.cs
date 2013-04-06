using UnityEngine;
using System.Collections;

/// <summary>
/// UI設計-繪製倒數計時圖
/// </summary>
public class DrawCountdown : MonoBehaviour
{
    public GameManager.GameValue WhichGameValue;    //抓GameManager的值
    public Color color;                 //底色
    public int GUIdepth;                //貼圖深度(值越小越後畫)
    public Texture[] TextureResoure;    //貼圖素材
    public Vector2 TexturePosition;     //貼圖位置
    public GUIStyle TextureStyle;       //貼圖style

    private int number;       //數值轉字串
    private int currentNumber = -1;
    void Start()
    {
    }

    void Update()
    {

    }

    void OnGUI()
    {
        if (GameManager.TotalTime < 4)
        {
            this.number = GameManager.GetGameValue(this.WhichGameValue);
            if (this.currentNumber != this.number)
            {
                this.animation.Stop();
                this.animation.Play();
                this.currentNumber = this.number;
            }

            GUI.color = color;
            GUI.depth = this.GUIdepth;

            GUI.Box(new Rect((this.TexturePosition.x - (this.TextureResoure[this.number].width / 2)) * GameManager.WidthOffset,
                            (this.TexturePosition.y - (this.TextureResoure[this.number].height / 2)) * GameManager.HeightOffset,
                            this.TextureResoure[this.number].width * GameManager.WidthOffset,
                            this.TextureResoure[this.number].height * GameManager.HeightOffset),
                        this.TextureResoure[this.number],
                        this.TextureStyle);
        }
    }
}