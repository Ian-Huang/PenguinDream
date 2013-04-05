using UnityEngine;
using System.Collections;

/// <summary>
/// UI�]�p-ø�s�i�۩w�q�Ϥ���Number list
/// </summary>
public class DrawCustomNumber : MonoBehaviour
{
    public int Number;                  //�ƭ�
    public Color color;                 //����
    public int GUIdepth;                //�K�ϲ`��(�ȶV�p�V��e)
    public Texture[] TextureResoure;    //�K�ϯ���
    public Vector2 TexturePosition;     //�K�Ϧ�m
    public GUIStyle TextureStyle;       //�K��style

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