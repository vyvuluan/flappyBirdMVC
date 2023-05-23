using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChoseRed()
    {
        PlayerPrefs.SetInt("color bird", (int)ColorBird.RED);
        SceneManager.LoadScene("GamePlay");
    }
    public void ChoseBlue()
    {
        PlayerPrefs.SetInt("color bird", (int)ColorBird.BLUE);
        SceneManager.LoadScene("GamePlay");
    }
    public void ChoseYellow()
    {
        PlayerPrefs.SetInt("color bird", (int)ColorBird.YELLOW);
        SceneManager.LoadScene("GamePlay");
    }
}
