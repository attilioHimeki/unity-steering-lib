using UnityEngine;
using UnitySteeringLib;

// A rather simple implementation of a World context to showcase the various steering behaviours.
public class ExampleWorld : MonoBehaviour, IWorldContextInfoProvider
{
    private IAgent[] obstacles;
    private SteeringAgent[] npcs;
    private Agent player;
    private AgentsGroup npcGroup;

    void Start()
    {
        retrieveWorldInfo();
        createTestGroup();
    }

    private void retrieveWorldInfo()
    {
        var playerGameObject = GameObject.FindGameObjectWithTag("Player");
        if (playerGameObject)
        {
            player = playerGameObject.GetComponent<Agent>();
            player.initialise(this);
        }

        var obstacleGameObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        obstacles = new IAgent[obstacleGameObjects.Length];
        for (var i = 0; i < obstacles.Length; i++)
        {
            var obs = obstacleGameObjects[i].GetComponent<IAgent>();
            obs.initialise(this);
            obstacles[i] = obs;
        }

        var nonPlayingCharacters = GameObject.FindGameObjectsWithTag("NPC");
        npcs = new SteeringAgent[nonPlayingCharacters.Length];
        for (var i = 0; i < npcs.Length; i++)
        {
            var npc = nonPlayingCharacters[i].GetComponent<SteeringAgent>();
            npc.initialise(this);
            npc.setTarget(player);

            npcs[i] = npc;
        }

    }

    private void createTestGroup()
    {
        npcGroup = new AgentsGroup();
        if (npcs.Length > 0)
        {
            var leader = npcs[0];
            npcGroup.setLeader(leader);

            npcGroup.addMembers(npcs);

        }
    }

    void Update()
    {
        float dt = Time.deltaTime;

        player.update(dt);

        foreach (var n in npcs)
        {
            n.update(dt);
        }
    }

    public IAgent[] getObstaclesForSector(Vector3 agentPosition)
    {
        return obstacles;
    }

    public IAgent getPlayerAgent()
    {
        return player;
    }

    public IAgent[] getNonPlayingAgents()
    {
        return npcs;
    }

}
