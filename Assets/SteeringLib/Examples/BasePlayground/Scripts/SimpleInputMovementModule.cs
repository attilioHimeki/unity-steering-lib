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
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");

        Vector3 inputVector = new Vector3(inputH, 0f, inputV);
        if(inputVector.sqrMagnitude > Mathf.Epsilon)
        {
            Vector3 movementDirection = inputVector.normalized;

            velocity = movementDirection * owner.getMaxSpeed();

            Vector3 step = velocity * dt;

            return step;
        }

        return Vector3.zero;
    }

}
