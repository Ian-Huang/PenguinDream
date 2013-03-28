using UnityEngine;
using System.Collections;

public class IceAngleReturn : MonoBehaviour
{
    private Vector3 OriginPosition;
    private float Velocity;

    public Vector3 Target = new Vector3(0, 180, 0);    
    public float SmoothTime = 0.1f;
    private float addValue;
    public float speed = 0.05f;

    // Use this for initialization
    void Start()
    {
        this.OriginPosition = this.transform.position;
    }    

    // Update is called once per frame
    void Update()
    {
        //if (addValue < 360)
        //{
        //    this.Target.y = this.addValue;
        //    this.addValue += this.speed;
        //}
        //else
        //{
        //    this.Target.y = this.addValue;
        //    this.addValue = 0;
        //}

        float tempX = Mathf.SmoothDampAngle(this.transform.eulerAngles.x, Target.x, ref Velocity, this.SmoothTime);
        float tempY = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, Target.y, ref Velocity, this.SmoothTime);
        float tempZ = Mathf.SmoothDampAngle(this.transform.eulerAngles.z, Target.z, ref Velocity, this.SmoothTime);

        this.transform.eulerAngles = new Vector3(tempX, tempY, tempZ);
        this.transform.position = this.OriginPosition;
    }
}