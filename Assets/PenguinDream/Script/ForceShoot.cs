using UnityEngine;
using System.Collections;

public class ForceShoot : MonoBehaviour
{
    public int PortFront = 0;
    public int PortCenter = 1;
    public int PortBack = 2;
    public int PortShoot = 3;

    public float LimitValue = 600;

    public Vector3 FrontShootForce = Vector3.zero;
    public Vector3 CenterShootForce = Vector3.zero;
    public Vector3 BackShootForce = Vector3.zero;

    public ForceMode mode;

    public AudioClip clip;              //音效檔
    public GameObject SoundObject;

    private GameObject cloneSoundObject;
    private GameSound gameSoundScript;  //聲音播放的script

    private Create create;
    private PhidgetSetting phidgetSetting;
    private PenguinAngleReturn penguinScript;

    private bool isShoot = false;

    void OnDestroy()
    {
        Destroy(this.cloneSoundObject);
    }

    // Use this for initialization
    void Start()
    {
        this.penguinScript = this.GetComponent<PenguinAngleReturn>();

        this.phidgetSetting = GameObject.Find("GamePhidgetSetting").GetComponent<PhidgetSetting>();

        this.cloneSoundObject = (GameObject)Instantiate(this.SoundObject, this.transform.position, Quaternion.identity);
        this.gameSoundScript = this.cloneSoundObject.GetComponent<GameSound>();

        this.create = this.transform.parent.GetComponent<Create>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (this.phidgetSetting.PhidgetKit != null)
        //{
        if (!this.isShoot)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                this.create.ChangeCreateState();
                this.penguinScript.TargetAngle.y = Random.Range(120, 240);
                this.transform.rigidbody.isKinematic = false;
                this.transform.rigidbody.AddForce(this.transform.parent.TransformDirection(this.FrontShootForce), mode);

                this.gameSoundScript.PlaySound(this.clip);              //播放音效
                this.transform.parent = GameObject.Find("ShootObjectGarbage").transform;
                this.isShoot = true;
            }
            else if (Input.GetKeyUp(KeyCode.C))
            {
                this.create.ChangeCreateState();
                this.penguinScript.TargetAngle.y = Random.Range(120, 240);
                this.transform.rigidbody.isKinematic = false;
                this.transform.rigidbody.AddForce(this.transform.parent.TransformDirection(this.CenterShootForce), mode);

                this.gameSoundScript.PlaySound(this.clip);              //播放音效
                this.transform.parent = GameObject.Find("ShootObjectGarbage").transform;
                this.isShoot = true;
            }
            else if (Input.GetKeyUp(KeyCode.B))
            {
                this.create.ChangeCreateState();
                this.penguinScript.TargetAngle.y = Random.Range(120, 240);
                this.transform.rigidbody.isKinematic = false;
                this.transform.rigidbody.AddForce(this.transform.parent.TransformDirection(this.BackShootForce), mode);

                this.gameSoundScript.PlaySound(this.clip);              //播放音效
                this.transform.parent = GameObject.Find("ShootObjectGarbage").transform;
                this.isShoot = true;
            }

            if (this.phidgetSetting.PhidgetKit.sensors[this.PortShoot].Value < this.LimitValue)
                this.create.CanCreate = true;


            if (this.create.CanCreate)
            {
                if (this.phidgetSetting.PhidgetKit.sensors[this.PortFront].Value > this.LimitValue)
                {
                    if (this.phidgetSetting.PhidgetKit.sensors[this.PortShoot].Value > this.LimitValue)
                    {
                        this.create.ChangeCreateState();
                        this.penguinScript.TargetAngle.y = Random.Range(120, 240);
                        this.transform.rigidbody.isKinematic = false;
                        this.transform.rigidbody.AddForce(this.transform.parent.TransformDirection(this.FrontShootForce), mode);

                        this.gameSoundScript.PlaySound(this.clip);              //播放音效
                        this.transform.parent = GameObject.Find("ShootObjectGarbage").transform;
                        this.isShoot = true;
                        this.create.CanCreate = false;
                    }
                }

                else if (this.phidgetSetting.PhidgetKit.sensors[this.PortCenter].Value > this.LimitValue)
                {
                    if (this.phidgetSetting.PhidgetKit.sensors[this.PortShoot].Value > this.LimitValue)
                    {
                        this.create.ChangeCreateState();
                        this.penguinScript.TargetAngle.y = Random.Range(120, 240);
                        this.transform.rigidbody.isKinematic = false;
                        this.transform.rigidbody.AddForce(this.transform.parent.TransformDirection(this.CenterShootForce), mode);

                        this.gameSoundScript.PlaySound(this.clip);              //播放音效
                        this.transform.parent = GameObject.Find("ShootObjectGarbage").transform;
                        this.isShoot = true;
                        this.create.CanCreate = false;
                    }
                }

                else if (this.phidgetSetting.PhidgetKit.sensors[this.PortBack].Value > this.LimitValue)
                {
                    if (this.phidgetSetting.PhidgetKit.sensors[this.PortShoot].Value > this.LimitValue)
                    {
                        this.create.ChangeCreateState();
                        this.penguinScript.TargetAngle.y = Random.Range(120, 240);
                        this.transform.rigidbody.isKinematic = false;
                        this.transform.rigidbody.AddForce(this.transform.parent.TransformDirection(this.BackShootForce), mode);

                        this.gameSoundScript.PlaySound(this.clip);              //播放音效
                        this.transform.parent = GameObject.Find("ShootObjectGarbage").transform;
                        this.isShoot = true;
                        this.create.CanCreate = false;
                    }
                }
            }
        }
        //}
    }
}