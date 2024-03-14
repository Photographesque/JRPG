using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDialogue : MonoBehaviour
{

    public float NumberofEnemy = 0;
    public GameObject FinalDialogueBox;
    public GameObject BlackBorder;
    public GameObject[] NextEnemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (NumberofEnemy == 3)
        {
            NextEnemy[0].SetActive(true);
            NextEnemy[1].SetActive(true);
        }

        if (NumberofEnemy == 5)
        {
            FinalDialogueBox.SetActive(true);
            BlackBorder.SetActive(true);
        }

     

    }
}
