using UnityEngine;
using System.Collections;

/// <summary>
/// ���Z�Y��+�ɶ�������
/// </summary>
public class PenguinGetTime : MonoBehaviour
{
    public GameObject AddTimetextObject;
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
            GameManager.AddScore();
            GameObject obj = (GameObject)Instantiate(this.AddTimetextObject);
            obj.GetComponent<DrawCustomText>().SetContent("+10 ��");

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
