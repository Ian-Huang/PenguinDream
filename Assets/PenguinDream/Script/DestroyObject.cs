using UnityEngine;
using System.Collections;

/// <summary>
/// //刪除進入範圍內的物件 (如果是海底則扣除企鵝生命)
/// </summary>
public class DestroyObject : MonoBehaviour
{
    public bool isDeductionLife = false;
    private GameUI gameUIScript;

    void OnTriggerEnter(Collider other)
    {
        //假如掉入海底，減少企鵝生命
        if (this.isDeductionLife)
        {
            GameCalculate.ComboCount = 0;
            this.gameUIScript.LoseLife();
        }
        //刪除進入範圍內的物件
        Destroy(other.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        this.gameUIScript = GameObject.Find("GameUI").GetComponent<GameUI>();
    }
}