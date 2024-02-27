using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAfterDelay : MonoBehaviour
{
    public float delayInSeconds = 5f;
    public float fadeRate = 0.25f;

    private CanvasGroup canvasGroup;
    private float startTimer;
    private float fadeoutTimer;

    private void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1.0f;

        startTimer = Time.time + delayInSeconds;
        fadeoutTimer = fadeRate;
    }

    private void Update()
    {
        //time to fade out?
        if (Time.time >= startTimer)
        {
            fadeoutTimer -= Time.deltaTime;

            //fadeout complete?
            if (fadeoutTimer <= 0)
            {
                gameObject.SetActive(false);
            }

            else
            {
                //reduce the alpha value
                canvasGroup.alpha = fadeoutTimer / fadeRate;
            }
        }
    }
}
