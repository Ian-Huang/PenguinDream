using UnityEngine;
using System.Collections;

public class IceController : MonoBehaviour
{
    private GameDefinition.Direction direction = GameDefinition.Direction.None;
    private float speed;

    public float UpDownSpeed = 1;
    public float UpDownDistance = 1;

    private float addValue = 0;
    private Vector3 originV3;

    //void OnCollisionEnter(Collision _object)
    //{
    //    //print("impact = " + _object.impactForceSum);
    //    //print("friction = " + _object.rigidbody.velocity);
    //    GameUI gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
    //    gameUI.TotalScore++;

    //    _object.transform.parent = this.transform;
    //    _object.rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    //    //_object.rigidbody.isKinematic = true;

        
    //}
    void OnTriggerEnter(Collider _object)
    {
        if (_object.rigidbody != null)
        {
            _object.GetComponent<TrailRenderer>().enabled = false;
            GameUI gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
            gameUI.AddScore();

            _object.transform.parent = this.transform;

            _object.rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
    }

    public void SetValue(float speed, GameDefinition.Direction direction)
    {
        this.speed = speed;
        this.direction = direction;
    }

    void Start()
    {
        this.originV3 = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.addValue > this.UpDownDistance)
        {
            this.addValue = this.UpDownDistance;
            this.UpDownSpeed = -this.UpDownSpeed;
        }
        else if(this.addValue < -this.UpDownDistance)
        {
            this.addValue = -this.UpDownDistance;
            this.UpDownSpeed = -this.UpDownSpeed;
        }
        this.addValue += this.UpDownSpeed * Time.deltaTime;

        if (this.direction != GameDefinition.Direction.None)
        {
            if (this.direction == GameDefinition.Direction.LeftToRight)
                this.transform.position += ((Vector3.right * this.speed) + (Vector3.up * this.UpDownSpeed)) * Time.deltaTime;

            else
                this.transform.position -= ((Vector3.right * this.speed) + (Vector3.up * this.UpDownSpeed)) * Time.deltaTime;

        }
    }
}