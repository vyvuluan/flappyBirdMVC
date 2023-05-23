using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    
    private List<GameObject> pipePool;
    private int pipePoolSize;
    private float speed;
    [SerializeField] private GameObject pipeHolder;
    // Start is called before the first frame update
    public void Initialized(float speed,int pipePoolSize)
    {
        this.pipePoolSize = pipePoolSize;
        this.speed = speed;
    }
    public List<GameObject> getListPipePool ()
    {
        return pipePool;
    }
 
    void Start()
    {
        pipePool = new List<GameObject>();
        for (int i = 0; i < this.pipePoolSize; i++)
        {
            GameObject pipe = Instantiate(pipeHolder);
            pipe.SetActive(false);
            pipePool.Add(pipe);
        }
        StartCoroutine(SpawnPipeAfterSecond());
    }
    // Update is called once per frame
    void Update()
    {
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Camera.main.aspect;
        
        foreach (GameObject pipe in pipePool)
        {
            if (pipe.activeInHierarchy && pipe.transform.position.x < -worldWidth / 2 - 2)
            { 
                pipe.SetActive(false);
            }
        }
        
    }
    IEnumerator SpawnPipeAfterSecond()
    {
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Camera.main.aspect;
        GameObject pipe =  getPipe();
        Vector3 temp = pipe.transform.position;
        temp.x = worldWidth / 2;
        temp.y = Random.Range(-2.0f, 2.0f);
        pipe.transform.position = temp;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SpawnPipeAfterSecond());
    }    
    public GameObject getPipe()
    {
        foreach (GameObject pipe in pipePool)
        {
            if (!pipe.activeInHierarchy)
            {
                pipe.GetComponent<Pipe>().Initialized(this.speed);
                pipe.transform.position = pipeHolder.transform.position;
                pipe.SetActive(true);
                return pipe;
            }
            
        }
        GameObject newPipe = Instantiate(pipeHolder);
        pipePool.Add(newPipe);
        return newPipe;

    }    
}
