using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour
{
    public GameObject CreateObject;
    public float CreateDelayTime = 0.5f;    //��

    public bool CanCreate = true;

    public bool isOneByOne = false;
    private bool isStartCreate = true;
    
    private float addTimeValue = 0;    

    // Use this for initialization
    void Start()
    {
        this.addTimeValue = 0;
        if (this.isOneByOne)
            CreateShootObject();
        
    }

    public void ChangeCreateState()
    {
        if (!this.isStartCreate)
            this.isStartCreate = true;
    }

    public void CreateShootObject()
    {
        GameObject obj;
        obj = (GameObject)Instantiate(this.CreateObject, transform.position, Quaternion.identity);
        obj.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isStartCreate && !this.isOneByOne)
        {
            if (this.addTimeValue < this.CreateDelayTime)            
                this.addTimeValue += Time.deltaTime;
            
            else
            {
                this.CreateShootObject();
                this.addTimeValue = 0;
                this.isStartCreate = false;
            }
        }
    }
}