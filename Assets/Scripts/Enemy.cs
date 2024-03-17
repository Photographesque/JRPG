using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Enemy : Character
{

    public GameObject FXDeath;
    public GameObject[] NextEnemy;
    //private int Number;
    public GameObject FinalDialogueBox;
    public GameObject BlackBorder;
    public FinalDialogue FINALDIALOGUE;

  

    internal override void Attack(Character defender)
    {
        
        if (HasAttackedThisTurnOrIsStuned) return;
        base.Attack(defender);
    }

    internal override void Hit(int damage)
    {
        base.Hit(damage);
        CharacterAnimator.SetTrigger("hit");
        Life = Mathf.Clamp(Life - damage, 0, LifeMax);
    }


    private void Update()
    {
        if (Life == 0)
        {

            Instantiate(FXDeath, gameObject.transform.position, Quaternion.identity);

            //Instantiate(NextEnemy, gameObject.transform.position, Quaternion.identity);

            if (NextEnemy.Length > 0)
            { NextEnemy[0].SetActive(true); }
            if (NextEnemy.Length > 1)
            { NextEnemy[1].SetActive(true); }

            //gameObject.SetActive(false);

            Destroy(gameObject);

            FINALDIALOGUE.NumberofEnemy += 1;

        }

       
    }

}
