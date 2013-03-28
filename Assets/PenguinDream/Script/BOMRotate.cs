using UnityEngine;
using System.Collections;

public class BOMRotate : MonoBehaviour
{
    public float RotateAngle = 5;
    public float RotateSpeed = 1;

    private float addValue = 0;
    private Vector3 RotateVector3;

    // Use this for initialization
    void Start()
    {
        this.RotateVector3 = new Vector3(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.addValue >= 360)
            this.addValue = 0;

        this.addValue += this.RotateSpeed;

        this.transform.rotation = Quaternion.EulerAngles(this.RotateVector3.x, RotateAngle * Mathf.Sin(((this.addValue * Mathf.PI) / 180.0f)) * Mathf.PI / 180.0f, this.RotateVector3.z);
    }
}