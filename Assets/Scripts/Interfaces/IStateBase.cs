namespace Assets.Scripts.Interfaces 
{
	public interface IStateBase
	{
        //If you want to REQUIRE your different states to have certain methods, place those below. 
        void StateStart();
		void StateUpdate ();
	}
	
}

