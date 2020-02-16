using UnityEngine;

namespace UnitySteeringLib
{
    [System.Serializable]
    public partial class SteeringMovementModule : MovementModule
    {
        public float minSpeed = 0.5f;
        private SteeringAgent steeringOwner;

        public SteeringMovementModule(IAgent agent)
        : base(agent)
        {
            steeringOwner = agent as SteeringAgent;
        }

        public override Vector3 getStep(float dt)
        {
            var target = steeringOwner.getTarget();
            if (target == null)
            {
                return Vector3.zero;
            }

            Vector3 steering = Vector3.zero;
            switch (steeringOwner.currentBehaviour)
            {
                case SteeringBehaviourId.Seek:
                    steering = stepSeek(target.getPosition());
                    break;
                case SteeringBehaviourId.Arrival:
                    steering = stepArrival(target.getPosition());
                    break;
                case SteeringBehaviourId.Flee:
                    steering = stepFlee(target.getPosition());
                    break;
                case SteeringBehaviourId.Pursue:
                    steering = stepPursue(target);
                    break;
                case SteeringBehaviourId.Evade:
                    steering = stepEvade(target.getPosition());
                    break;
                case SteeringBehaviourId.Follow:
                    steering = stepFollow(target.getPosition());
                    break;
                case SteeringBehaviourId.Flocking:
                    steering = stepFlocking();
                    break;
            }

            if(steeringOwner.avoidObstacles)
            {
                var obstacles = steeringOwner.world.getObstaclesForSector(owner.getPosition());
                steering += stepCollisionAvoidance(obstacles);
            }

            steering = Vector3.ClampMagnitude(steering, owner.getMaxForce());
            steering /= owner.getMass();

            velocity = Vector3.ClampMagnitude(velocity + steering, owner.getMaxSpeed());

            if (velocity.magnitude > minSpeed)
            {
                return velocity * dt;
            }

            return Vector3.zero;

        }

    }

}