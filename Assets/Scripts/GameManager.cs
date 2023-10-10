using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	
	public GameObject playButton;
	public GameObject playerShip;
	public GameObject enemySpawner;
	public GameObject restartButton;
	public GameObject scoreCounter;

	public enum GameManagerState
{
Opening,
Gameplay,
GameOver,
Restart,
}    
 
GameManagerState GMState;
GameManagerState GMSR;

    void Start()
    {
        	GMState = GameManagerState.Opening;
    }

    
    void UpdateGameManagerState()
{

	switch(GMState)
{
	case GameManagerState.Opening:

				
				restartButton.SetActive(false);
	playButton.SetActive(true);
			break;

	case GameManagerState.Gameplay:
		playButton.SetActive(false);
		restartButton.SetActive(false);
		playerShip.GetComponent<PlayerControls>().Init();
	
		enemySpawner.GetComponent<simpSpawner>().ScheduleEnemySpawner();
			break;
	
case GameManagerState.GameOver:
	

		Invoke("ChangeToRestartingState", 5f);
		enemySpawner.GetComponent<simpSpawner>().UnscheduleEnemySpawner();
		playButton.SetActive(false);
				
				break;


case GameManagerState.Restart:
	restartButton.SetActive(true);
	playButton.SetActive(false);
	enemySpawner.GetComponent<simpSpawner>().ResetEnemySpawner();
				scoreCounter.GetComponent<ScoreCounter>().SetPoints();


				break;
}
}

	public void SetGameManagerState(GameManagerState state)
{
	GMState = state;
	UpdateGameManagerState ();
}	



			public void StartGamePlay()
{
 		 GMState = GameManagerState.Gameplay;
		UpdateGameManagerState();
		}
			public void ChangeToRestartingState()
		{
 			SetGameManagerState (GameManagerState.Restart);
		}


}