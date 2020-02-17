namespace UnitySteeringLib
{
	public class SteeringAgent : Agent 
	{
		public SteeringBehaviourId initialBehaviour;
		public bool avoidObstacles = true;
		public IAgent target { get; set; }
		private SteeringMovementModule steeringMovementModule;

		protected override void setupMovementModule()
		{
			steeringMovementModule = new SteeringMovementModule(this);
			movementModule = steeringMovementModule;

			if(initialBehaviour != SteeringBehaviourId.None)
			{
				steeringMovementModule.setBehaviour(initialBehaviour);
			}
		}

		public void setBehaviour(SteeringBehaviourId behaviour)
		{
			steeringMovementModule.setBehaviour(behaviour);
		}

	}

}