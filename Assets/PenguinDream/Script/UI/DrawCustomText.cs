using UnityEngine;
using System.Collections;

/// <summary>
/// UI設計-可自定義的Text UI
/// </summary>
public class DrawCustomText : MonoBehaviour
{
    public GameManager.UITextPattern pattern;
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
            this.TextScreenPosition.x * GameManager.WidthOffset,
            this.TextScreenPosition.y * GameManager.HeightOffset,
            this.ShadowRect.width,
            this.ShadowRect.height);

        this.style.fontSize = (int)this.FontSize;
    }

    void OnGUI()
    {
        switch (this.pattern)
        {
            case GameManager.UITextPattern.ShadowAndOutline:
                ShadowAndOutline.DrawShadow(this.ShadowRect, this.guiContent, this.style, this.TextColor, this.ShadowColor, this.ShadowDirection);
                ShadowAndOutline.DrawOutline(this.ShadowRect, this.guiContent, this.style, this.OutlineColor, this.TextColor, this.OutlineSize);
                break;
            case GameManager.UITextPattern.Shadow:
                ShadowAndOutline.DrawShadow(this.ShadowRect, this.guiContent, this.style, this.TextColor, this.ShadowColor, this.ShadowDirection);
                break;
            case GameManager.UITextPattern.Outline:
                ShadowAndOutline.DrawOutline(this.ShadowRect, this.guiContent, this.style, this.OutlineColor, this.TextColor, this.OutlineSize);
                break;
            default:
                break;
        }

    }

    public void CallDestroy()
    {
        Destroy(this.gameObject);
    }
}