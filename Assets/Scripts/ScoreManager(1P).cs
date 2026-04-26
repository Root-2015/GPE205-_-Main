using UnityEngine;
using TMPro;

public class ScoreManager1P : MonoBehaviour
{
    public GameObject player1;
    public float Score = 0;
    public TMP_Text ScoreText;
    public ScoreManager scoreManager;

    public void Activate()
    {
        player1 = GameObject.Find("Player(Clone)");
    }
    
    public void Update()
    {
        if (player1 != null) 
        {
            Health Player1Health = player1.GetComponent<Health>();
            Score = Player1Health.score;
            ScoreText.text = "Score: " + Score;
        }
        scoreManager.p1Score = Score;
    }



}
