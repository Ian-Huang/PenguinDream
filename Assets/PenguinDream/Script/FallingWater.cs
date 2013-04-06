using UnityEngine;
using System.Collections;

/// <summary>
/// ������Z�����Უ�ͪ��ĪG(�����n�B�������l�B���ͤ���)
/// </summary>
public class FallingWater : MonoBehaviour
{
    public GameObject Watersplash;      //����
    public AudioClip clip;              //������������
    public GameObject SoundObject;
    public LayerMask PenguinLayer;

    private GameObject cloneSoundObject;
    private GameSound gameSoundScript;  //�n������script

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & this.PenguinLayer.value) > 0)
        {
            this.gameSoundScript.PlaySound(this.clip);              //���񭵮�
            other.GetComponent<TrailRenderer>().enabled = false;    //�������l�S��

            //���ͤ���
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
