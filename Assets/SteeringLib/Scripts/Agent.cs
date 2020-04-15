using UnityEngine;

namespace Himeki.AI.Steering
{
    public class Agent : MonoBehaviour, IAgent
    {

        [SerializeField]
        protected internal float maxSpeed = 15f;
        [SerializeField]
        protected internal float minSpeed = 1f;
        [SerializeField]
        protected internal float maxForce = 15f;
        [SerializeField]
        protected internal float mass = 15f;
        [SerializeField]
        protected internal float radius = 1f;

        protected internal MovementModule movementModule;
        protected internal IWorldContextInfoProvider world;
        protected internal AgentsGroup currentGroup;

        public virtual void initialise(IWorldContextInfoProvider w)
        {
            world = w;

            setupMovementModule();
        }

        protected virtual void setupMovementModule()
        {
            movementModule = new MovementModule(this);
        }

        public virtual void update(float dt)
        {
            var steering = movementModule.getStep(dt);
            if (steering.sqrMagnitude >= minSpeed * minSpeed)
            {
                var movementStep = steering * dt;
                setForward(steering.normalized);
                translate(movementStep);
            }
        }

        public Vector3 getPosition()
        {
            return transform.position;
        }

        public Vector3 getForward()
        {
            return transform.forward;
        }

        public void setPosition(Vector3 pos)
        {
            transform.position = pos;
        }

        public void setForward(Vector3 forward)
        {
            transform.forward = forward;
        }

        public void translate(Vector3 movement)
        {
            transform.position += movement;
        }

        public GameObject getEntity()
        {
            return gameObject;
        }

        public float getMass()
        {
            return mass;
        }
        public float getRadius()
        {
            return radius;
        }

        public float getMaxSpeed()
        {
            return maxSpeed;
        }

        public float getMinSpeed()
        {
            return minSpeed;
        }

        public float getMaxForce()
        {
            return maxForce;
        }

        public virtual Vector3 getVelocity()
        {
            return movementModule.velocity;
        }

        public IWorldContextInfoProvider getWorldContext()
        {
            return world;
        }

        public void setGroup(AgentsGroup group)
        {
            currentGroup = group;
        }

        public AgentsGroup getGroup()
        {
            return currentGroup;
        }

        public bool hasGroup()
        {
            return currentGroup != null;
        }
    }
}