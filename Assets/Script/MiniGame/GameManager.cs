using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text tryscoreText;
    public Text gameStartText;

    public GameObject GameOverWindow;
    public Text gameoverTryScore;
    public Text gameoverBestScore;

    public float time = 0;
    public float tryScore;
    public float bestScore;
    public bool gameStart;
    public bool gameOver;
    public bool getgameOver;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Time.timeScale = 0.0f;
    }

    private void Update()
    {
        if (!gameStart && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1.0f;
            gameStart = true;
            gameStartText.enabled = false;
            tryscoreText.enabled = true;
        }
        if (tryscoreText.enabled == true && !gameOver)
        {
            time += Time.deltaTime;
            tryscoreText.text = "현재 점수 : " + time.ToString("N2");
        }
        if (!getgameOver && gameOver)
        {
            Invoke("GetGameOverWindow", 2f);
            getgameOver = true;
        }
    }
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Back()
    {
        SceneChanger.instance.ChangeScene_Main();
    }
    public void Getgameover()
    {
        gameOver = true;
    }
    public void GetGameOverWindow()
    {
        GameOverWindow.SetActive(true);
        float trytime = time;
        float besttime = PlayerPrefs.GetFloat("BestScore");
        if (PlayerPrefs.HasKey("BestScore"))
        {
            if (trytime > besttime)
            {
                PlayerPrefs.SetFloat("BestScore", trytime);
                gameoverTryScore.text = "현재 점수 : " + trytime.ToString("N2");
                gameoverBestScore.text = "최고 점수 : " + trytime.ToString("N2");
            }
            else
            {
                gameoverTryScore.text = "현재 점수 : " + trytime.ToString("N2");
                gameoverBestScore.text = "최고 점수 : " + besttime.ToString("N2");
            }
        }
        else
        {
            PlayerPrefs.SetFloat("BestScore", trytime);
            gameoverTryScore.text = "현재 점수 : " + trytime.ToString("N2");
            gameoverBestScore.text = "최고 점수 : " + trytime.ToString("N2");
        }
    }
    
}
