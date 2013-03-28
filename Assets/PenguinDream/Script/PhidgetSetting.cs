using UnityEngine;
using System.Collections;
using Phidgets;

public class PhidgetSetting : MonoBehaviour
{    
    public InterfaceKit PhidgetKit { get; private set; }

    // Use this for initialization
    void Start()
    {
		this.PhidgetKit = new InterfaceKit();
        this.PhidgetKit.open();
        this.PhidgetKit.waitForAttachment(1000);
    }
    void OnDisable()
    {
        this.PhidgetKit.close();
    }
}