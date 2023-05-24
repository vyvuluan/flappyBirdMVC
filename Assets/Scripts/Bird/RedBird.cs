using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBird : Bird
{
    private bool isCountDown = false;
    private IEnumerator dash()
    {
        base.setSpeed.Invoke(8f);
        yield return new WaitForSeconds(0.5f);
        base.gravitationalForce = 9.8f;
        base.setSpeed.Invoke(3f);
        StartCoroutine(Countdown());
    }
    private IEnumerator Countdown()
    {
        int countdownTime = 5;
        isCountDown = true;
        while (countdownTime > 0)
        {
            base.countDownSkill.Invoke(countdownTime.ToString());
            yield return new WaitForSeconds(1.0f);
            countdownTime--;
        }
        // end count down
        isCountDown = false;
        base.countDownSkill.Invoke(string.Empty);
    }

    public override void Skill()
    {
        if (!isCountDown)
        {
            base.imageCountDownSkillBlack.Invoke();
            base.checkSkill = true;
            base.gravitationalForce = 0;
            StartCoroutine(dash());
        }
    }
    private void Update()
    {
        if (isCountDown)
        {
            base.imageCountDownSkill.Invoke();
        }

    }
}
