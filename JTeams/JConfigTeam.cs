using Steamworks;

namespace JTeams
{
    public class JConfigTeam : JGroup
    {
        public JConfigTeam(string name, CSteamID groupId) : base(name, groupId = CSteamID.Nil)
        {
        }

        public JConfigTeam(string name, CSteamID groupId, string permissionGroup, int priority) : base(name, groupId)
        {
            PermissionGroup = permissionGroup;
            Priority = priority;
        }

        public JConfigTeam() : base()
        {
        }

        public string PermissionGroup { get; set; }
        public int Priority { get; set; }
    }
    //01101110 01101111 00100000 01101000 01101111 01101101 01101111 00100000 01110100 01101000 01101111
}
