using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBird : MonoBehaviour, IBird
{
    private bool isCountDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skill()
    {
        if (!isCountDown)
        {
            Debug.Log("skill");
            //BirdTest.Instance.checkSkill = true;
            //BirdTest.Instance.gravitationalForce = 0;
            StartCoroutine(dash());
        }
    }
    IEnumerator dash()
    {
        //GameObject[] pipeHolders = BirdTest.Instance.pipeHolder;
        //pipeHolders[0].GetComponent<PipeController>().speed = 8f;
        //pipeHolders[1].GetComponent<PipeController>().speed = 8f;
        yield return new WaitForSeconds(0.25f);
        //pipeHolders[0].GetComponent<PipeController>().speed = 3f;
        //pipeHolders[1].GetComponent<PipeController>().speed = 3f;
        StartCoroutine(Countdown());
    }
    IEnumerator Countdown()
    {
        int countdownTime = 5;
        isCountDown = true;

        while (countdownTime > 0)
        {

            //BirdTest.Instance.countdownTextDash.text = countdownTime.ToString();
            yield return new WaitForSeconds(1.0f);
            countdownTime--;
        }

        // Kết thúc count down
        isCountDown = false;
        //BirdTest.Instance.countdownTextDash.text = "";
    }

}
