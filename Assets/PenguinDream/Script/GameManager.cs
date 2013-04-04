using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameObject UIMenu_Title { get; set; }
    public static GameObject UIMenu_Maker { get; set; }

    public static int ComboCount { get; set; }
    public static int TotalScore { get; set; }
    public static float TotalTime { get; set; }
    public static float WidthOffset { get; set; }
    public static float HeightOffset { get; set; }
    public static GameState gameState { get; set; }

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
    
    public static void UIButtonClick(UIChoose choose)
    {
        switch (choose)
        {
            case UIChoose.Nothing:
                break;
            case UIChoose.StartGame:
                UIMenu_Title.SetActive(false);
                GameObject.Find("GameUI").GetComponent<GameUI>().isStartGame = true;
                break;
            case UIChoose.Maker:
                UIMenu_Title.SetActive(false);
                UIMenu_Maker.SetActive(true);
                break;
            case UIChoose.MakerCancel:
                UIMenu_Maker.SetActive(false);
                UIMenu_Title.SetActive(true);                
                break;
            case UIChoose.ExitGame:
                Application.Quit();
                break;
            default:
                break;
        }
    }

    // Use this for initialization
    void Start()
    {
        ComboCount = 0;
        TotalScore = 0;
        gameState = GameState.Menu;
        UIMenu_Title = GameObject.Find("Menu-Title");
        UIMenu_Maker = GameObject.Find("Menu-Maker");
        UIMenu_Maker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WidthOffset = (float)Screen.width / 1280.0f;
        HeightOffset = (float)Screen.height / 720.0f;
    }

    #region Enum Define
    public enum Direction
    {
        None, RightToLeft, LeftToRight
    }

    public enum Layout
    {
        Front = 0,
        Center,
        Back
    }

    public enum GameState
    {
        Menu, Game, CalculateScore
    }

    public enum UIChoose
    {
        Nothing,
        StartGame,
        Maker, MakerCancel,
        ExitGame
    }
    #endregion

}
