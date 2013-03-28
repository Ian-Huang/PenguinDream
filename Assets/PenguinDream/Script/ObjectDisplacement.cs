using UnityEngine;
using System.Collections;

public class ObjectDisplacement : MonoBehaviour
{
    public float DisplacementValue;
    public float DisplacementSpeed;

    public float RotateAngle = 5;
    public float RotateSpeed = 1;
    private float rotateAddValue = 0;
    private Vector3 RotateVector3;

    private float displacementAddValue = 0;
    private Vector3 originV3;
    // Use this for initialization
    void Start()
    {
        this.originV3 = this.transform.position;
        this.RotateVector3 = new Vector3(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.displacementAddValue > this.DisplacementValue || this.displacementAddValue < -this.DisplacementValue)
        {
            this.DisplacementSpeed = -this.DisplacementSpeed;
        }
        this.displacementAddValue += this.DisplacementSpeed * Time.deltaTime;
        this.transform.position = new Vector3(this.originV3.x + this.displacementAddValue, this.originV3.y, this.originV3.z);

        if (this.rotateAddValue >= 360)
            this.rotateAddValue = 0;

        this.rotateAddValue += this.RotateSpeed;
        this.transform.rotation = Quaternion.EulerAngles(this.RotateVector3.x, RotateAngle * Mathf.Sin(((this.rotateAddValue * Mathf.PI) / 180.0f)) * Mathf.PI / 180.0f, this.RotateVector3.z);
    
    }
}
