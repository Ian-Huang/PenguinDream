using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int totalLife;
    public int totalTime;

    public static GameObject UIMenu_Title { get; set; }
    public static GameObject UIMenu_Maker { get; set; }

    public static int TotalTime { get; set; }
    public static int TotalLife { get; set; }
    public static float TotalGetStar { get; set; }

    public static int ComboCount { get; set; }
    public static int TotalScore { get; set; }
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

    public static void UIButtonClick(UIButtonEvent choose)
    {
        switch (choose)
        {
            case UIButtonEvent.Nothing:
                break;
            case UIButtonEvent.StartGame:
                UIMenu_Title.SetActive(false);
                GameObject.Find("GameUI").GetComponent<GameUI>().isStartGame = true;
                break;
            case UIButtonEvent.Maker:
                UIMenu_Title.SetActive(false);
                UIMenu_Maker.SetActive(true);
                break;
            case UIButtonEvent.MakerBack:
                UIMenu_Maker.SetActive(false);
                UIMenu_Title.SetActive(true);
                break;
            case UIButtonEvent.ExitGame:
                Application.Quit();
                break;
            case UIButtonEvent.ResultBack:
                Application.LoadLevel(Application.loadedLevel);
                break;
            default:
                break;
        }
    }


    void Awake()
    {
        TotalLife = this.totalLife;
        TotalTime = this.totalTime;
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

    public enum UIButtonEvent
    {
        Nothing,
        StartGame,
        Maker, MakerBack,
        ExitGame,
        ResultBack
    }

    public enum UITextPattern
    {
        ShadowAndOutline, Shadow, Outline
    }
    #endregion

}
