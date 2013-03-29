using UnityEngine;
using System.Collections;

/// <summary>
/// 控制浮冰的移動(左右)、以及浮冰的漂浮(上下)
/// </summary>
public class IceController : MonoBehaviour
{
    public float UpDownSpeed = 1;       //漂浮的速度
    public float UpDownDistance = 1;    //漂浮的距離差

    private GameDefinition.Direction iceMoveDirection = GameDefinition.Direction.None;
    private float iceSpeed;
    private float addValue = 0;

    /// <summary>
    /// 企鵝跳上浮冰後的控制
    /// </summary>
    /// <param name="_object"></param>
    void OnTriggerEnter(Collider _object)
    {
        if (_object.rigidbody != null)
        {
            _object.GetComponent<TrailRenderer>().enabled = false;      //關閉尾勁特效
            GameUI gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
            gameUI.AddScore();

            _object.transform.parent = this.transform;

            _object.rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
    }

    /// <summary>
    /// 設定浮冰的屬性
    /// </summary>
    /// <param name="speed">浮冰移動速度</param>
    /// <param name="direction">浮冰移動的方向</param>
    public void SetIceAttributes(float speed, GameDefinition.Direction direction)
    {
        this.iceSpeed = speed;
        this.iceMoveDirection = direction;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //控制浮冰的漂浮
        if (this.addValue > this.UpDownDistance)
        {
            this.addValue = this.UpDownDistance;
            this.UpDownSpeed = -this.UpDownSpeed;
        }
        else if (this.addValue < -this.UpDownDistance)
        {
            this.addValue = -this.UpDownDistance;
            this.UpDownSpeed = -this.UpDownSpeed;
        }
        this.addValue += this.UpDownSpeed * Time.deltaTime;
        //------------------------------------------------

        // 控制浮冰的移動
        if (this.iceMoveDirection != GameDefinition.Direction.None)
        {
            if (this.iceMoveDirection == GameDefinition.Direction.LeftToRight)
                this.transform.position += ((Vector3.right * this.iceSpeed) + (Vector3.up * this.UpDownSpeed)) * Time.deltaTime;

            else
                this.transform.position -= ((Vector3.right * this.iceSpeed) + (Vector3.up * this.UpDownSpeed)) * Time.deltaTime;
        }
        //------------------------------------------------
    }
}