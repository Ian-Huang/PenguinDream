using UnityEngine;
using System.Collections;
using Phidgets;

public class PhidgetSetting : MonoBehaviour
{
    public InterfaceKit PhidgetKit { get; private set; }
    public bool isOpenPhidget;

    // Use this for initialization
    void Start()
    {
        if (this.isOpenPhidget)
        {
            this.PhidgetKit = new InterfaceKit();
            this.PhidgetKit.open();
            this.PhidgetKit.waitForAttachment(1000);
        }
    }
    void OnDisable()
    {
        if (this.isOpenPhidget)
        {
            this.PhidgetKit.close();
        }
    }
}