using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Himeki.AI.Steering
{
    public class SteeringMovementModule : MovementModule
    {
        private SteeringAgent steeringOwner;
        private Dictionary<SteeringBehaviourId, SteeringBehaviour> steeringBehaviours;
        private SteeringBehaviour currentBehaviour;
        private SteeringBehaviour avoidanceBehaviour;
        private static Dictionary<SteeringBehaviourId, System.Type> behavioursMappings;
        
        static SteeringMovementModule()
        {
            behavioursMappings = new Dictionary<SteeringBehaviourId, Type>();

            behavioursMappings[SteeringBehaviourId.Idle] = typeof(Idle);
            behavioursMappings[SteeringBehaviourId.Alignment] = typeof(Alignment);
            behavioursMappings[SteeringBehaviourId.Arrival] = typeof(Arrival);
            behavioursMappings[SteeringBehaviourId.Cohesion] = typeof(Cohesion);
            behavioursMappings[SteeringBehaviourId.Evade] = typeof(Evade);
            behavioursMappings[SteeringBehaviourId.Flee] = typeof(Flee);
            behavioursMappings[SteeringBehaviourId.Flocking] = typeof(Flocking);
            behavioursMappings[SteeringBehaviourId.Follow] = typeof(Follow);
            behavioursMappings[SteeringBehaviourId.Pursue] = typeof(Pursue);
            behavioursMappings[SteeringBehaviourId.Seek] = typeof(Seek);
            behavioursMappings[SteeringBehaviourId.Separation] = typeof(Separation);
            behavioursMappings[SteeringBehaviourId.Avoidance] = typeof(Avoidance);
        }

        public SteeringMovementModule(IAgent agent)
        : base(agent)
        {
            steeringOwner = agent as SteeringAgent;

            steeringBehaviours = new Dictionary<SteeringBehaviourId, SteeringBehaviour>();

            avoidanceBehaviour = steeringBehaviours[SteeringBehaviourId.Avoidance] = new Avoidance(steeringOwner);
        }

        public void setBehaviour<T>() where T : SteeringBehaviour
        {  
            var type = typeof(T);
            var typeBehaviourId = behavioursMappings.FirstOrDefault(x => x.Value == type).Key;
            if(steeringBehaviours.ContainsKey(typeBehaviourId))
            {
                currentBehaviour = steeringBehaviours[typeBehaviourId];
            }
            else
            {
                currentBehaviour = (T)Activator.CreateInstance(type, owner);
                steeringBehaviours[typeBehaviourId] = currentBehaviour;
            }
        }

        public void setBehaviour(SteeringBehaviourId id)
        {
            if(steeringBehaviours.ContainsKey(id))
            {
                currentBehaviour = steeringBehaviours[id];
            }
            else
            {
                Type type;
                bool found = behavioursMappings.TryGetValue(id, out type);
                if(found)
                {
                    currentBehaviour = (SteeringBehaviour)Activator.CreateInstance(type, owner);
                    steeringBehaviours[id] = currentBehaviour;
                }
                else
                {
                    throw new System.ArgumentException("Parameter behaviour id not recognised.", id.ToString());
                }
            }
        }

        public override Vector3 getStep(float dt)
        {
            IAgent target = steeringOwner.target;

            if (target == null || currentBehaviour == null)
            {
                return Vector3.zero;
            }

            Vector3 steering = currentBehaviour.step();

            if(steeringOwner.avoidObstacles)
            {
                steering += avoidanceBehaviour.step();
            }

            steering = Vector3.ClampMagnitude(steering, owner.getMaxForce());
            
            float mass = Mathf.Max(owner.getMass(), 0.1f);
            Vector3 acceleration = steering / mass;
            velocity += acceleration * dt;
            velocity = Vector3.ClampMagnitude(velocity, owner.getMaxSpeed());

            if(velocity.magnitude >= steeringOwner.minSpeed)
            {
                Vector3 step = velocity * dt;
                return step;
            }
            else
            {
                return Vector3.zero;
            }
        }

    }

}