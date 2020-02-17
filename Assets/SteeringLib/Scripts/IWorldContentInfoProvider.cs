using UnityEngine;

namespace UnitySteeringLib
{
	public interface IWorldContextInfoProvider  
	{
		IAgent[] getObstaclesForSector(Vector3 agentPosition);
		IAgent getPlayerAgent();
		IAgent[] getNonPlayingAgents();
	}

}