using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("MVC")]
    [SerializeField] private GameConfig model;
    [SerializeField] private GameView view;
    [SerializeField] private Audio audioGame;

    [Header("Preference")]
    [SerializeField] private PipeSpawner pipeSpawner;
    [SerializeField] private BulletSpawner bulletSpawner;
    [SerializeField] private BirdController birdController;
    [SerializeField] private BirdSpawner birdSpawner;
    private void Awake()
    {
        pipeSpawner.Initialized(model.speed, model.pipePoolSize);
        bulletSpawner.Initialized(model.poolBulletSize, model.bulletSpeed, birdController.currentPosition);
        birdController.Initialized(model.gravitationalForce, model.bounceForce, view.SetTextScore, audioGame.AudioDie, audioGame.AudioFly, 
            audioGame.AudioPoint, view.EnableGameOverPanel, bulletSpawner.getBullet, birdSpawner.birdGameObject);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        birdController.InitializedListPipePool(pipeSpawner.getListPipePool());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
