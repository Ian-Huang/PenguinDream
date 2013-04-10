using UnityEngine;
using System.Collections;

public class TestText : MonoBehaviour
{
    public string Text;
    public GUISkin skin;
    public Rect rect;

    public Font font;
    public GUIStyle style;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (this.skin)
            GUI.skin = this.skin;
        GUI.Label(this.rect, this.Text);
    }
}
