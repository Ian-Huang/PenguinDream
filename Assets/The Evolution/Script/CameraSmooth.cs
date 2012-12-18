using UnityEngine;
using System.Collections;

public class CameraSmooth : MonoBehaviour
{

    public GameObject Target;
    public float SmoothTime = 0.1f;
    private float Velocity;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            float tempPX = Mathf.SmoothDamp(this.transform.position.x, Target.transform.position.x, ref Velocity, this.SmoothTime);
            float tempPY = Mathf.SmoothDamp(this.transform.position.y, Target.transform.position.y, ref Velocity, this.SmoothTime);
            float tempPZ = Mathf.SmoothDamp(this.transform.position.z, Target.transform.position.z, ref Velocity, this.SmoothTime);

            this.transform.position = new Vector3(tempPX, tempPY, tempPZ);

            float tempAX = Mathf.SmoothDampAngle(this.transform.eulerAngles.x, Target.transform.eulerAngles.x, ref Velocity, this.SmoothTime);
            float tempAY = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, Target.transform.eulerAngles.y, ref Velocity, this.SmoothTime);
            float tempAZ = Mathf.SmoothDampAngle(this.transform.eulerAngles.z, Target.transform.eulerAngles.z, ref Velocity, this.SmoothTime);

            this.transform.eulerAngles = new Vector3(tempAX, tempAY, tempAZ);
        }
    }
}
