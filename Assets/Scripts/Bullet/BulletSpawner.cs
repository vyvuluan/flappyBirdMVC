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
    public void Initialized(int poolBulletSize, float speedBullet)
    {
        this.poolBulletSize = poolBulletSize;
        this.speedBullet = speedBullet;
    }
    public void InitializedPositionBird( Vector3 currentPosition)
    {
        this.currentPosition = currentPosition;
    }
    void Start()
    {

        bulletPool = new List<GameObject>();
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
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.GetComponent<Bullet>().Initialized(this.speedBullet);
                bullet.transform.position = currentPosition;
                bullet.SetActive(true);
                break;
            }

        }

    }
}
