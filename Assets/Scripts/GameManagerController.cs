using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] private UIManagerController uiManager;
    private int score;
    [SerializeField] private int secondIntervalIncrease;
    [SerializeField] private int scoreIncrement;
    private float timer = 0;

    private void Start()
    {
        uiManager.UpdateUIPoints(score);
    }

    private void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > secondIntervalIncrease)
        {
            score = score + scoreIncrement;
            uiManager.UpdateUIPoints(score);
            timer = 0;
        }
    }
}