using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("UI Elements")]
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject menuUI;
    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    bool gameStarted;
    int currentScore = 0;
    int currentHightScore = 0;

    public void StartGame()
    {
        currentScore = 0;
        currentScoreText.text = "Current Score: " + currentScore.ToString();

        menuUI.SetActive(false);
        gameStarted = true;
        playerController.StartGame();
    }

    public void PointScored()
    {
        currentScore += 1; //shorthand can be "currentScore++"
        currentScoreText.text = "Current Score: " + currentScore.ToString();
    }

    public void GameOver()
    {
        gameStarted = false;

        if(currentScore > currentHightScore)
        {
            currentHightScore = currentScore;
            highScoreText.text = "High Score: " + currentScore.ToString();
        }

        menuUI.SetActive(true);
    }

    public bool HasGameStarted()
    {
        return gameStarted;
    }
}
