using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts.States;
using Assets.Scripts.Interfaces;

public class Quitter : MonoBehaviour
{

    private StateManager manager;

    void Start ()
    {
        manager = GameObject.FindObjectOfType<StateManager>() as StateManager;
    }
	
	void Update () 
	{

		if(Input.GetKey (KeyCode.Escape))
		{
			if (SceneManager.GetActiveScene().name == "Startup")
			{
				Application.Quit();
			}
			else
			{
                //Can use the below to exit to the startup screen if you don't plan to use an in-game menu. Fine for a game that doesn't need an in-game menu.
				//SceneManager.LoadScene ("Startup", LoadSceneMode.Single);
			}
		}
	
	}

    public void QuitGame()
    {
        //Include anything else you want to happen when a player quits. Save automatically? You can put that in here.
        QuitState quitState = new QuitState(manager);
        manager.SwitchState(quitState);
        Application.Quit();
    }
}
