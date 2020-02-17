namespace UnitySteeringLib
{
    public class Flocking : CompoundSteeringBehaviour
    {

        public Flocking(SteeringAgent owner)
        : base(owner)
        {
            addBehaviour(new Arrival(owner),    1f);
            addBehaviour(new Separation(owner), 1f);
            addBehaviour(new Cohesion(owner),   0.2f);
            addBehaviour(new Alignment(owner),  1f);
        }

    }
}