using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvas;
    /*[SerializeField] private GameObject _settingsMenuCanvas;*/

    /*[SerializeField] private GameObject _mainMenuFirst;*/
    /*[SerializeField] private GameObject _settingsMenuFirst;*/

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        _mainMenuCanvas.SetActive(false);
        /*_settingsMenuCanvas.SetActive(false);*/
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
            else
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
}
