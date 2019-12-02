using System.Collections.Generic;

namespace UnitySteeringLib
{
    public class AgentsGroup
    {
        private List<IAgent> members;
        private IAgent groupLeader;

        public AgentsGroup()
        {
            members = new List<IAgent>();
        }

        public void addMembers(IList<IAgent> agents)
        {
            foreach(var a in agents)
            {
                addMember(a);
            }
        }

        public void addMember(IAgent agent)
        {
            if(!members.Contains(agent))
            {
                members.Add(agent);
                agent.setGroup(this);
                
            }
        }

        public void removeMember(IAgent agent)
        {
            members.Remove(agent);
        }

        public int getMembersCount()
        {
            return members.Count;
        }

        public bool hasLeader()
        {
            return groupLeader != null;
        }

        public void setLeader(IAgent leader)
        {
            groupLeader = leader;
        }

        public IAgent getLeader()
        {
            return groupLeader;
        }

        public IList<IAgent> getMembers()
        {
            return members.AsReadOnly();
        }
     }
}