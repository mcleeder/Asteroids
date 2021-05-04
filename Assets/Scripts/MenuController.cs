using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static void LoadNextLevel()
    {
        LevelLoader.levelComplete = true;
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

}
