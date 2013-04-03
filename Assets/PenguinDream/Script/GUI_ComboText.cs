using UnityEngine;
using System.Collections;

public class GUI_ComboText : MonoBehaviour
{
    public float FontSize; 
    public Vector2 TextScreenPosition;
    public float OutlineSize;
    public Rect ShadowRect;
    public GUIContent guiContent;

    public Vector2 ShadowDirection;

    public Color TextColor;
    public Color OutlineColor;
    public Color ShadowColor;
    public GUIStyle style;

    // Use this for initialization
    void Start()
    {

    }

    public void SetContent(string text)
    {
        this.guiContent.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        //this.guiText.material.color = this.TextColor;
        this.ShadowRect = new Rect(
            Screen.width * this.TextScreenPosition.x,
            Screen.height * this.TextScreenPosition.y,
            this.ShadowRect.width,
            this.ShadowRect.height);

        this.style.fontSize = (int)this.FontSize;
    }

    void OnGUI()
    {
        ShadowAndOutline.DrawShadow(this.ShadowRect, this.guiContent, this.style, this.TextColor, this.ShadowColor, this.ShadowDirection);
        ShadowAndOutline.DrawOutline(this.ShadowRect, this.guiContent.text, this.style, this.OutlineColor, this.TextColor, this.OutlineSize);
    }

    public void CallDestroy()
    {
        Destroy(this.gameObject);
    }
}