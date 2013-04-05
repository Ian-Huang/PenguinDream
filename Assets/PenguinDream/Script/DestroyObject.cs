using UnityEngine;
using System.Collections;

/// <summary>
/// //刪除進入範圍內的物件 (如果是海底則扣除企鵝生命)
/// </summary>
public class DestroyObject : MonoBehaviour
{
    public bool isDeductionLife = false;
    public GameObject PenguinSoul;          //企鵝掉入海底，出現企鵝靈魂
    public AudioClip clip;                  //落水的音效檔
    public GameObject SoundObject;

    private GameObject cloneSoundObject;
    private GameSound gameSoundScript;      //聲音播放的script

    void OnTriggerEnter(Collider other)
    {
        //假如掉入海底，減少企鵝生命
        if (this.isDeductionLife)
        {
            GameManager.ComboCount = 0;
            GameManager.LoseLife();
            Instantiate(this.PenguinSoul);
            this.gameSoundScript.PlaySound(this.clip);      //播放音效
        }
        //刪除進入範圍內的物件
        Destroy(other.gameObject);
    }

    void OnDestroy()
    {
        Destroy(this.cloneSoundObject);
    }

    // Use this for initialization
    void Start()
    {
        if (this.isDeductionLife)
        {
            this.cloneSoundObject = (GameObject)Instantiate(this.SoundObject, this.transform.position, Quaternion.identity);
            this.gameSoundScript = this.cloneSoundObject.GetComponent<GameSound>();
        }
    }
}