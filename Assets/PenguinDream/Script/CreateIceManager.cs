using UnityEngine;
using System.Collections;

public class CreateIceManager : MonoBehaviour
{
    public float CreateTimeTIterval = 3;
    private float addValue;
    private int currentLayout = -1;

    // Use this for initialization
    void Start()
    {
        this.addValue = this.CreateTimeTIterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.addValue < this.CreateTimeTIterval)
            this.addValue += Time.deltaTime;
        
        else
        {
            int random;
            do
            {
                random = Random.Range(0, 3);
            } while (random == this.currentLayout);
            this.currentLayout = random;

            switch ((GameDefinition.Layout)this.currentLayout)
            {
                case GameDefinition.Layout.Front:
                    GameObject.Find("Layout_Front").GetComponent<CreateIce>().CreateIceObject();
                    break;
                case GameDefinition.Layout.Center:
                    GameObject.Find("Layout_Center").GetComponent<CreateIce>().CreateIceObject();
                    break;
                case GameDefinition.Layout.Back:
                    GameObject.Find("Layout_Back").GetComponent<CreateIce>().CreateIceObject();
                    break;
            }            
            this.addValue = 0;
        }
    }
}