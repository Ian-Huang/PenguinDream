using UnityEngine;
using System.Collections;

/// <summary>
/// 一定時間後，自動銷毀物件
/// </summary>
public class AutoDestroy : MonoBehaviour
{
    public float DestroyTime;       //經過n秒後，銷毀物件

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