using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
    private int count;
    [SerializeField] private List<GameObject> birds;
    private void Awake()
    {
        count = 0;
        foreach(GameObject bird in birds)
        {
            bird.SetActive(false);
        }
        showBird();
    }

    public void showBird()
    {
        birds[count].SetActive(true);
    }
    public void BackButton()
    {
        birds[count].SetActive(false);
        count--;
        if (count < 0) count = 2;
        showBird();
    }
    public void NextButton()
    {
        birds[count].SetActive(false);
        count++;
        if (count > 2) count = 0;
        showBird();
    }
    public void ChoseBird()
    {
        GameObject gameObject = new("Param");
        gameObject.tag = "Param";
        Parameters parameters = gameObject.AddComponent<Parameters>();
        switch(count)
        {
            case 0:
                parameters.BirdType = ColorBird.RED;
                break;
            case 1:
                parameters.BirdType = ColorBird.BLUE;
                break;
            case 2:
                parameters.BirdType = ColorBird.YELLOW;
                break;
        }
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("GamePlay");

    }

}
