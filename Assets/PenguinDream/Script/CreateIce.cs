using UnityEngine;
using System.Collections;

/// <summary>
/// �]�w�B�B�ݩʡA���ͯB�B
/// </summary>
public class CreateIce : MonoBehaviour
{
    public float IceMoveSpeed;                  //�B�B���ʪ��t��
    public GameDefinition.Direction direction;  //�B�B���ʪ���V
    public GameObject TimeObejct;               //�ݥͲ��B�B(�W��+�ɶ��D��)
    public GameObject IceObject;                //�ݥͲ��B�B(�W�L�D��)
    public GameObject IceObject_Star;           //�ݥͲ��B�B(�W���P�P)

    public bool Debug_isStart = false;          //Debug�ΡA��������Ice

    /// <summary>
    /// ���ͯB�B
    /// </summary>
    public void CreateIceObject()
    {
        GameObject createObject;
        IceController iceScript;

        int random = Random.Range(1, 11);
        if (random <= 2)
            createObject = (GameObject)Instantiate(this.TimeObejct, this.transform.position, Quaternion.identity);
        else if (random <= 5)
            createObject = (GameObject)Instantiate(this.IceObject, this.transform.position, Quaternion.identity);
        else
            createObject = (GameObject)Instantiate(this.IceObject_Star, this.transform.position, Quaternion.identity);

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