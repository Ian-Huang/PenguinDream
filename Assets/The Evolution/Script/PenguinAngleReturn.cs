using UnityEngine;
using System.Collections;

public class PenguinAngleReturn : MonoBehaviour
{
    //private Vector3 OriginPosition;
    private float Velocity;

    public Vector3 TargetAngle = Vector3.zero;
    public float SmoothTime = 0.1f;

    // Use this for initialization
    void Start()
    {
        //this.OriginPosition = this.transform.position;
        TargetAngle = Vector3.zero;
        TargetAngle.y = (180 + GameObject.Find("MainCamera").transform.eulerAngles.y) % 360;
    }

    // Update is called once per frame
    void Update()
    {
        float tempX = Mathf.SmoothDampAngle(this.transform.eulerAngles.x, TargetAngle.x, ref Velocity, this.SmoothTime);
        float tempY = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, TargetAngle.y, ref Velocity, this.SmoothTime);
        float tempZ = Mathf.SmoothDampAngle(this.transform.eulerAngles.z, TargetAngle.z, ref Velocity, this.SmoothTime);

        this.transform.eulerAngles = new Vector3(tempX, tempY, tempZ);
        //this.transform.position = this.OriginPosition;
    }
}