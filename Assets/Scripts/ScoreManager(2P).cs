using UnityEngine;
using TMPro;

public class ScoreManager2P : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float Player1Score = 0;
    public float Player2Score = 0;
    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;
    public ScoreManager scoreManager;

    public void Activate()
    {
        player1 = GameObject.Find("Player 2(Clone)");
        player2 = GameObject.Find("Player 1(Clone)");
    }

    public void Update()
    {
        if (player1 != null)
        {
            Health Player1Health = player1.GetComponent<Health>();
            Player1Score = Player1Health.score;
            player1ScoreText.text = "Player 1's Score: " + Player1Score;
        }
        if (player2 != null)
        {
            Health Player1Health = player2.GetComponent<Health>();
            Player2Score = Player1Health.score;
            player2ScoreText.text = "Player 2's Score: " + Player2Score;
        }
        scoreManager.p1Score = Player1Score;
        scoreManager.p2Score = Player2Score;
    }
}