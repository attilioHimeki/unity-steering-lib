using UnityEngine;

namespace UnitySteeringLib
{
    public partial class SteeringMovementModule : MovementModule
    {

        [Header("Avoidance")]
        public float minObstacleAvoidanceDistance = 3f;
        public float maxAvoidanceForce = 20f;
        public float maxAvoidanceBrakingForce = 1f;

        private Vector3 stepCollisionAvoidance(IAgent[] obstacles)
        {
            if (obstacles.Length > 0 && minObstacleAvoidanceDistance > 0f)
            {
                var closest = getClosestAvoidanceObstacle(obstacles);
                if(closest != null)
                {
                    var distanceVector = closest.getPosition() - owner.getPosition();

                    float brakingMultiplier = (minObstacleAvoidanceDistance - distanceVector.magnitude) / minObstacleAvoidanceDistance;
                    var braking = owner.getForward() * brakingMultiplier * maxAvoidanceBrakingForce;

                    var lateralSteering = (owner.getForward() - distanceVector.normalized) * maxAvoidanceForce;

                    return braking + lateralSteering;
                }
            }

            return Vector3.zero;
        }

        private IAgent getClosestAvoidanceObstacle(IAgent[] obstacles)
        {
            IAgent closest = null;
            float closestDistance = float.MaxValue;
            
            foreach(var o in obstacles)
            {
                var direction = o.getPosition() - owner.getPosition();
                if(Vector3.Dot(direction.normalized, owner.getVelocity().normalized) > 0.5f)
                {
                    var distance = direction.magnitude - o.getRadius() - owner.getRadius();
                    if(distance <= minObstacleAvoidanceDistance)
                    {
                        //var timeToCollision = distance / owner.getVelocity().magnitude;
                        if(distance < closestDistance)
                        {
                            closest = o;
                            closestDistance = distance;
                        }
                    }
                }

            }

            return closest;
        }
    }

}