using UnityEngine;
using System.Collections;

/// <summary>
/// ���ͯB�B���޲z��,�H���b�e����T�h����
/// </summary>
public class CreateIceManager : MonoBehaviour
{
    public float CreateTimeInterval = 8;    //���ͯB�B�����j
    private int currentLayout = -1;         //�W�����ͯB�B�����h

    // Use this for initialization
    void Start()
    {
        this.RandomCreateIce();
    }

    /// <summary>
    /// �H���b(�e����)�T�h���ͯB�B
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
        //�T�w�ɶ��A���ͯB�B
        if (!this.IsInvoking("RandomCreateIce"))
            this.Invoke("RandomCreateIce", this.CreateTimeInterval);
    }
}