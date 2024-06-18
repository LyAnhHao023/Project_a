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
    [SerializeField] private GameObject _OpenChestUI;
    [SerializeField] private GameObject statShow;
    [SerializeField] private GameObject buffTable;

    /*[SerializeField] private GameObject _mainMenuFirst;*/
    /*[SerializeField] private GameObject _settingsMenuFirst;*/

    [SerializeField] List<UpgradeButton> upgradeButtons;

    [SerializeField] private GameObject levelUpEffect;
    [SerializeField] private ParticleSystem _levelUpEffect;

    [SerializeField] Vector3 statShowStep;
    [SerializeField] Vector3 startStatShowStep;
    [SerializeField] Vector3 buffTableStep;
    [SerializeField] Vector3 startBuffTableStep;
    [SerializeField] Vector3 openChestStep;
    [SerializeField] Vector3 startOpenChestStep;
    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;

    private bool isPaused;

    private bool isGameOver;

    private bool isSelectBuff;

    // Start is called before the first frame update
    void Start()
    {
        _mainMenuCanvas.SetActive(false);
        /*_settingsMenuCanvas.SetActive(false);*/
        _gameOverUI.SetActive(false);
        _levelUpUI.SetActive(false);
        _OpenChestUI.SetActive(false);
        levelUpEffect.SetActive(false);

        isGameOver = false;
        isSelectBuff = false;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.MenuOpenCloseInput)
        {
            if (!isGameOver && !isSelectBuff)
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
        isSelectBuff = true;
        isPaused = true;


        statShow.LeanMoveLocal(statShowStep, tweenTime).setEase(tweenType).setIgnoreTimeScale(true);
        buffTable.LeanMoveLocal(buffTableStep, tweenTime).setEase(tweenType).setIgnoreTimeScale(true);

        for (int i = 0; i < upgradeDatas.Count; i++)
        {
            upgradeButtons[i].Set(upgradeDatas[i]);
        }

        Time.timeScale = 0f;
        _levelUpUI.SetActive(true);
        levelUpEffect.SetActive(true);

        _levelUpEffect.Play();

        EventSystem.current.SetSelectedGameObject(null);
    }

    public void LevelUpDone()
    {
        _levelUpEffect.Stop();

        statShow.LeanMoveLocal(startStatShowStep, 0f).setEase(tweenType).setIgnoreTimeScale(true);
        buffTable.LeanMoveLocal(startBuffTableStep, 0f).setEase(tweenType).setIgnoreTimeScale(true);

        isSelectBuff = false;

        _levelUpUI.SetActive(false);
        levelUpEffect.SetActive(false);
        Unpause();
    }

    public void OpenChestScene()
    {
        isSelectBuff = true;
        isPaused = true;

        _OpenChestUI.LeanMoveLocal(openChestStep, tweenTime).setEase(tweenType).setIgnoreTimeScale(true);

        Time.timeScale = 0f;

        _OpenChestUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void CloseChestScene()
    {
        _OpenChestUI.LeanMoveLocal(startOpenChestStep, tweenTime).setEase(tweenType).setIgnoreTimeScale(true);

        isSelectBuff = false;

        _OpenChestUI.SetActive(false);
        Unpause();
    }
}
