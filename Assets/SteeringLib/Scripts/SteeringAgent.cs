namespace UnitySteeringLib
{
	public class SteeringAgent : Agent 
	{
		public SteeringBehaviour currentBehaviour;
		public bool avoidObstacles = true;

		private SteeringMovementModule steeringMovementModule;
		private IAgent target;

		protected override void setupMovementModule()
		{
			steeringMovementModule = new SteeringMovementModule(this);
			movementModule = steeringMovementModule;
		}

		public void setBehaviour(SteeringBehaviour behaviour)
		{
			currentBehaviour = behaviour;
		}

		public void setTarget(IAgent trg)
		{
			target = trg;
		}

		public IAgent getTarget()
		{
			return target;
		}

	}

}