using UnityEngine;
using System.Collections;

/// <summary>
/// 設定浮冰屬性，產生浮冰
/// </summary>
public class CreateIce : MonoBehaviour
{
    public float IceMoveSpeed;                  //浮冰移動的速度
    public GameDefinition.Direction direction;  //浮冰移動的方向
    public GameObject IceObject;                //待產生的浮冰物件

    public bool Debug_isStart = false;          //Debug用，直接產生Ice

    /// <summary>
    /// 產生浮冰
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
        //Debug用，直接產生Ice
        if (this.Debug_isStart)
        {
            this.CreateIceObject();
            this.Debug_isStart = false;
        }
    }
}