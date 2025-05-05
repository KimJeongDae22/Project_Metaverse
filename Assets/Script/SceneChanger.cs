using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;

    [SerializeField] GameObject mainPlayer;
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject mainCamera;
    void Start()
    {
        if (instance == null)

        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ChangeScene_Main()
    {
        SceneManager.LoadScene(SceneName.Main);
        mainPlayer.SetActive(true);
        mainCanvas.SetActive(true);
    }
    public void ChangeScene_MiniGame()
    {
        SceneManager.LoadScene(SceneName.MiniGame);
        mainPlayer.SetActive(false);
        mainCanvas.SetActive(false);
    }
}
