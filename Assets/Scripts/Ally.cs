using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Ally : Character
{
    public SpriteRenderer sprite;
    public float TimeRedFlash;

    internal override void Attack(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        print(defender.GetType());
        if (defender.GetType() == typeof(Ally))
        {
            Debug.LogWarning("You should not hit your allies");
            return;
        }
        base.Attack(defender);
    }

    internal override void Hit(int damage)
    {
        print("hit");
        base.Hit(damage);
        CharacterAnimator.SetTrigger("hit");
        Life = Mathf.Clamp(Life - damage, 0, LifeMax);
        StartCoroutine(FlashRed());
    }

    public IEnumerator FlashRed()
    {
        float totalTime = TimeRedFlash;
        float elapsedTime = 0f;
        Color startColor = sprite.color;
        Color endColor = new Color(1f, 0f, 0f, startColor.a);

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / totalTime;
            //L
            Color lerpedColor = Color.Lerp(startColor, endColor, t);
            sprite.color = lerpedColor;
            yield return null;
        }
        // // Une fois l'animation terminée, assurez-vous que la couleur est réinitialisée à la couleur d'origine
        sprite.color = startColor;
    }
}
