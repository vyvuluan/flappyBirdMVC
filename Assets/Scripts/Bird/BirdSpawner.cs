using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject choseBird(GameObject birdPrefab)
    {
        GameObject birdGameObject = Instantiate(birdPrefab, birdPrefab.transform.position, Quaternion.identity);
        return birdGameObject;
    }
}
