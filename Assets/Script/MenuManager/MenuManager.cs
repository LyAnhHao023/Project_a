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

    /*[SerializeField] private GameObject _mainMenuFirst;*/
    /*[SerializeField] private GameObject _settingsMenuFirst;*/

    [SerializeField] List<UpgradeButton> upgradeButtons;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.MenuOpenCloseInput)
        {
            if(!isPaused)
            {
                Pause();
            }
            else if(!isGameOver || !isLevelUp)
            {
                Unpause();
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
        _gameOverUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        isPaused = true;
        isGameOver = true;
        Time.timeScale = 0f;
    }

    public void LevelUpScene(List<UpgradeData> upgradeDatas)
    {
        _levelUpUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        isPaused = true;
        isLevelUp = true;
        Time.timeScale = 0f;

        for(int i = 0; i < upgradeDatas.Count; i++)
        {
            upgradeButtons[i].Set(upgradeDatas[i]);
        }
    }

    public void LevelUpDone()
    {
        isLevelUp = false;
        Unpause();
        _levelUpUI.SetActive(false);
    }
}
