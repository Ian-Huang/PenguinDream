using UnityEngine;
using System.Collections;

/// <summary>
/// //�R���i�J�d�򤺪����� (�p�G�O�����h�������Z�ͩR)
/// </summary>
public class DestroyObject : MonoBehaviour
{
    public bool isDeductionLife = false;
    private GameUI gameUIScript;

    void OnTriggerEnter(Collider other)
    {
        //���p���J�����A��֥��Z�ͩR
        if (this.isDeductionLife)
        {
            GameCalculate.ComboCount = 0;
            this.gameUIScript.LoseLife();
        }
        //�R���i�J�d�򤺪�����
        Destroy(other.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        this.gameUIScript = GameObject.Find("GameUI").GetComponent<GameUI>();
    }
}