using UnityEngine;
using System.Collections;

public class GameSound : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(AudioClip clip)
    {
        this.audio.clip = clip;
        this.audio.Play();
    }
}