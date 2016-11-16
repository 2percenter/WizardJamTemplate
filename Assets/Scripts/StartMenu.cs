using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Assets.Scripts.States;
using Assets.Scripts.Interfaces;

public class StartMenu : MonoBehaviour
{

    private StateManager manager;

    void Start()
    {
        manager = GameObject.FindObjectOfType<StateManager>() as StateManager;
    }

    public void StartGame()
    {
        LevelLoadState levelLoadState = new LevelLoadState(manager);
        manager.SwitchState(levelLoadState);
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

}
