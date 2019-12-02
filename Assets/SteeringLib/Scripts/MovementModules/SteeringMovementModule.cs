using UnityEngine;

namespace UnitySteeringLib
{
    [System.Serializable]
    public partial class SteeringMovementModule : MovementModule
    {
        public float minSpeed = 0.5f;
        public float maxForce = 15f;
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
                case SteeringBehaviour.Seek:
                    steering = stepSeek(target.getPosition());
                    break;
                case SteeringBehaviour.Arrival:
                    steering = stepArrival(target.getPosition());
                    break;
                case SteeringBehaviour.Flee:
                    steering = stepFlee(target.getPosition());
                    break;
                case SteeringBehaviour.Pursue:
                    steering = stepPursue(target);
                    break;
                case SteeringBehaviour.Evade:
                    steering = stepEvade(target.getPosition());
                    break;
                case SteeringBehaviour.Follow:
                    steering = stepFollow(target.getPosition());
                    break;
                case SteeringBehaviour.Flocking:
                    steering = stepFlocking();
                    break;
            }

            steering = Vector3.ClampMagnitude(steering, maxForce);
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