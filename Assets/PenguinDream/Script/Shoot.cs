using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public int Port = 1;
    public float ReturnLimitValue = 250;
    public Vector3 force = Vector3.zero;
    public ForceMode mode;

    private Create create;
    private PhidgetSetting phidgetSetting;
    private bool isShoot = false;
    private bool isReturn = true;
    private float maxValue = 0;

    public float maxMultiple = 1;
    public float minMultiple = 0.8f;

    // Use this for initialization
    void Start()
    {
        this.phidgetSetting = GameObject.Find("GamePhidgetSetting").GetComponent<PhidgetSetting>();

        this.create = this.transform.parent.GetComponent<Create>();

        if (this.phidgetSetting.PhidgetKit.sensors[this.Port].Value > this.ReturnLimitValue)
            this.isReturn = false;
        else
            this.isReturn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.phidgetSetting.PhidgetKit != null)
        {
            if (!this.isShoot)
            {
                if (this.isReturn)
                {
                    if (this.phidgetSetting.PhidgetKit.sensors[this.Port].Value > this.ReturnLimitValue)
                        this.isReturn = false;
                }
                else
                {
                    if (this.phidgetSetting.PhidgetKit.sensors[this.Port].Value > this.maxValue)
                    {
                        this.maxValue = this.phidgetSetting.PhidgetKit.sensors[this.Port].Value;
                    }

                    if (this.phidgetSetting.PhidgetKit.sensors[this.Port].Value <= this.ReturnLimitValue)
                    {
                        this.isReturn = true;

                        this.create.ChangeCreateState();

                        float multiple = Mathf.Lerp(this.minMultiple, this.maxMultiple, this.maxValue / 1000.0f);

                        this.transform.parent = GameObject.Find("ShootObjectGarbage").transform;

                        this.transform.rigidbody.isKinematic = false;
                        this.transform.rigidbody.AddForce(this.transform.TransformDirection(this.force) * multiple, mode);
                        this.isShoot = true;
                    }
                }
            }
        }
    }
}