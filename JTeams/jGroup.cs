using Steamworks;

namespace JTeams
{
    public class JGroup
    {
        public JGroup(string name, CSteamID groupId)
        {
            Name = name;
            GroupId = groupId;
        }

        protected JGroup()
        {

        }

        public string Name { get; set; }
        public CSteamID GroupId { get; set; }
    }
}
