using UnityEngine;
using Himeki.AI.Steering;
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

            velocity = movementDirection * owner.getMaxSpeed();

            return velocity;
        }

        return Vector3.zero;
    }

}
