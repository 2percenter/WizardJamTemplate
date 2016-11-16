using UnityEngine;
using Assets.Scripts.States;
using Assets.Scripts.Interfaces;


namespace Assets.Scripts.States
{
    public class LevelLoadState : IStateBase
    {
        private StateManager manager;


        public LevelLoadState(StateManager managerRef)
        {
            manager = managerRef;
        }

        public void StateStart()
        {

        }

        public void StateUpdate()
        //Use this (if you want) to call certain methods during the Update() cycle. This will be called from the StateManager for the current state only.
        {
            //Wait for level to be fully loaded.

            //For this simple case, I am just going to check and make sure the GameMenu is present and then change to GameState. You can leave it like this or do whatever you need.

            if (GameObject.FindObjectOfType<GameMenu>())
            {
                GameState gameState = new GameState(manager);
                manager.SwitchState(gameState);
            }
        }

    }

}
