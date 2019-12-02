using UnityEngine;

namespace UnitySteeringLib
{
	public partial class SteeringMovementModule : MovementModule 
	{
        [Header("Flee")]
        public float safeFleeDistance = 10f;
        private Vector3 stepFlee(Vector3 targetPosition)
        {
            var desiredVelocity = targetPosition - owner.getPosition();

            var distance = desiredVelocity.magnitude;
            if(distance < safeFleeDistance)
            {
                return -stepSeek(targetPosition);
            }
            
            return -velocity;
        }

    }
}