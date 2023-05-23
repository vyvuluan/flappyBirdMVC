using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private List<GameObject> bulletPool;
    private int poolBulletSize;
    private float speedBullet;
    [SerializeField] private GameObject bulletPrefabs;
    private Vector3 currentPosition;
    public void Initialized(int poolBulletSize, float speedBullet, Vector3 currentPosition)
    {
        this.poolBulletSize = poolBulletSize;
        this.speedBullet = speedBullet;
        this.currentPosition = currentPosition;
    }
    void Start()
    {

        bulletPool = new List<GameObject>();
        Debug.Log(poolBulletSize);
        for (int i = 0; i < poolBulletSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefabs);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;
        foreach (GameObject bullet in bulletPool)
        {
            if (bullet.activeInHierarchy && bullet.transform.position.x > worldWidth / 2)
            {
                bullet.SetActive(false);
            }
        }
    }
    public void getBullet()
    {
        Debug.Log("lay dc dan");
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                Debug.Log("1111");
                bullet.GetComponent<Bullet>().Initialized(this.speedBullet);
                bullet.transform.position = currentPosition;
                bullet.SetActive(true);
                break;
            }

        }

    }
}
