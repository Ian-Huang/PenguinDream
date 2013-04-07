using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// //�R���i�J�d�򤺪����� (�p�G�O�����h�������Z�ͩR)
/// </summary>
public class DestroyOutObject : MonoBehaviour
{
    public bool isDeductionLife = false;
    //public GameObject PenguinSoul;          //���Z���J�����A�X�{���Z�F��
    public AudioClip clip;                  //������������
    public GameObject SoundObject;

    public GameObject FrontSoul;        //���Z���J�����A�X�{���Z�F��(�e)
    public GameObject CenterSoul;       //���Z���J�����A�X�{���Z�F��(��)
    public GameObject BackSoul;         //���Z���J�����A�X�{���Z�F��(��)
    public static List<GameManager.FallingLayout> PenguinFallingList = new List<GameManager.FallingLayout>();
    
    private GameObject cloneSoundObject;
    private GameSound gameSoundScript;      //�n������script

    void OnTriggerEnter(Collider other)
    {
        //���p���J�����A��֥��Z�ͩR
        if (this.isDeductionLife)
        {
            GameManager.ComboCount = 0;
            GameManager.LoseLife();
            switch (PenguinFallingList[0])
            {               
                case GameManager.FallingLayout.Front:
                    Instantiate(this.FrontSoul,this.FrontSoul.transform.position,this.FrontSoul.transform.rotation);
                    break;
                case GameManager.FallingLayout.Center:
                    Instantiate(this.CenterSoul, this.CenterSoul.transform.position, this.CenterSoul.transform.rotation);
                    break;
                case GameManager.FallingLayout.Back:
                    Instantiate(this.BackSoul, this.BackSoul.transform.position, this.BackSoul.transform.rotation);
                    break;
                default:
                    break;
            }
            PenguinFallingList.RemoveAt(0);
            //Instantiate(this.PenguinSoul);
            this.gameSoundScript.PlaySound(this.clip);      //���񭵮�
        }
        //�R���i�J�d�򤺪�����
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