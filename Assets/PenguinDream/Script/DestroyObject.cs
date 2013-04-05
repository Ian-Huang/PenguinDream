using UnityEngine;
using System.Collections;

/// <summary>
/// //�R���i�J�d�򤺪����� (�p�G�O�����h�������Z�ͩR)
/// </summary>
public class DestroyObject : MonoBehaviour
{
    public bool isDeductionLife = false;
    public GameObject PenguinSoul;          //���Z���J�����A�X�{���Z�F��
    public AudioClip clip;                  //������������
    public GameObject SoundObject;

    private GameObject cloneSoundObject;
    private GameSound gameSoundScript;      //�n������script

    void OnTriggerEnter(Collider other)
    {
        //���p���J�����A��֥��Z�ͩR
        if (this.isDeductionLife)
        {
            GameManager.ComboCount = 0;
            GameManager.LoseLife();
            Instantiate(this.PenguinSoul);
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