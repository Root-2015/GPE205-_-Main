using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float p1Score;
    public float p2Score;
    public float HighScore;
    public TMP_Text ScoreText;
    public TMP_Text P1ScoreText;
    public TMP_Text P2ScoreText;
    public TMP_Text HighScoreText;
    public TMP_Text HighScoreText2Player;

    public void Awaken1Player() 
    {
        ScoreText.text = "Score: " + p1Score;
        if (p1Score >= HighScore) 
        {
            HighScore = p1Score;
        }
        HighScoreText.text = "Highest Score: " + HighScore;
    }
    public void Awaken2Player() 
    {
        P1ScoreText.text = "Player 1's Score: " + p1Score;
        P2ScoreText.text = "Player 2's Score: " + p2Score;
        if (p1Score >= HighScore)
        {
            HighScore = p1Score;
        }
        if (p2Score >= HighScore)
        {
            HighScore = p2Score;
        }

        HighScoreText2Player.text = "Highest Score: " + HighScore;
    }
}
