using UnityEngine;
using System.Linq;

namespace UnitySteeringLib
{
	public partial class SteeringMovementModule : MovementModule 
	{
        [Header("Follow")]
        public float followDistance = 3f;

        private Vector3 stepFollow(Vector3 targetPosition)
        {
            var target = steeringOwner.getTarget();
            var offset = -target.getForward() * followDistance;

            var targetFollowPos = targetPosition + offset;

            var steering = stepArrival(targetFollowPos);

            return steering;
        }
    }
}