using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public static void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        /*
                    .LoadScene(0)
                    .LoadScene("MainScene")  does the same thing
        */
    }
    public void Menu()
    {
        Debug.Log("Go To Menu");
    }
}
