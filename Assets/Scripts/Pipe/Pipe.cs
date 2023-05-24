using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float speed;

    public void Initialized(float speed)
    {
        this.speed = speed;
    }    
    void Update()
    {
        pipeMovement();
        //if (BirdTest.Instance != null)
        //{
        //    if (BirdTest.Instance.flag == 1)
        //    {
        //        Destroy(GetComponent<PipeController>());
        //    }
        //}
    }
    void pipeMovement()
    {
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;
        transform.position += Vector3.left * this.speed * Time.deltaTime;
        if (transform.position.x < -worldWidth / 2 -3)
        {
            transform.position = new Vector3(worldWidth / 2, Random.Range(-1.5f, 2.0f), 0f);

        }
    }
}
