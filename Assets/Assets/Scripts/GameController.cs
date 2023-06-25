using Assets.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //public GameObject FinishPanel;
    //public GameObject FindTheKeyPanel;
    //public GameObject PausePanel;
    //public GameObject GameOverPanel;
    public GameObject Key;
    //public Text txtFinalMessage;
    public Text txtCoins;
    public Text txtLives;
    public bool IsKeyCatched = false;
    public bool IsFinished = false;
    public bool IsPaused = false;
    public bool IsMainMenu = false;
    public bool IsShowFindKeyMessage = false;
    public bool IsGameOver = false;

    //audios clips
    private AudioSource[] audioSource;
    private AudioSource audioGameTheme;
    private AudioSource audioGameOverTheme;
    private AudioSource audioKeyUI;
    private AudioSource audioFinishTheme;
    private AudioSource audioCoin;
    private AudioSource audioJump;
    private static AudioSource audioHurt;
    private AudioSource audioAlertTheme;
    private AudioSource audioSelectOption;

    public int totalScore;
    public int totalLive;

    public static GameController instance;

    void Start()
    {
        audioSource = GetComponents<AudioSource>();
        audioGameTheme = audioSource[0];
        audioFinishTheme = audioSource[1];
        audioGameOverTheme = audioSource[2];
        audioKeyUI = audioSource[3];
        audioCoin = audioSource[4];
        audioJump = audioSource[5];
        audioHurt = audioSource[6];
        audioAlertTheme = audioSource[7];
        audioSelectOption = audioSource[8];
        txtCoins.text = totalScore.ToString();
        txtLives.text = totalLive.ToString();
        audioGameTheme.Play();
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused || IsShowFindKeyMessage)
                Resume();
            else
                Pause();
        }
    }
    public void Pause()
    {
        if (IsPaused)
        { 
            Resume();
        }
        else
        if (!IsFinished && !IsGameOver && !IsMainMenu)
        {
            //PausePanel.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
            audioGameTheme.Pause();
            audioSelectOption.Play();
        }
    }
    public void Resume()
    {
        //PausePanel.SetActive(false);
        //FindTheKeyPanel.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        IsShowFindKeyMessage = false;
        audioSelectOption.Play();
        audioGameTheme.Play();
    }
    public void Finish()
    {
        //FinishPanel.SetActive(true);
        Time.timeScale = 0f;
        IsFinished = true;
        audioGameTheme.Pause();
        audioFinishTheme.Play();
    }
    public void FindTheKeyMessage(bool showMessage)
    {
        //FindTheKeyPanel.SetActive(showMessage);
        Time.timeScale = 0f;
        IsShowFindKeyMessage = true;
        audioGameTheme.Pause();
        audioAlertTheme.Play();
    }

    public void ShowKeyUI(GameObject key)
    {
        IsKeyCatched = true;
        Key.SetActive(IsKeyCatched);
        Time.timeScale = 1f;
        IsFinished = false;
        IsPaused = false;
        IsGameOver = false;
        IsMainMenu = false;
        Destroy(key, 0.25f);
        audioKeyUI.Play();
    }
    public void MainMenu()
    {
        Time.timeScale = 0f;
        IsMainMenu = true;
        audioGameTheme.Pause();
        audioFinishTheme.Play();
    }
    public void PlayJumpAudio()
    {
        if (audioJump != null)
            audioJump.Play();
    }
    public void PlayGetCoinAudio()
    {
        if (audioCoin != null)
            audioCoin.Play();
    }
    public static void PlayGetHurtAudio()
    {
        if (audioHurt != null)
            audioHurt.Play();
    }
    public void GameOver()
    {
        //GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        IsGameOver = true;
        audioGameTheme.Pause();
        audioGameOverTheme.Play();
    }
    public void Restart()
    {
        //PausePanel.SetActive(false);
        Key.gameObject.SetActive(false);
        //GameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        audioGameOverTheme.Pause();
        audioGameTheme.Play();
    }
    public void SelectScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            Time.timeScale = 1f;
            audioSelectOption.Play();
            if (sceneName == Constants.MAIN_SCENE)
            {
                audioGameOverTheme.Pause();
                audioGameTheme.Pause();
                Time.timeScale = 0f;
            }

            SceneManager.LoadScene(sceneName);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void WrongAnswer()
    {
        Answer(false, "No! Wrong answer!");
    }
    public void RightAnswer(string message)
    {
        Answer(true, message);
    }
    private void Answer(bool right, string message)
    {
        if (right)
            PlayGetCoinAudio();
        else
            PlayGetHurtAudio();
        // txtFinalMessage.text = message;
    }
}
