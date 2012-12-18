using UnityEngine;
using System.Collections;

public class FallingWaterSound : MonoBehaviour
{
    public AudioClip clip;    
    private GameSound gameSoundScript;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.transform.name == "ShootObjectGarbage")
        {
            this.gameSoundScript.PlaySound(this.clip);
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
