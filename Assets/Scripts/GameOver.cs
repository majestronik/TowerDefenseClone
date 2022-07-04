using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

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
