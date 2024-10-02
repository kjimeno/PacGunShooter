using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour
{
    [SerializeField] Text[] timerLabels;
    [SerializeField] GameOver gameOver;

    private float timer = 61f;

    const int MAX_NUM_DIGITS = 3;

    private void Update() {
        timer -= Time.deltaTime;

        if (timer < 0) {
            gameOver.GameIsOver();
            gameOver.enabled = true;
        }

        int numZerosPrior;

        if ((int)timer >= 10) {
            numZerosPrior = MAX_NUM_DIGITS - 2;
        } else {
            numZerosPrior = MAX_NUM_DIGITS - 1;
        }

        foreach (var label in timerLabels) {
            string newLabel = "";
        
            for (int i = 0; i < numZerosPrior; i++)
                newLabel += "0";

            newLabel += ((int)timer).ToString();
            label.text = newLabel;
        }
    }
}
