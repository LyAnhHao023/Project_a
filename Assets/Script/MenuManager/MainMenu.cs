using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SceneAsset scene;

    public void sceneAsset(SceneAsset asset)
    {
        scene = asset;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartGame(int id)
    {
        StaticData.LevelType = id;
        SceneManager.LoadScene(scene.name);
    }
}
