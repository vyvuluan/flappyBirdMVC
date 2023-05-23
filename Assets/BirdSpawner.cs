using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] private GameObject yellowBird;
    [SerializeField] private GameObject redBird;
    [SerializeField] private GameObject blueBird;
    private int birdColor;
    private const string textColorBird = "color bird";
    public GameObject birdGameObject;
    private void Awake()
    {
        birdColor = PlayerPrefs.GetInt(textColorBird);
        choseBird();
    }
    public void choseBird()
    {
        if (birdColor == (int)ColorBird.RED)
        {
            birdGameObject = Instantiate(redBird, redBird.transform.position, Quaternion.identity);
        }
        if (birdColor == (int)ColorBird.BLUE)
        {
            birdGameObject = Instantiate(blueBird, blueBird.transform.position, Quaternion.identity);
        }
        if (birdColor == (int)ColorBird.YELLOW)
        {
            birdGameObject = Instantiate(yellowBird, yellowBird.transform.position, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
