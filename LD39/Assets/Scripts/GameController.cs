using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameObject WinPanel;
    public static GameObject LosePanel;
    void OnEnable()
    {
        Master.OnWin += Win;
        Master.OnLose += Lose;
    }

    void Lose()
    {
        LosePanel.SetActive(true);
        Master.PauseGame();
    }

    void Win()
    {
        WinPanel.SetActive(true);
        Master.PauseGame();
    }
}
