using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "LevelSelect";
    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        StartCoroutine(sceneFader.FadeOut(levelToLoad));
        Application.Quit();
    }
}
