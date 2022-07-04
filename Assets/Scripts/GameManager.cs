using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsGameOver;


    public GameObject gameOverUI;
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
}
