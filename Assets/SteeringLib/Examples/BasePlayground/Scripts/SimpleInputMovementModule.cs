using UnityEngine;
using UnitySteeringLib;
public class SimpleInputMovementModule : MovementModule
{
    public SimpleInputMovementModule(IAgent agent)
    : base(agent)
    {
    }

    public override Vector3 getStep(float dt)
    {
        var inputH = Input.GetAxisRaw("Horizontal");
        var inputV = Input.GetAxisRaw("Vertical");

        var inputVector = new Vector3(inputH, 0f, inputV);
        if(inputVector.sqrMagnitude > Mathf.Epsilon)
        {
            var movementDirection = inputVector.normalized;

            var steering = movementDirection * owner.getMaxSpeed();

            return steering;
        }

        return Vector3.zero;
    }

}
