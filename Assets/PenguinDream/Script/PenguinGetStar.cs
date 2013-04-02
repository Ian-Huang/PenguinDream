using UnityEngine;
using System.Collections;

/// <summary>
/// 企鵝吃到星星的控制
/// </summary>
public class PenguinGetStar : MonoBehaviour
{
    public AudioClip SuccessSound;      //成功跳上去的音效檔    
    public LayerMask PlayerLayer;       //敵人的Layer

    private GameSound gameSoundScript;  //聲音播放的script

    /// <summary>
    /// 企鵝吃到星星的控制
    /// </summary>
    /// <param name="_object"></param>
    void OnTriggerEnter(Collider _object)
    {
        if (((1 << _object.gameObject.layer) & this.PlayerLayer.value) > 0)
        {
            this.gameSoundScript.PlaySound(this.SuccessSound);          //播放音效

            GameUI gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
            gameUI.AddScore();

            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        this.gameSoundScript = GameObject.Find("GameSound").GetComponent<GameSound>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
