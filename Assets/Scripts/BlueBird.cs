﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : MonoBehaviour, IBird
{
    private bool isCountDown = false;

    public void skill()
    {
        if (!isCountDown)
        {
            StartCoroutine(slowPipe());
        }
    }
    IEnumerator slowPipe()
    {
        StartCoroutine(Countdown());
        //GameObject[] pipeHolders = BirdTest.Instance.pipeHolder;
        //pipeHolders[0].GetComponent<PipeController>().speed = 1.5f;
        //pipeHolders[1].GetComponent<PipeController>().speed = 1.5f;
        yield return new WaitForSeconds(1f);
        //pipeHolders[0].GetComponent<PipeController>().speed = 3f;
        //pipeHolders[1].GetComponent<PipeController>().speed = 3f;
    }

    IEnumerator Countdown()
    {
        int countdownTime = 5;
        isCountDown = true;
        while (countdownTime > 0)
        {
            //BirdTest.Instance.countdownTextSlow.text = countdownTime.ToString();
            yield return new WaitForSeconds(1.0f);
            countdownTime--;

        }
        // Kết thúc count down
        isCountDown = false;
        //BirdTest.Instance.countdownTextSlow.text = "";
    }

}
