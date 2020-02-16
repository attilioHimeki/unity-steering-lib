using UnityEngine;

namespace UnitySteeringLib
{
    public partial class SteeringMovementModule : MovementModule
    {
        [Header("Cohesion")]
        public float maxCohesion = 10f;
        
        private Vector3 stepCohesion()
        {
            var centerOfMass = owner.getPosition();
            var neighboursAmount = 1;

            var ownerGroup = owner.getGroup();
            if(ownerGroup != null)
            {
                var members = ownerGroup.getMembers();

                for (var i = 0; i < members.Count; i++)
                {
                    var a = members[i];
                    if (a != owner)
                    {
                        var distance = Vector3.Distance(owner.getPosition(), a.getPosition());
                        if (distance < maxCohesion)
                        {
                            centerOfMass += a.getPosition();
                            neighboursAmount++;
                        }
                    }
                }

                if (neighboursAmount > 1)
                {
                    centerOfMass /= neighboursAmount;

                    return stepSeek(centerOfMass);
                }
            }

            return Vector3.zero;
        }
    }
}