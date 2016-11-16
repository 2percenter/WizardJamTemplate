using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.States;
using Assets.Scripts.Interfaces;

public class GameMenu : MonoBehaviour
{
    //This must be attached to a canvas for your game menu. Do not make more than one instance of this script in a scene.
    private StateManager manager;
    public Canvas gameMenuCanvas;       //Attach your game menu canvas in the inspector.
    private float menuTimer;             //How long the menu has been open.
    public float minMenuTime;           //Minimum amount of time menu can be open before an escape key can take effect. Set this in the inspector.
    private float menuStartTime;        //Recorded when we open the menu;

    void Start()
    {
        manager = GameObject.FindObjectOfType<StateManager>() as StateManager;
    }

    void Update ()
    {
	
	}

    public void GameStateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //Open game menu here and now. Change state to menu state.
            MenuState menuState = new MenuState(manager);
            manager.SwitchState(menuState);
            Time.timeScale = 0; //Stop time like the pauser.
            gameMenuCanvas.enabled = true;
            menuTimer = 0.0f;
            menuStartTime = Time.realtimeSinceStartup;
        }
    }

    public void MenuStateUpdate()
    {

        menuTimer = (Time.realtimeSinceStartup - menuStartTime);
        if (Input.GetKeyUp(KeyCode.Escape) && (menuTimer >= minMenuTime))
        {
            //Menu goes away without hitting resume button if hit escape again.
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        //Change back to game state
        GameState gameState = new GameState(manager);
        manager.SwitchState(gameState);
        gameMenuCanvas.enabled = false;
        Time.timeScale = 1; //Resume time, like the un-pauser.
    }

}
