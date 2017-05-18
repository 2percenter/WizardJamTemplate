using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.States;
using Assets.Scripts.Interfaces;

public class Pauser : MonoBehaviour 
{
	public static bool paused = false;
	public Canvas pauseTextCanvas;
    public Text pauseText;
    private string originalPauseText;
	private StateManager manager;
	private bool waiting = false;
    public float delay; 

	void Start () 
	{
        manager = GameObject.FindObjectOfType<StateManager>();
        originalPauseText = pauseText.GetComponent<Text>().text;
	}


	// Update is called once per frame
	void Update () 
	{
        if (Input.GetKeyUp(KeyCode.P))
		{
            if (manager.activeState.GetType() == typeof(PauseState)) //Unpausing must be first within this if-then
            {
                StartCoroutine(Unpause());
            }

            if (manager.activeState.GetType() == typeof(GameState))
            {
				paused = true;
                PauseState pauseState = new PauseState(manager);
                manager.SwitchState(pauseState);
                pauseTextCanvas.GetComponent<Canvas>().enabled = true;
                Time.timeScale = 0;
            }

		}
	}

	IEnumerator Unpause()
	{
		waiting = true;
		float timeSince = 0.0f;

		float startTime = Time.realtimeSinceStartup;
		int roundedTime = (int)delay;

		while (waiting)
		{
			roundedTime = (int)(delay - timeSince+0.5f);
            //Can use a GUI element showing the countdown to being unpause if you are using a delay. Use the roundedTime value to show the seconds remaining.
            if (roundedTime > 0)
            {
                pauseText.GetComponent<Text>().text = roundedTime.ToString();
            }
            timeSince = Time.realtimeSinceStartup - startTime;
			if (timeSince > delay)
			{
				waiting = false;
			}
			yield return 0;
		}
        //Turn off pause text and change back to GameState
        pauseTextCanvas.GetComponent<Canvas>().enabled = false;
        pauseText.GetComponent<Text>().text = originalPauseText; //Return what original pause text was. Set to "Pause" originally.
        GameState gameState = new GameState(manager);
        manager.SwitchState(gameState);
        Time.timeScale = 1;
		yield return 0;
	}

}
