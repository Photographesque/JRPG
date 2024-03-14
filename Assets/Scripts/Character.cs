using System;
using UnityEngine;

[Serializable]
public class Character : MonoBehaviour
{
    public int LifeMax = 100;
    public int Life = 100;
    public Sprite SpritePortrait;
    public SpriteRenderer Visual;
    public Animator CharacterAnimator;
    public int NormalAttackDamage = 10;
    public Color CanAttackColor = Color.white;
    public Color StandByColor = Color.grey;
    private bool _hasAttackedThisTurnOrIsStuned = false;
    public float TimeShake;
    public float PowerShake;
    public Shake ShakeScript;
    public GameObject[] FX;
    public bool HasAttackedThisTurnOrIsStuned
    {
        get { return _hasAttackedThisTurnOrIsStuned; }
        set
        {
            _hasAttackedThisTurnOrIsStuned = value;
            Visual.color = _hasAttackedThisTurnOrIsStuned ? StandByColor : CanAttackColor;
        }
    }

    private void Start()
    {
        Life = LifeMax;
    }
    public bool isAlive()
    {
        return Life > 0;
    }
    virtual internal void Attack(Character defender)
    {
        print($"{name} is attacking {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("attack");

        TurnManager.Instance.HasAttacked(this);

        //quaternion identity permet de ne pas faire rotater l'objet
        if (FX.Length > 0) { Instantiate(FX[0], defender.transform.position, Quaternion.identity); }
        if(FX.Length > 1) {Instantiate(FX[1], gameObject.transform.position, Quaternion.identity); }
        
        Shaking(TimeShake, PowerShake);

        if (defender.GetType() == typeof(Ally))
        {
            ((Ally)defender).Hit(damage: NormalAttackDamage);
            if (FX.Length > 2) { Instantiate(FX[2], defender.transform.position, Quaternion.identity); }
        }
        else if (defender.GetType() == typeof(Enemy))
        {
            ((Enemy)defender).Hit(damage: NormalAttackDamage);
        }
    }
    virtual internal void Hit(int damage)
    {
        print($"{name} is hit and took {damage} damages");
    }



    public void Shaking(float TimeToShake, float Puissance)
    {
        StartCoroutine(ShakeScript.Shaking(TimeToShake, Puissance)); // Passer la position au lieu de la transformation
    }

}
