using UnityEngine;

namespace UnitySteeringLib
{
	public partial class SteeringMovementModule : MovementModule 
	{

        [Header("Avoidance")]
        public float minObstacleAvoidanceDistance = 4f;
        public float maxAvoidanceForce = 20f;
        public float maxAvoidanceBrakingForce = 1f;
		private Vector2 stepCollisionAvoidance(IAgent obstacle)
        {
            var distanceVector = obstacle.getPosition() - owner.getPosition();

            float brakingMultiplier = (minObstacleAvoidanceDistance - distanceVector.magnitude) / minObstacleAvoidanceDistance;
            var braking = owner.getForward() * brakingMultiplier * maxAvoidanceBrakingForce;

            var lateralSteering = (owner.getForward() - distanceVector.normalized) * maxAvoidanceForce;

            return braking + lateralSteering;
        }
	}

}