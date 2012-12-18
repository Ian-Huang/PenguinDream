using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour
{
    public Texture StartGameTexture;
    public Texture GameOverTexture;

    public float lifeTextureScale = 1;
    public Texture LifeTexture;
    public Texture[] NumberTexture;

    public int TotalLife = 5;

    public bool isStartGame = false;
    public bool isGameOver = false;
    

    public float TotalTime = 90;
    private int TimeTendigit = 0;
    private int TimeSingledigits = 0;

    public float TotalScore = 0;    
    private int ScoreTendigit = 0;
    private int ScoreSingledigits = 0;

    private float widthOffset;
    private float heightOffset;

    // Use this for initialization
    void Start()
    {
        this.ScoreTendigit = (int)this.TotalScore / 10;
        this.ScoreSingledigits = (int)this.TotalScore % 10;

        this.TimeTendigit = (int)this.TotalTime / 10;
        this.TimeSingledigits = (int)this.TotalTime % 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isStartGame)
        {
            if (this.TotalTime >= 0)
            {
                this.TotalTime -= Time.deltaTime;
                this.TimeTendigit = (int)this.TotalTime / 10;
                this.TimeSingledigits = (int)this.TotalTime % 10;
            }
            else
                this.isGameOver = true;
        }

        this.widthOffset = (float)Screen.width / 1280.0f;
        this.heightOffset = (float)Screen.height / 720.0f;

        if(Input.GetKeyUp(KeyCode.Q))
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            this.isStartGame = true;
        }
    }

    void OnGUI()
    {
        if (this.isStartGame)
        {
            if (!this.isGameOver)
            {
                this.LifeGUI();
                this.ScoreGUI();
                this.TimeGUI();
            }
            else
            {
                if (this.GameOverTexture != null)
                    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), this.GameOverTexture, ScaleMode.StretchToFill);
            }
        }
        else
            if (this.StartGameTexture != null)
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), this.StartGameTexture, ScaleMode.StretchToFill);
    }

    void LifeGUI()
    {
        for (int i = 1; i <= this.TotalLife; i++)
        {
            GUI.DrawTexture(new Rect(
                (1280 - 10 - (LifeTexture.width * this.lifeTextureScale) * i) * this.widthOffset,
                13 * this.heightOffset,
                this.LifeTexture.width * this.lifeTextureScale * this.widthOffset,
                this.LifeTexture.height * this.lifeTextureScale * this.heightOffset),
                this.LifeTexture,
                ScaleMode.StretchToFill);
        }
    }

    void TimeGUI()
    {
        GUI.DrawTexture(new Rect(
            173 * this.widthOffset,
            13 * this.heightOffset,
            this.NumberTexture[this.TimeTendigit].width * this.widthOffset,
            this.NumberTexture[this.TimeTendigit].height * this.heightOffset),
            this.NumberTexture[this.TimeTendigit],
            ScaleMode.StretchToFill);

        GUI.DrawTexture(new Rect(
            245 * this.widthOffset,
            13 * this.heightOffset,
            this.NumberTexture[this.TimeSingledigits].width * this.widthOffset,
            this.NumberTexture[this.TimeSingledigits].height * this.heightOffset),
            this.NumberTexture[this.TimeSingledigits],
            ScaleMode.StretchToFill);
    }

    void ScoreGUI()
    {
        GUI.DrawTexture(new Rect(
            573 * this.widthOffset,
            13 * this.heightOffset,
            this.NumberTexture[this.ScoreTendigit].width * this.widthOffset,
            this.NumberTexture[this.ScoreTendigit].height * this.heightOffset),
            this.NumberTexture[this.ScoreTendigit],
            ScaleMode.StretchToFill);

        GUI.DrawTexture(new Rect(
            645 * this.widthOffset,
            13 * this.heightOffset,
            this.NumberTexture[this.ScoreSingledigits].width * this.widthOffset,
            this.NumberTexture[this.ScoreSingledigits].height * this.heightOffset),
            this.NumberTexture[this.ScoreSingledigits],
            ScaleMode.StretchToFill);
    }

    public void AddScore(int score = 1)
    {
        this.TotalScore += score;
        this.ScoreTendigit = (int)this.TotalScore / 10;
        this.ScoreSingledigits = (int)this.TotalScore % 10;
    }

    public void LoseLife(int life = 1)
    {
        this.TotalLife -= life;
        if (this.TotalLife == 0)
            this.isGameOver = true;
    }
}
