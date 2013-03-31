using UnityEngine;
using System.Collections;

/// <summary>
/// 控制企鵝落水後產生的效果(落水聲、關閉尾勁、產生水花)
/// </summary>
public class FallingWater : MonoBehaviour
{
    public GameObject Watersplash;      //水花
    public AudioClip clip;              //落水的音效檔
    private GameSound gameSoundScript;  //聲音播放的script

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.transform.name == "ShootObjectGarbage")
        {
            this.gameSoundScript.PlaySound(this.clip);              //播放音效
            other.GetComponent<TrailRenderer>().enabled = false;    //關閉尾勁特效
            
            //產生水花
            Instantiate(this.Watersplash, other.transform.position, this.Watersplash.transform.rotation);
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
