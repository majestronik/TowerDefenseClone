using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        /*
                    .LoadScene(0)
                    .LoadScene("MainScene")  does the same thing
        */
    }
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
