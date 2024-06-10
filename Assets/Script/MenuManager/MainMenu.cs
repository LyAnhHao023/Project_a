using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartGame(int id)
    {
        StaticData.LevelType = id;
        SceneManager.LoadScene("SampleScene");
    }
}
