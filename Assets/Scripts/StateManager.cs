using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.States;
using Assets.Scripts.Interfaces;

public class StateManager : MonoBehaviour 
{
	private IStateBase activeState;		//Whatever your possible states are, e.g. GameState, PlayingState, ShowScoreState, NannyStateMIriteGuyz. Some sample states are provided.
	public string currentState;			//String with just the state's name in it

    private static StateManager instanceRef;
	
	void Awake()
	{
		if(instanceRef == null)
		{
			instanceRef = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			DestroyImmediate(gameObject);
		}
	}
	
	void Start()
	{
        if (SceneManager.GetActiveScene().name == "Startup")
        {
            activeState = new StartupState(this);
        }
        else
        {
            activeState = new LevelLoadState(this);
        }
		ShowState (activeState);

	}
	
	void Update()
	{
		if(activeState != null)
			activeState.StateUpdate ();
	}
	
	public void SwitchState(IStateBase newState)
	{
		activeState = newState;
		ShowState (activeState);
        activeState.StateStart();
	}
	
	void ShowState(IStateBase state)
	{
		//Section to get nice string to show current state.
		int finalDotLocation = 0;
		int locInString = 0;
		string tmpString;
		tmpString = state.ToString();
		foreach (char c in tmpString)
		{
			locInString++;
			if(c == '.')
				finalDotLocation = locInString;
		}

		currentState = tmpString.Substring(finalDotLocation);
		Debug.Log ("currentState = " + currentState);
	}
	
    //Reinstate this method if you want to restart.
	//public void Restart()
	//{
	//	Destroy (gameObject);
	//	Application.LoadLevel ("YourMainSceneNameHere");
	//}
	
}

