using UnityEngine;
using System.Collections;

/// <summary>
/// ���Z�Y��+�ɶ�������
/// </summary>
public class PenguinGetTime : MonoBehaviour
{
    public GameObject CombotextObject;
    public AudioClip SuccessSound;      //���\���W�h��������    
    public LayerMask PlayerLayer;       //�ĤH��Layer

    private GameSound gameSoundScript;  //�n������script

    /// <summary>
    /// ���Z�Y��+�ɶ�������
    /// </summary>
    /// <param name="_object"></param>
    void OnTriggerEnter(Collider _object)
    {
        if (((1 << _object.gameObject.layer) & this.PlayerLayer.value) > 0)
        {
            this.gameSoundScript.PlaySound(this.SuccessSound);          //���񭵮�

            GameManager.AddTime();
            GameManager.ComboCount++;
            GameManager.AddScore();
            GameObject obj = (GameObject)Instantiate(this.CombotextObject);
            obj.GetComponent<DrawCustomText>().SetContent("Combo " + GameManager.ComboCount.ToString());

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
