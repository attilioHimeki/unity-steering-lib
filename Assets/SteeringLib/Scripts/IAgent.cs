using UnityEngine;

namespace UnitySteeringLib
{
	public interface IAgent 
	{
		void initialise(IWorldContextInfoProvider w);
		float getMass();
		float getRadius();
		Vector3 getVelocity();
		float getMaxSpeed();
		float getMinSpeed();
		float getMaxForce();
		Vector3 getPosition();
		void update(float dt);
		void setPosition(Vector3 pos);
		void translate(Vector3 movement);
		Vector3 getForward();
		void setForward(Vector3 forward);
		GameObject getEntity();
		IWorldContextInfoProvider getWorldContext();
		void setGroup(AgentsGroup group);
		AgentsGroup getGroup();
		bool hasGroup();
		
	}

}