using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bird : MonoBehaviour
{
    private bool isAlive;
    private int score;
    protected float gravitationalForce;
    private float bounceForce;
    private float verticalVelocity;
    public Vector3 previousPosition;
    public Vector3 currentPosition;
    protected bool checkSkill;
    private Action<int> setTextScore;
    private Action playAudioDie;
    private Action playAudioFly;
    private Action playAudioPoint;
    private Action<int> enableGameOverPanel;
    protected Action<float> setSpeed;
    protected Action getBullet;
    protected Action<string> countDownSkill;
    protected Action imageCountDownSkillBlack;
    protected Action imageCountDownSkill;
    public void Initialized(float gravitationalForce, float bounceForce, Action<int> setTextScore, Action playAudioDie, Action playAudioFly, 
        Action playAudioPoint, Action<int> enableGameOverPanel, Action getBullet, Action<float> setSpeed, Action<string> countDownSkill, Action imageCountDownSkillBlack, Action imageCountDownSkill)
    {
        this.gravitationalForce = gravitationalForce;
        this.bounceForce = bounceForce;
        this.setTextScore = setTextScore;
        this.playAudioDie = playAudioDie;
        this.playAudioFly = playAudioFly;
        this.playAudioPoint = playAudioPoint;
        this.enableGameOverPanel = enableGameOverPanel;
        this.getBullet = getBullet;
        this.setSpeed = setSpeed;
        this.countDownSkill = countDownSkill;
        this.imageCountDownSkillBlack = imageCountDownSkillBlack;
        this.imageCountDownSkill = imageCountDownSkill;
    }
    private void Awake()
    {
        isAlive = true;
        checkSkill = false;
        score = 0;
    }

    public void BirdDie()
    {
        if (isAlive)
        {
            isAlive = false;
            enableGameOverPanel.Invoke(score);
            playAudioDie.Invoke();
            Time.timeScale = 0;
        }
    }
    public void Tap()
    {
        verticalVelocity = bounceForce;
        playAudioFly.Invoke();
    }    
    public void BirdFly()
    {
        if (!isAlive) return;
        currentPosition =  transform.position;
        Vector3 previousFramePosition = previousPosition;
        verticalVelocity -= gravitationalForce * Time.deltaTime;
        if ( transform.position.y > -4.0f)
        {
            Vector3 newPosition =  transform.position + Vector3.up * verticalVelocity * Time.deltaTime;
            newPosition.x =  transform.position.x;
             transform.position = newPosition;
        }
        if ( transform.position.y < -4.0f)
        {
            BirdDie();
        }
        BirdRotation(currentPosition, previousFramePosition);
        previousPosition = currentPosition;
    }
    public void BirdRotation (Vector3 currentPosition, Vector3 previousFramePosition)
    {
        if (previousFramePosition.y < currentPosition.y)
        {
            float angel = Mathf.Lerp(0, 90, verticalVelocity / 10);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else
        {
            float angel = Mathf.Lerp(0, -90, -verticalVelocity / 10);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }    
    public bool CheckColliderBirdAndPipe(GameObject pipe)
    {
        Transform child1 = pipe.transform.GetChild(0);
        Transform child2 = pipe.transform.GetChild(1);
        Renderer objectRenderer1 = child1.GetComponent<Renderer>();
        Renderer objectRenderer2 = child2.GetComponent<Renderer>();
        //pipe bottom
        Vector3 objectBoundsMin = objectRenderer1.bounds.min;
        Vector3 objectBoundsMax = objectRenderer1.bounds.max;
        //pipe top
        Vector3 objectBoundsMin1 = objectRenderer2.bounds.min;
        if (transform.position.x > objectBoundsMin.x && transform.position.x < objectBoundsMax.x)
        {
            if (transform.position.y <= objectBoundsMax.y && !checkSkill || transform.position.y >= objectBoundsMin1.y && !checkSkill)
            {
                BirdDie();
            }
            if (transform.position.y > objectBoundsMax.y && transform.position.y < objectBoundsMin1.y)
            {
                score++;
                playAudioPoint.Invoke();
                setTextScore.Invoke(score);
                return true;
            }
            else if (checkSkill == true)
            {
                score++;
                playAudioPoint.Invoke();
                setTextScore.Invoke(score);
                checkSkill = false;
                return true;
            }
        }
        return false;
    }    
    public abstract void Skill();

}
