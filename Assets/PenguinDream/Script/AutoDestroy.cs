using UnityEngine;
using System.Collections;

/// <summary>
/// �@�w�ɶ���A�۰ʾP������
/// </summary>
public class AutoDestroy : MonoBehaviour
{
    public float DestroyTime;       //�g�Ln���A�P������

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.DestroyTime -= Time.deltaTime;

        if (this.DestroyTime < 0.0)
        {
            Destroy(this.gameObject);
        }
    }
}