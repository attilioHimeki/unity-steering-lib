using UnityEngine;
using System.Collections.Generic;

namespace UnitySteeringLib
{
    public abstract class CompoundSteeringBehaviour : SteeringBehaviour
    {
        private List<SteeringBehaviour> behaviours;
        private List<float> weights;
        public CompoundSteeringBehaviour(SteeringAgent owner)
        : base(owner)
        {
            behaviours = new List<SteeringBehaviour>(4);
            weights = new List<float>(4);
        }

        public void addBehaviour(SteeringBehaviour b, float weight = 1f)
        {
            behaviours.Add(b);
            weights.Add(weight);
        }

        public override Vector3 step()
        {
            var steering = Vector3.zero;

            for(var i = 0; i < behaviours.Count; i++)
            {
                steering += behaviours[i].step() * weights[i];
            }

            return steering;
        }
    }
}