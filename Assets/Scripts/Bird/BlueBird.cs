using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : Bird
{
    private bool isCountDown = false;

    IEnumerator slowPipe()
    {
        StartCoroutine(Countdown());
        base.setSpeed.Invoke(1.5f);
        yield return new WaitForSeconds(1f);
        base.setSpeed.Invoke(3f);
    }
    IEnumerator Countdown()
    {
        int countdownTime = 5;
        isCountDown = true;
        while (countdownTime > 0)
        {
            base.countDownSkill.Invoke(countdownTime.ToString());
            
            yield return new WaitForSeconds(1.0f);
            countdownTime--;

        }
        //end count down
        isCountDown = false;
        base.countDownSkill.Invoke(string.Empty);
    }
    private void Update()
    {
        if(isCountDown)
        {
            base.imageCountDownSkill.Invoke();
        }
        
    }

    public override void Skill()
    {
        if (!isCountDown)
        {
            base.imageCountDownSkillBlack.Invoke();
            StartCoroutine(slowPipe());
        }
    }
}
