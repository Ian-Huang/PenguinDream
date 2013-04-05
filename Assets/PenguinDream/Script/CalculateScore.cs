using UnityEngine;
using System.Collections;

/// <summary>
/// 結算成績-讓玩家看起來分數有逐漸增加的動畫
/// </summary>
public class CalculateScore : MonoBehaviour
{
    public GameManager.GameValue WhichValue;
    public float CalculateSpeed = 0.5f;

    private bool isStartCalculate = false;
    private int tempValue;

    // Use this for initialization
    void OnEnable()
    {
        switch (this.WhichValue)
        {
            case GameManager.GameValue.Star:
                this.tempValue = GameManager.TotalGetStar;
                GameManager.TotalGetStar = 0;
                break;

            case GameManager.GameValue.Score:
                this.tempValue = GameManager.TotalScore;
                GameManager.TotalScore = 0;
                break;

            default:
                break;
        }
        this.isStartCalculate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isStartCalculate)
        {
            switch (this.WhichValue)
            {
                case GameManager.GameValue.Star:
                    GameManager.TotalGetStar = (int)Mathf.Lerp(GameManager.TotalGetStar, this.tempValue, this.CalculateSpeed) + 1;
                    if (GameManager.TotalGetStar >= this.tempValue)
                    {
                        GameManager.TotalGetStar = this.tempValue;
                        this.isStartCalculate = false;
                    }
                    break;
                case GameManager.GameValue.Score:
                    GameManager.TotalScore = (int)Mathf.Lerp(GameManager.TotalScore, this.tempValue, this.CalculateSpeed) + 1;
                    if (GameManager.TotalScore >= this.tempValue)
                    {
                        GameManager.TotalScore = this.tempValue;
                        this.isStartCalculate = false;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}