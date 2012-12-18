using UnityEngine;
using System.Collections;

public class AnalogyShoot : MonoBehaviour
{
    public int PortX = 6;
    public int PortY = 7;
    
    public float maxMultiple = 1;
    public float minMultiple = 0;

    public float ReturnLimitValueY = 550;

    public Vector3 ShootForce = Vector3.zero;
    public ForceMode mode;

    private Create create;
    private PhidgetSetting phidgetSetting;
    private bool isShoot = false;
    private bool isReturn = true;
    private float xValue;
    private float yValue;
	
	private PenguinAngleReturn penguinScript;

    // Use this for initialization
    void Start()
    {
        this.penguinScript = this.GetComponent<PenguinAngleReturn>();

        this.phidgetSetting = GameObject.Find("GamePhidgetSetting").GetComponent<PhidgetSetting>();

        this.create = this.transform.parent.GetComponent<Create>();

        if (this.phidgetSetting.PhidgetKit.sensors[this.PortY].Value > this.ReturnLimitValueY)
            this.isReturn = false;
        else
            this.isReturn = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.phidgetSetting.PhidgetKit != null)
        {
            if (!this.isShoot)
            {
                if (this.isReturn)
                {
                    if (this.phidgetSetting.PhidgetKit.sensors[this.PortY].Value > this.ReturnLimitValueY)
                        this.isReturn = false;
                }
                else
                {
                    if (this.phidgetSetting.PhidgetKit.sensors[this.PortY].Value > this.yValue)
                    {
                        this.yValue = this.phidgetSetting.PhidgetKit.sensors[this.PortY].Value;
                        this.xValue = this.phidgetSetting.PhidgetKit.sensors[this.PortX].Value;
                    }

                    if (this.phidgetSetting.PhidgetKit.sensors[this.PortY].Value <= this.ReturnLimitValueY)
                    {
                        this.isReturn = true;

                        this.create.ChangeCreateState();

                        float multiple = Mathf.Lerp(this.minMultiple, this.maxMultiple, (this.yValue - ReturnLimitValueY) / (1000 - ReturnLimitValueY));
                        

                        this.ShootForce.z *= multiple;

                        if (this.xValue < 400)
                            this.ShootForce.x *= Mathf.Lerp(0, 1, (400 - this.xValue) / 400.0f);

                        else if (this.xValue > 600)
                            this.ShootForce.x *= -Mathf.Lerp(0, 1, (this.xValue - 600) / 400.0f);

                        else
                            this.ShootForce.x = 0;

                        this.penguinScript.TargetAngle.y = Random.Range(0, 360);

                        this.transform.rigidbody.isKinematic = false;
                        this.transform.rigidbody.AddForce(this.transform.parent.TransformDirection(this.ShootForce), mode);

                        this.transform.parent = GameObject.Find("ShootObjectGarbage").transform;
                        this.isShoot = true;
                    }
                }
            }
        }
    }
}