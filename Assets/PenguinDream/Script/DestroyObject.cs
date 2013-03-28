using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour
{
    public bool isDeduction = false;
    private GameUI gameUIScript;

    void OnTriggerEnter(Collider other)
    {
        if (this.isDeduction)
            this.gameUIScript.LoseLife();

        Destroy(other.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        this.gameUIScript = GameObject.Find("GameUI").GetComponent<GameUI>();
    }
}