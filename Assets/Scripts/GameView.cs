using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private Image fillBarProgress;
    private float lastValue;


    void Update()
    {
        if (!GameManager.singleton.GameStarted)
            return;

        float travelDistance = GameManager.singleton.EntireDistance - GameManager.singleton.DistanceLeft;
        float value = travelDistance / GameManager.singleton.EntireDistance;

        if (GameManager.singleton.GameEnded && value < lastValue)
            return;

        fillBarProgress.fillAmount = Mathf.Lerp(fillBarProgress.fillAmount, value, 5 * Time.deltaTime);

        lastValue = value;
    }
}
