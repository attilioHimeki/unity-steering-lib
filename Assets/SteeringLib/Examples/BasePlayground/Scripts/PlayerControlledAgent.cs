using UnityEngine;
using Himeki.AI.Steering;

public class PlayerControlledAgent : Agent
{
    protected override void setupMovementModule()
    {
        movementModule = new SimpleInputMovementModule(this);
    }

}
