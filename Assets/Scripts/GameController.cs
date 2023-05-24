using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [System.Serializable]
    public class BirdInfo
    {
        public ColorBird BirdType;
        public GameObject BirdPrefab;
    }

    [Header("MVC")]
    [SerializeField] private GameConfig model;
    [SerializeField] private GameView view;
    [SerializeField] private Audio audioGame;

    [Header("Preference")]
    [SerializeField] private PipeSpawner pipeSpawner;
    [SerializeField] private BulletSpawner bulletSpawner;
    [SerializeField] private BirdSpawner birdSpawner;

    [SerializeField] private List<BirdInfo> birds;
    private Bird bird;
    private const string textColorBird = "color bird";
    private GameObject gameObjectBird;
    private int index;
    private void Awake()
    {
        index = 0;
        GameObject receiveBirdType = GameObject.FindGameObjectWithTag("Param");
        if(receiveBirdType != null)
        {
            Parameters parameters = receiveBirdType.GetComponent<Parameters>();
            PlayerPrefs.SetInt(textColorBird,(int) parameters.BirdType);
            Destroy(receiveBirdType);
        }
        foreach (BirdInfo birdInfo in birds)
        {
            if (PlayerPrefs.GetInt(textColorBird) == (int) birdInfo.BirdType)
            {
                gameObjectBird = birdSpawner.choseBird(birdInfo.BirdPrefab);
                Destroy(receiveBirdType);
                break;
            }
        }
        bird = gameObjectBird.GetComponent<Bird>();
        pipeSpawner.Initialized(model.speed, model.pipePoolSize, model.pipeSpacing);
        bulletSpawner.Initialized(model.poolBulletSize, model.bulletSpeed);
        bird.Initialized(model.gravitationalForce, model.bounceForce, view.SetTextScore, audioGame.AudioDie, 
            audioGame.AudioFly, audioGame.AudioPoint, view.EnableGameOverPanel, bulletSpawner.getBullet, pipeSpawner.ChangeSpeedPipes, view.CountDownSkill, view.ImageCountDownSkillBlack, view.ImageCountDownSkill);

    }
    // Update is called once per frame
    void Update()
    {
        bulletSpawner.InitializedPositionBird( bird.currentPosition);
        bird.BirdFly();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bird.Tap();
        }    
        if(Input.GetKeyDown(KeyCode.A))
        {
            bird.Skill();
        }
        if (bird.CheckColliderBirdAndPipe(pipeSpawner.GetPipe(index)))
        {
            index++;
            if (index > pipeSpawner.GetLength()-1) index = 0;
        }
    }   
    public void Tap()
    {
        bird.Tap();
    }
    public void TapSkill()
    {
        bird.Skill();
    }
}
