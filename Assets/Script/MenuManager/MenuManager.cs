using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvas;
    /*[SerializeField] private GameObject _settingsMenuCanvas;*/
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _levelUpUI;
    [SerializeField] private GameObject statShow;
    [SerializeField] private GameObject buffTable;

    /*[SerializeField] private GameObject _mainMenuFirst;*/
    /*[SerializeField] private GameObject _settingsMenuFirst;*/

    [SerializeField] List<UpgradeButton> upgradeButtons;

    [SerializeField] Vector3 statShowStep;
    [SerializeField] Vector3 startStatShowStep;
    [SerializeField] Vector3 buffTableStep;
    [SerializeField] Vector3 startBuffTableStep;
    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;

    private bool isPaused;

    private bool isGameOver;

    private bool isLevelUp;

    // Start is called before the first frame update
    void Start()
    {
        _mainMenuCanvas.SetActive(false);
        /*_settingsMenuCanvas.SetActive(false);*/
        _gameOverUI.SetActive(false);
        _levelUpUI.SetActive(false);

        isGameOver = false;
        isLevelUp = false;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.MenuOpenCloseInput)
        {
            if (!isGameOver && !isLevelUp)
            {
                if (!isPaused)
                {
                    Pause();
                }
                else
                {
                    Unpause();
                }
            }
        }
            
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        OpenMainMenu();
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        CloseAllMenus();
    }

    private void OpenMainMenu()
    {
        _mainMenuCanvas.SetActive(true);
        /*_settingsMenuCanvas.SetActive(false);*/

        EventSystem.current.SetSelectedGameObject(null);
    }

    /*private void OpenSettingsMenuHandle()
    {
        _settingsMenuCanvas.SetActive(true);
        _mainMenuCanvas.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }*/

    private void CloseAllMenus()
    {
        _mainMenuCanvas.SetActive(false);
        /*_settingsMenuCanvas.SetActive(false);*/

        EventSystem.current.SetSelectedGameObject(null);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Unpause();
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Unpause();
    }

    public void GameOverScreen()
    {
        isPaused = true;
        isGameOver = true;
        Time.timeScale = 0f;
        _gameOverUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void LevelUpScene(List<UpgradeData> upgradeDatas)
    {
        isLevelUp = true;
        isPaused = true;

        statShow.LeanMoveLocal(statShowStep, tweenTime).setEase(tweenType).setIgnoreTimeScale(true);
        buffTable.LeanMoveLocal(buffTableStep, tweenTime).setEase(tweenType).setIgnoreTimeScale(true);

        for (int i = 0; i < upgradeDatas.Count; i++)
        {
            upgradeButtons[i].Set(upgradeDatas[i]);
        }

        Time.timeScale = 0f;
        _levelUpUI.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
    }

    public void LevelUpDone()
    {
        statShow.LeanMoveLocal(startStatShowStep, tweenTime).setEase(tweenType).setIgnoreTimeScale(true);
        buffTable.LeanMoveLocal(startBuffTableStep, tweenTime).setEase(tweenType).setIgnoreTimeScale(true);

        isLevelUp = false;

        _levelUpUI.SetActive(false);
        Unpause();
    }
}
