using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{
    public GameObject Shakeobject;
    public PhidgetSetting phidgetSetting;
    public int Port = 0;
    public float shakeValue = 50;

    private float newValue = 0;
    private float oldValue = 0;
    private float deletaValue = 0;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.phidgetSetting.PhidgetKit != null)
        {
            this.newValue = (this.phidgetSetting.PhidgetKit.sensors[this.Port].Value) - 500;
            
            this.deletaValue = this.newValue - this.oldValue;
            //print("Shake = " + this.deletaValue.ToString());
            
            this.Shakeobject.transform.position += new Vector3(this.deletaValue / shakeValue, this.deletaValue / shakeValue, this.deletaValue / shakeValue);
            
            this.oldValue = this.newValue;
        }
    }
}
