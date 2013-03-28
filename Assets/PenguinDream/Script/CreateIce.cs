using UnityEngine;
using System.Collections;

public class CreateIce : MonoBehaviour
{
    public float MoveSpeed;
    public GameDefinition.Direction direction;

    public GameObject IceObject;

    public bool isStart = false;

    public void CreateIceObject()
    {
        GameObject createObject;
        IceController script;
        createObject = (GameObject)Instantiate(this.IceObject, this.transform.position, Quaternion.identity);
        createObject.transform.parent = this.transform;
        script = createObject.GetComponent<IceController>();
        script.SetValue(this.MoveSpeed, this.direction);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isStart)
        {
            this.CreateIceObject();
            this.isStart = false;
        }
    }
}