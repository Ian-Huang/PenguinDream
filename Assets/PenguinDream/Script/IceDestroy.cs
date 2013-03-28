using UnityEngine;
using System.Collections;

public class IceDestroy : MonoBehaviour
{
    public GameObject Target;
    private GameObject cameraObject;
    public CameraSmooth cameraSmoothScipt;
    private Create create;
    public float WaitTime = 1;
    private float addValue;
    private GameObject destroyObject;

    private bool checkPos = false;

    void OnCollisionStay(Collision other)
    {
        if (other.rigidbody.velocity.magnitude < 0.1f)
        {
            if (this.addValue > this.WaitTime)
            {
                this.cameraSmoothScipt.Target = this.Target;
                this.destroyObject = other.gameObject;
                checkPos = true;
            }
            else
                addValue += Time.deltaTime;
        }
    }

    void OnCollisionExit(Collision other)
    {
        this.addValue = 0;
    }

    // Use this for initialization
    void Start()
    {
        this.cameraObject = GameObject.Find("MainCamera");
        this.create = GameObject.Find("ShootPosition").GetComponent<Create>();
        this.cameraSmoothScipt = this.cameraObject.GetComponent<CameraSmooth>();
        this.addValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.checkPos)
        {
            if (Vector3.Distance(Target.transform.position, this.cameraObject.transform.position) < 1)
            {
                this.create.CreateShootObject();
                this.checkPos = false;
                Destroy(this.destroyObject);
            }
        }
    }
}
