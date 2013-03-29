using UnityEngine;
using System.Collections;

/// <summary>
/// 產生浮冰的管理者,隨機在前中後三層產生
/// </summary>
public class CreateIceManager : MonoBehaviour
{
    public float CreateTimeInterval = 8;    //產生浮冰的間隔
    private int currentLayout = -1;         //上次產生浮冰的階層

    // Use this for initialization
    void Start()
    {
        this.RandomCreateIce();
    }

    /// <summary>
    /// 隨機在(前中後)三層產生浮冰
    /// </summary>
    void RandomCreateIce()
    {
        int random;
        do
        {
            random = Random.Range(0, 3);
        } while (random == this.currentLayout);
        this.currentLayout = random;

        switch ((GameDefinition.Layout)this.currentLayout)
        {
            case GameDefinition.Layout.Front:
                GameObject.Find("Layout_Front").GetComponent<CreateIce>().CreateIceObject();
                break;
            case GameDefinition.Layout.Center:
                GameObject.Find("Layout_Center").GetComponent<CreateIce>().CreateIceObject();
                break;
            case GameDefinition.Layout.Back:
                GameObject.Find("Layout_Back").GetComponent<CreateIce>().CreateIceObject();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //固定時間，產生浮冰
        if (!this.IsInvoking("RandomCreateIce"))
            this.Invoke("RandomCreateIce", this.CreateTimeInterval);
    }
}