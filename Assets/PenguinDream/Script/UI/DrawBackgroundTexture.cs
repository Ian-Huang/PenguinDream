using UnityEngine;
using System.Collections;

/// <summary>
/// UI�]�p-ø�s�@�i�K�ϯ���(�I���M��-����)
/// </summary>
public class DrawBackgroundTexture : MonoBehaviour
{
    public int GUIdepth;                //�K�ϲ`��(�ȶV�p�V��e)
    public Texture BackgroundTexture;   //�K�ϯ���

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
