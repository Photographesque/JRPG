using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    public GameObject FXDeath;


    internal override void Attack(Character defender)
    {
        print($"{name} attack {defender.name}");
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
            Destroy(gameObject);
        }
    }

}
