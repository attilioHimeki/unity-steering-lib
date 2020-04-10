using UnityEngine;

namespace Himeki.AI.Steering
{
	public interface IWorldContextInfoProvider  
	{
		IAgent[] getObstaclesForSector(Vector3 agentPosition);
		IAgent getPlayerAgent();
		IAgent[] getNonPlayingAgents();
	}

}