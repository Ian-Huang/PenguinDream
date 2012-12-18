using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour
{
    public PhidgetSetting phidgetSetting;
    public int Port = 1;

    private float newValue = 0;
    private float oldValue = 0;
    private float deletaValue = 0;

    public bool isReturn = true;
    public float maxValue = 0;
    public bool isShoot = false;


    // Use this for initialization
    void Start()
    {
        if (this.phidgetSetting.PhidgetKit.sensors[this.Port].Value > 200)
            this.isReturn = false;
        else
            this.isReturn = true;
        
    }

    //Update is called once per frame
    void Update()
    {
        if (this.phidgetSetting.PhidgetKit != null)
        {
            if (this.isReturn)
            {
                if (this.phidgetSetting.PhidgetKit.sensors[this.Port].Value > 200)
                    this.isReturn = false;
            }
            else
            {
                if (this.phidgetSetting.PhidgetKit.sensors[this.Port].Value > this.maxValue)
                {
                    this.maxValue = this.phidgetSetting.PhidgetKit.sensors[this.Port].Value;
                }

                if (this.phidgetSetting.PhidgetKit.sensors[this.Port].Value <= 200)
                {
                    this.isReturn = true;
                    this.isShoot = true;
                }
            }
            this.newValue = this.phidgetSetting.PhidgetKit.sensors[this.Port].Value;
            print("push = " + this.newValue);
            //this.deletaValue = this.newValue - this.oldValue;

            this.oldValue = this.newValue;
        }
    }
}
