using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speedBullet;
    public void Initialized(float speedBullet)
    {
        this.speedBullet = speedBullet;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletMovement();
    }
    void bulletMovement()
    {
        Vector3 temp = transform.position;
        temp.x += speedBullet * Time.deltaTime;
        transform.position = temp;
    }
}
