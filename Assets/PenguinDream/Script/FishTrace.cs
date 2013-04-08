using UnityEngine;
using System.Collections;

public class FishTrace : MonoBehaviour
{
    public float speed = 0.05f;
    public GameObject Fish;
    public LayerMask PenguinLayer;

    private bool isTrace = false;
    private GameObject penguin;
    private float rotateZ;


    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & this.PenguinLayer.value) > 0)
        {
            this.isTrace = true;
            this.penguin = other.gameObject;
            this.Fish.animation.Stop();

            if ((this.penguin.transform.position.x - this.Fish.transform.position.x) > 0)
                this.rotateZ = 180;
            else
                this.rotateZ = 0;
        }

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.isTrace)
        {
            if (this.penguin != null)
            {
                this.Fish.transform.position = new Vector3(
                        Mathf.Lerp(this.Fish.transform.position.x, this.penguin.transform.position.x, this.speed),
                        Mathf.Lerp(this.Fish.transform.position.y, this.penguin.transform.position.y, this.speed),
                        Mathf.Lerp(this.Fish.transform.position.z, this.penguin.transform.position.z, this.speed)
                    );
                this.Fish.transform.localEulerAngles = new Vector3(
                        0,
                        Mathf.LerpAngle(0, 30, this.speed),
                        this.rotateZ
                    );
            }
            else
            {
                this.isTrace = false;
                this.Fish.animation.Play();
            }
        }
    }
}
