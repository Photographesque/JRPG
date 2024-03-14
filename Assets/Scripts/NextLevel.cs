using Spine.Unity;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public float AnimationSpeed, AnimationDistance;
    float _distance, _firstPositionY;

    private void Start()
    {
        _firstPositionY = transform.position.y;
    }

    void Update()
    {
        _distance = Mathf.Sin(Time.time * AnimationSpeed) * AnimationDistance;
        transform.position = new Vector3(transform.position.x, _firstPositionY + _distance, transform.position.z);
    }
}
