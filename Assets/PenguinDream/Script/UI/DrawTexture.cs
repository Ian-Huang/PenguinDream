using UnityEngine;
using System.Collections;

/// <summary>
/// UI�]�p-ø�s�@�i�K�ϯ���
/// </summary>
public class DrawTexture : MonoBehaviour
{
    public Color color;
    public GameManager.UIChoose UIchoose;
    public int GUIdepth;            //�K�ϲ`��(�ȶV�p�V��e)
    public Texture TextureResoure;  //�K�ϯ���
    public Vector2 TexturePosition; //�K�Ϧ�m
    public GUIStyle TextureStyle;   //�K��style

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
