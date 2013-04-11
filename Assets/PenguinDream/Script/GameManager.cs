using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int totalLife;
    public float totalTime;

    public static GameObject UIMenu_Title { get; set; }
    public static GameObject UIMenu_Maker { get; set; }
    public static GameObject GameUI { get; set; }
    public static GameObject ResultUI { get; set; }

    public static float TotalTime { get; set; }
    public static int TotalLife { get; set; }
    public static int TotalGetStar { get; set; }

    public static int ComboCount { get; set; }
    public static int TotalScore { get; set; }
    public static int HighScore { get; set; }

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
    }

    public static void UIButtonClick(UIButtonEvent choose)
    {
        switch (choose)
        {
            case UIButtonEvent.Nothing:
                break;

            case UIButtonEvent.StartGame:
                UIMenu_Title.SetActive(false);
                GameUI.SetActive(true);
                gameState = GameState.Game;
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

    public static int GetGameValue(GameValue value)
    {
        switch (value)
        {
            case GameValue.Time:
                return Mathf.FloorToInt(TotalTime);

            case GameValue.Star:
                return TotalGetStar;

            case GameValue.Score:
                return TotalScore;

            case GameValue.HighScore:
                return HighScore;
        }
        return 0;
    }

    public static void LoseLife(int life = 1)
    {
        TotalLife -= life;
        if (TotalLife == 0)
            gameState = GameState.CalculateScore;
    }

    public static void AddTime(int time = 10)
    {
        TotalTime += time;
    }


    void Awake()
    {
        TotalLife = this.totalLife;
        TotalTime = this.totalTime + 1;
    }

    // Use this for initialization
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        ComboCount = 0;
        TotalScore = 0;
        TotalGetStar = 0;
        gameState = GameState.Menu;
        UIMenu_Title = GameObject.Find("Menu-Title");
        UIMenu_Maker = GameObject.Find("Menu-Maker");
        GameUI = GameObject.Find("GameUI");
        ResultUI = GameObject.Find("ResultUI");
        UIMenu_Maker.SetActive(false);
        GameUI.SetActive(false);
        ResultUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
            Application.LoadLevel(Application.loadedLevelName);

        WidthOffset = (float)Screen.width / 1280.0f;
        HeightOffset = (float)Screen.height / 720.0f;

        switch (gameState)
        {
            case GameState.Menu:
                break;

            case GameState.Game:
                if (TotalTime > 3)
                    TotalTime -= Time.deltaTime;
                else if (TotalTime >= 0)
                {
                    TotalTime -= Time.deltaTime;
                }
                else
                    gameState = GameState.CalculateScore;
                break;

            case GameState.CalculateScore:
                if (!ResultUI.activeSelf)
                {
                    GameUI.SetActive(false);
                    ResultUI.SetActive(true);
                }
                break;

            default:
                break;
        }
    }

    #region Enum Define
    public enum Direction
    {
        None,
        RightToLeft,
        LeftToRight
    }

    public enum Layout
    {
        Front = 0,
        Center,
        Back
    }

    public enum FallingLayout
    {
        None,
        Front,
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

    public enum GameValue
    {
        Time,
        Star, Score,
        HighScore
    }

    public enum UITextPattern
    {
        ShadowAndOutline,
        Shadow,
        Outline
    }
    #endregion

}
