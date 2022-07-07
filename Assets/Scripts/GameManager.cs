using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsGameOver;
    public GameObject gameOverUI;
    public GameObject compleLevelUI;

    private void Start()
    {
        IsGameOver = false;
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        if (IsGameOver) return;

        if ((PlayerStats.Lives <= 0))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over!");
        IsGameOver = true;
        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        IsGameOver = true;
        compleLevelUI.SetActive(true);
        Debug.Log("LEVEL WON!");
    
    }
}
