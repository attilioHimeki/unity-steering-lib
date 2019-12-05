using UnityEngine;
using UnitySteeringLib;
public class SimpleInputMovementModule : MovementModule
{
    private Vector3 lastPosition;
    public SimpleInputMovementModule(IAgent agent)
    : base(agent)
    {
        lastPosition = agent.getPosition();
    }

    public override Vector3 getStep(float dt)
    {
        var inputH = Input.GetAxisRaw("Horizontal");
        var inputV = Input.GetAxisRaw("Vertical");

        var movementDirection = new Vector3(inputH, 0f, inputV).normalized;

        var steering = movementDirection * owner.getMaxSpeed();

        return steering;
    }

}
