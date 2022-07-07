using UnityEngine;
using TMPro;
using System.Collections;

public class RoundsSurvived : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    public string menuSceneName = "MainMenu";

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(.7f);
        while (round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(.05f);
        }
    }
}
