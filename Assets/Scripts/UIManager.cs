using UnityEngine;

public class UIManager : MonoBehaviour
{
	[Header("Screen States")]
 	public GameObject OpenScreen;
	public GameObject StartScreen;
	public GameObject Settings;
	public GameObject Credits;
	public GameObject GameOver;
    public GameObject GameOverMultiplayer;
    public GameObject OnePlayerUI;
    public GameObject TwoPlayerUI;
	public SettingsUI SettingsManager;
	public ScoreManager scoreManager;

    private GameManager gameManager;

    private void Start()
	{
    ActivateOpenScreen();
    gameManager = GetComponent<GameManager>();
    }

	public void ActivateOpenScreen()
	{
		DeactivateAllStates();
		OpenScreen.SetActive(true);
	}

	public void ActivateStartScreen()
	{
		DeactivateAllStates();
		StartScreen.SetActive(true);
	}

	public void ActivateSettings()
	{
		DeactivateAllStates();
		Settings.SetActive(true);
	}

	public void ActivateCredits()
	{
		DeactivateAllStates();
		Credits.SetActive(true);
	}

	public void ActivateGameOver()
	{
		DeactivateAllStates();
		if (SettingsManager.IsMultiplayerOn == 0)
        {
            GameOver.SetActive(true);
			scoreManager.Awaken1Player();
        }
        else
        {
			GameOverMultiplayer.SetActive(true);
			scoreManager.Awaken2Player();
        }
        
	}

	public void ActivateGamePlay()
	{
		DeactivateAllStates();
		gameManager.StartGame();
		if (SettingsManager.IsMultiplayerOn == 0) 
		{
			ActivateOnePlayerUI();
        }
		else 
		{
            ActivateTwoPlayerUI();
        }
    }

    public void ActivateOnePlayerUI()
    {
        OnePlayerUI.SetActive(true);
        ScoreManager1P Awaken1 = OnePlayerUI.GetComponent<ScoreManager1P>();
        Awaken1.Activate();
    }

    public void ActivateTwoPlayerUI()
    {
        TwoPlayerUI.SetActive(true);
        ScoreManager2P Awaken2 = TwoPlayerUI.GetComponent<ScoreManager2P>();
        Awaken2.Activate();
    }

    private void DeactivateAllStates()
	{
		OpenScreen.SetActive(false);
		StartScreen.SetActive(false);
		Settings.SetActive(false);
		Credits.SetActive(false);
		GameOver.SetActive(false);
        GameOverMultiplayer.SetActive(false);
        OnePlayerUI.SetActive(false);
        TwoPlayerUI.SetActive(false);
    }
}