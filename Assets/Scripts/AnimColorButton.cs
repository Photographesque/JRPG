using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimColorButton : MonoBehaviour
{
    private Color _colorBase;
    private Color _currentColor;
    public Color colorToChange;
    public float timeToChange;
    public float speedColor;

    private void Start()
    {
        _colorBase = GetComponent<Image>().color;
        _currentColor = _colorBase;
    }

    public void OnPointerEnter()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeColor(_currentColor, colorToChange));
    }

    public void OnPointerExit()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeColor(_currentColor, _colorBase));
    }

    IEnumerator ChangeColor(Color colorBase, Color newColor)
    {
        float elapsedTime = 0f;

        while (elapsedTime < timeToChange)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / timeToChange);
            Color lerpedColor = Color.Lerp(colorBase, newColor, t);
            GetComponent<Image>().color = lerpedColor;
            _currentColor = lerpedColor;
            yield return null;
        }
    }
}