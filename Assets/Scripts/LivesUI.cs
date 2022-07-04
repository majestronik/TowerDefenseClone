using TMPro;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI Lives;

    private void Update()
    {
        Lives.text = PlayerStats.Lives + " LIVES";
    }
}
