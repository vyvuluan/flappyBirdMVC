using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private Button tapToStart;
    [SerializeField] private Text scoreText, scorePanel, bestScore;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Image medalGold, medalSilver, medalBronze;
    [SerializeField] private Text timeCountDownStartText;
    [SerializeField] private GameObject pausePanel;
    private const string highScore = "high score";
    private void Awake()
    {
        Time.timeScale = 0;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {

        timeCountDownStartText.gameObject.SetActive(true);
        tapToStart.gameObject.SetActive(false);
        StartCoroutine(CountDownToStartGame());
    }
   
    public void SetTextScore(int score)
    {
        scoreText.text = score.ToString();
        //scrorePanel.text = score.ToString();
    }
    public void SetTextBestScore(int score)
    {
        bestScore.text = score.ToString();
    }

    public void SetMedal(int score)
    {
        if (score > 10)
        {
            medalGold.gameObject.SetActive(true);
            medalSilver.gameObject.SetActive(false);
            medalBronze.gameObject.SetActive(false);
        }
        else if (score < 10 && score > 5)
        {
            medalGold.gameObject.SetActive(false);
            medalSilver.gameObject.SetActive(true);
            medalBronze.gameObject.SetActive(false);
        }
        else
        {
            medalGold.gameObject.SetActive(false);
            medalSilver.gameObject.SetActive(false);
            medalBronze.gameObject.SetActive(true);
        }
    }

    public void EnableGameOverPanel(int score)
    {
        if (score > 10)
        {
            medalGold.gameObject.SetActive(true);
            medalSilver.gameObject.SetActive(false);
            medalBronze.gameObject.SetActive(false);
        }
        else if (score < 10 && score > 5)
        {
            medalGold.gameObject.SetActive(false);
            medalSilver.gameObject.SetActive(true);
            medalBronze.gameObject.SetActive(false);
        }
        else
        {
            medalGold.gameObject.SetActive(false);
            medalSilver.gameObject.SetActive(false);
            medalBronze.gameObject.SetActive(true);
        }
        scorePanel.text = score.ToString();
        if(score >  PlayerPrefs.GetInt(highScore))
            bestScore.text = score.ToString();
        gameOverPanel.SetActive(true);
    }
    public void HomeButton()
    {
        Debug.Log("menu");
        SceneManager.LoadScene("MainMenu");
    }
    public void ResumButton()
    {
        SceneManager.LoadScene("GamePlay");
    }
    IEnumerator CountDownToStartGame()
    {
        int countDownTime = 3;
        while (countDownTime > 0)
        {
            timeCountDownStartText.text = countDownTime.ToString();
            yield return new WaitForSecondsRealtime(1.0f);
            countDownTime--;
        }

        Time.timeScale = 1;
        timeCountDownStartText.gameObject.SetActive(false);

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
