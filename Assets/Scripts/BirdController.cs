using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private bool isAlive;
    [SerializeField] private PipeSpawner pipeSpawner;
    private int score;
    private float gravitationalForce;
    private float bounceForce;
    private float verticalVelocity;

    private GameObject birdGameObject;
    public Vector3 previousPosition;
    public Vector3 currentPosition;

    private List<GameObject> pipePool;
    public bool checkSkill;
    private bool checkPoint;
    private Action<int> setTextScore;
    private Action playAudioDie;
    private Action playAudioFly;
    private Action playAudioPoint;
    private Action<int> enableGameOverPanel;
    private IBird ibird;
    private const string highScore = "high score";
    private Action getBullet;

    public void InitializedListPipePool(List<GameObject> pipePool)
    {
        this.pipePool = pipePool;
       
    }
    public void Initialized(float gravitationalForce, float bounceForce, Action<int> setTextScore, 
        Action playAudioDie, Action playAudioFly, Action playAudioPoint, Action<int> enableGameOverPanel, Action getBullet, GameObject birdGameObject)
    {
        this.gravitationalForce = gravitationalForce;
        this.bounceForce = bounceForce;
        this.setTextScore = setTextScore;
        this.playAudioDie = playAudioDie;
        this.playAudioFly = playAudioFly;
        this.playAudioPoint = playAudioPoint;
        this.enableGameOverPanel = enableGameOverPanel;
        this.getBullet = getBullet;
        this.birdGameObject = birdGameObject;
    }
    private void Awake()
    {
        isAlive = true;
        checkSkill = false;
        score = 0;
        PlayerPrefs.SetInt(highScore, 0);
    }
    void Start()
    {
        //birdGameObject = Instantiate(yellowBird, yellowBird.transform.position, Quaternion.identity);
        ibird = birdGameObject.GetComponent<IBird>();
        if (ibird is YellowBird yellowBirdInstance)
        {
            yellowBirdInstance.Initialized(getBullet);
        }
    }
    void Update()
    {
        BirdFly();
        CheckColliderBirdAndPipe();
        useSkill();
    }
       
    public void BirdDie()
    {
        if (isAlive)
        {
            isAlive = false;
            Destroy(pipeSpawner);
            enableGameOverPanel.Invoke(score);
            playAudioDie.Invoke();
            Time.timeScale = 0;

        }
    }
    public void BirdFly()
    {
        if (!isAlive) return;
        currentPosition = birdGameObject.transform.position;
        Vector3 previousFramePosition = previousPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = bounceForce;
            playAudioFly.Invoke();
        }
        verticalVelocity -= gravitationalForce * Time.deltaTime;
        if (birdGameObject.transform.position.y > -4.0f)
        {
            Vector3 newPosition = birdGameObject.transform.position + Vector3.up * verticalVelocity * Time.deltaTime;
            newPosition.x = birdGameObject.transform.position.x;
            birdGameObject.transform.position = newPosition;
        }
        if (birdGameObject.transform.position.y < -4.0f)
        {
            BirdDie();
        }
        if (previousFramePosition.y < currentPosition.y)
        {
            float angel = Mathf.Lerp(0, 90, verticalVelocity / 10);
            birdGameObject.transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else
        {
            float angel = Mathf.Lerp(0, -90, -verticalVelocity / 10);
            birdGameObject.transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        previousPosition = currentPosition;
    }
    public void CheckColliderBirdAndPipe()
    {

        float distanceFromBirdToPipe1 = Mathf.Abs(birdGameObject.transform.position.x - pipePool[0].transform.position.x);
        float distanceFromBirdToPipe2 = Mathf.Abs(birdGameObject.transform.position.x - pipePool[1].transform.position.x);
        Transform child1;
        Transform child2;
        if (distanceFromBirdToPipe1 < distanceFromBirdToPipe2)
        {
            child1 = pipePool[0].transform.GetChild(0);
            child2 = pipePool[0].transform.GetChild(1);
        }
        else
        {
            child1 = pipePool[1].transform.GetChild(0);
            child2 = pipePool[1].transform.GetChild(1);
        }
        Renderer objectRenderer1 = child1.GetComponent<Renderer>();
        Renderer objectRenderer2 = child2.GetComponent<Renderer>();
        //pipe bottom
        Vector3 objectBoundsMin = objectRenderer1.bounds.min;
        Vector3 objectBoundsMax = objectRenderer1.bounds.max;
        //pipe top
        Vector3 objectBoundsMin1 = objectRenderer2.bounds.min;
        Debug.Log(objectBoundsMax.y);
        if (birdGameObject.transform.position.x > objectBoundsMin.x && birdGameObject.transform.position.x < objectBoundsMax.x)
        {
            Debug.Log(checkSkill);
            if (birdGameObject.transform.position.y <= objectBoundsMax.y && !checkSkill || birdGameObject.transform.position.y >= objectBoundsMin1.y && !checkSkill)
            {
                BirdDie();
            }
            if (birdGameObject.transform.position.y > objectBoundsMax.y && birdGameObject.transform.position.y < objectBoundsMin1.y && checkPoint == false)
            {
                checkPoint = true;
                score++;
                playAudioPoint.Invoke();
                setTextScore.Invoke(score);
                //IncreaseScore();
            }
            else if (checkPoint == false && checkSkill == true)
            {
                checkPoint = true;
                score++;
                playAudioPoint.Invoke();
                setTextScore.Invoke(score);
                //IncreaseScore();
            }
        }
        if (birdGameObject.transform.position.x > objectBoundsMax.x)
        {
            checkPoint = false;
            checkSkill = false;
            gravitationalForce = 9.8f;
        }
    }
    public void useSkill()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            ibird.skill();
        }    
    }    
}
