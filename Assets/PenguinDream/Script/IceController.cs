using UnityEngine;
using System.Collections;

/// <summary>
/// ����B�B������(���k)�B�H�ίB�B���}�B(�W�U)
/// </summary>
public class IceController : MonoBehaviour
{
    public float UpDownSpeed = 1;       //�}�B���t��
    public float UpDownDistance = 1;    //�}�B���Z���t

    private GameDefinition.Direction iceMoveDirection = GameDefinition.Direction.None;
    private float iceSpeed;
    private float addValue = 0;

    /// <summary>
    /// ���Z���W�B�B�᪺����
    /// </summary>
    /// <param name="_object"></param>
    void OnTriggerEnter(Collider _object)
    {
        if (_object.rigidbody != null)
        {
            _object.GetComponent<TrailRenderer>().enabled = false;      //�������l�S��
            GameUI gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
            gameUI.AddScore();

            _object.transform.parent = this.transform;

            _object.rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
    }

    /// <summary>
    /// �]�w�B�B���ݩ�
    /// </summary>
    /// <param name="speed">�B�B���ʳt��</param>
    /// <param name="direction">�B�B���ʪ���V</param>
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
        //����B�B���}�B
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

        // ����B�B������
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