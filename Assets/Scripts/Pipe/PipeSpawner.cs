using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    
    private List<GameObject> pipes;
    private int pipePoolSize;
    private float speed;
    [SerializeField] private GameObject pipeHolder;
    private float resetPositionX;
    private float pipeSpacing;
    // Start is called before the first frame update
    public void Initialized(float speed,int pipePoolSize, float pipeSpacing)
    {
        this.pipePoolSize = pipePoolSize;
        this.speed = speed;
        this.pipeSpacing = pipeSpacing;
    }
    private void Awake()
    {
        pipes = new List<GameObject>();
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;
        resetPositionX = worldWidth / 2;
    }

    void Start()
    {
        SpawnPipes();
    }

    void SpawnPipes()
    {
        float startPositionX = resetPositionX;
        for (int i = 0; i < this.pipePoolSize; i++)
        {
            GameObject pipeTemp = Instantiate(pipeHolder, new Vector3(startPositionX, Random.Range(-1.5f, 2.0f), 0f), Quaternion.identity);
            pipeTemp.GetComponent<Pipe>().Initialized(this.speed);
            startPositionX += this.pipeSpacing;
            pipes.Add(pipeTemp);
        }
    }
    public GameObject GetPipe(int index)
    {
        return pipes[index];
    }
    public int GetLength()
    {
        return pipes.Count;
    }
    public void ChangeSpeedPipes(float speed)
    {
        foreach (GameObject pipe in pipes)
        {
            pipe.GetComponent<Pipe>().Initialized(speed);
        }    
    }
}
