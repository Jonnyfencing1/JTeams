using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System.Collections.Generic;

namespace JTeams
{
    public class Teams
    {
        //Group List
        List<JGroup> groups = new List<JGroup>();
        public Teams()
        {
            //Foreach Loop to generate groups in game
            foreach (var team in JTeams.Config.Instance.Teams)
            {
                CSteamID groupId = GroupManager.generateUniqueGroupID();
                GroupInfo groupInfo = GroupManager.addGroup(groupId, team.Name);
                GroupManager.sendGroupInfo(groupInfo);
                groups.Add(new JGroup(team.Name, groupId));
            }
        }
        //Add Player to Group Event
        public int AddPlayerToGroup(UnturnedPlayer player, string groupsName)
        {
            var group = groups.Find(c => c.Name == groupsName);
            if (group == null)
            {
                return 0;
            }

            var groupId = group.GroupId;

            player.Player.quests.channel.send("tellSetGroup", ESteamCall.ALL, ESteamPacket.UPDATE_RELIABLE_BUFFER, new object[]
            {
                groupId,
                0
            });
            return 1;
        }
        //Remove Player from the Group Event
        public void RemovePlayerFromGroup(UnturnedPlayer player)
        {
            player.Player.channel.send("askKickFromGroup", ESteamCall.SERVER, ESteamPacket.UPDATE_RELIABLE_BUFFER, new object[]
            {
               player.CSteamID
            });

        }

    }
}
