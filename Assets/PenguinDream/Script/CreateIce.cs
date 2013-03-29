using UnityEngine;
using System.Collections;

/// <summary>
/// �]�w�B�B�ݩʡA���ͯB�B
/// </summary>
public class CreateIce : MonoBehaviour
{
    public float IceMoveSpeed;                  //�B�B���ʪ��t��
    public GameDefinition.Direction direction;  //�B�B���ʪ���V
    public GameObject IceObject;                //�ݲ��ͪ��B�B����

    public bool Debug_isStart = false;          //Debug�ΡA��������Ice

    /// <summary>
    /// ���ͯB�B
    /// </summary>
    public void CreateIceObject()
    {
        GameObject createObject;
        IceController iceScript;

        createObject = (GameObject)Instantiate(this.IceObject, this.transform.position, Quaternion.identity);
        createObject.transform.parent = this.transform;
        iceScript = createObject.GetComponent<IceController>();
        iceScript.SetIceAttributes(this.IceMoveSpeed, this.direction);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug�ΡA��������Ice
        if (this.Debug_isStart)
        {
            this.CreateIceObject();
            this.Debug_isStart = false;
        }
    }
}