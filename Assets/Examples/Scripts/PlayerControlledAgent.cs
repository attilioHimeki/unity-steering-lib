using UnityEngine;

namespace UnitySteeringLib
{
	public class PlayerControlledAgent : Agent
	{
		
		protected override void setupMovementModule()
		{
			movementModule = new SimpleInputMovementModule(this);
		}

		public override void update(float dt)
		{
			velocity = movementModule.getStep(dt);
			if(velocity.sqrMagnitude > Mathf.Epsilon)
			{
				var movementStep = velocity * dt;
				setForward(velocity.normalized);
				translate(movementStep);
			}
		}

	}
}
