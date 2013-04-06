using UnityEngine;
using System.Collections;

/// <summary>
/// 控制企鵝落水後產生的效果(落水聲、關閉尾勁、產生水花)
/// </summary>
public class FallingWater : MonoBehaviour
{
    public GameObject Watersplash;      //水花
    public AudioClip clip;              //落水的音效檔
    public GameObject SoundObject;
    public LayerMask PenguinLayer;

    private GameObject cloneSoundObject;
    private GameSound gameSoundScript;  //聲音播放的script

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & this.PenguinLayer.value) > 0)
        {
            this.gameSoundScript.PlaySound(this.clip);              //播放音效
            other.GetComponent<TrailRenderer>().enabled = false;    //關閉尾勁特效

            //產生水花
            Instantiate(this.Watersplash, other.transform.position, this.Watersplash.transform.rotation);
        }
    }

    void OnDestroy()
    {
        Destroy(this.cloneSoundObject);
    }


    // Use this for initialization
    void Start()
    {
        this.cloneSoundObject = (GameObject)Instantiate(this.SoundObject, this.transform.position, Quaternion.identity);
        this.gameSoundScript = this.cloneSoundObject.GetComponent<GameSound>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
