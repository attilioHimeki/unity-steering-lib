using UnityEngine;

namespace UnitySteeringLib
{
    public class Alignment : SteeringBehaviour
    {

        public Alignment(SteeringAgent owner)
        : base(owner)
        {
        }
        
        public override Vector3 step()
        {
            var heading = Vector3.zero;
            var neighboursAmount = 0;

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
                        if (a.getVelocity().sqrMagnitude > 0)
                        {
                            heading += a.getVelocity().normalized;
                            neighboursAmount++;
                        }
                    }
                }

                if (neighboursAmount > 0)
                {
                    heading /= neighboursAmount;

                    var desired = heading * owner.getMaxSpeed();
                    var steering = desired - owner.getVelocity();
                    return steering * (owner.getMaxForce() / owner.getMaxSpeed());
                }
            }

            return Vector3.zero;
        }
    }

}