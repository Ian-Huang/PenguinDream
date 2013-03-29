using UnityEngine;
using System.Collections;

/// <summary>
/// 控制企鵝落水後產生的落水聲
/// </summary>
public class FallingWaterSound : MonoBehaviour
{
    public AudioClip clip;              //落水的音效檔
    private GameSound gameSoundScript;  //聲音播放的script

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.transform.name == "ShootObjectGarbage")
        {
            this.gameSoundScript.PlaySound(this.clip);              //播放音效
            other.GetComponent<TrailRenderer>().enabled = false;    //關閉尾勁特效
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
