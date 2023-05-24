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
    [SerializeField] private TMPro.TextMeshProUGUI countDownText;
    private const string highScore = "high score";
    private void Awake()
    {
        Time.timeScale = 0;
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
        Debug.Log(PlayerPrefs.GetInt(highScore));
        int highScoreTemp = PlayerPrefs.GetInt(highScore);
        if (score > highScoreTemp)
        {
            highScoreTemp = score;
            PlayerPrefs.SetInt(highScore, score);
        }
        bestScore.text = highScoreTemp.ToString();
        gameOverPanel.SetActive(true);
    }
    public void HomeButton()
    {
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

    public void CountDownSkill(string time)
    {
        countDownText.text = time;
    }

}
