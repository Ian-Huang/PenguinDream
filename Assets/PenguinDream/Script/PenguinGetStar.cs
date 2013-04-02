using UnityEngine;
using System.Collections;

/// <summary>
/// ���Z�Y��P�P������
/// </summary>
public class PenguinGetStar : MonoBehaviour
{
    public AudioClip SuccessSound;      //���\���W�h��������    
    public LayerMask PlayerLayer;       //�ĤH��Layer

    private GameSound gameSoundScript;  //�n������script

    /// <summary>
    /// ���Z�Y��P�P������
    /// </summary>
    /// <param name="_object"></param>
    void OnTriggerEnter(Collider _object)
    {
        if (((1 << _object.gameObject.layer) & this.PlayerLayer.value) > 0)
        {
            this.gameSoundScript.PlaySound(this.SuccessSound);          //���񭵮�

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
