using UnityEngine;
using System.Collections;

public class GameCalculate : MonoBehaviour
{
    public static int ComboCount { get; set; }

    public static int TotalScore;
    public static float TotalTime { get; set; }

    public static void AddScore()
    {
        if (ComboCount < 5)
            TotalScore += ComboCount * 5;

        else if (ComboCount < 10)
            TotalScore += ComboCount * 10;

        else if (ComboCount < 15)
            TotalScore += ComboCount * 15;

        else if (ComboCount < 20)
            TotalScore += ComboCount * 20;

        else if (ComboCount < 25)
            TotalScore += ComboCount * 25;

        else
            TotalScore += ComboCount * 30;

        //GameObject.Find("GameUI").GetComponent<GameUI>().TotalScore = TotalScore;
    }

    // Use this for initialization
    void Start()
    {
        ComboCount = 0;
        TotalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
