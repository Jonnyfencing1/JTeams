using Rocket.API;
using Rocket.Core;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using System.Linq;

namespace JTeams
{
    public class JTeams : RocketPlugin<Config>
    {

        public static IAsset<Config> Config;

        private Teams _teams;

        public Teams teams()
        {
            if (_teams != null)
            {
                return _teams;
            }

            _teams = new Teams();
            return _teams;
        }
        //Plugin Load Function
        protected override void Load()
        {
            base.Load();
            Config = Configuration;
            U.Events.OnPlayerConnected += EventsOnOnPlayerConnected;
            U.Events.OnPlayerDisconnected += player => teams().RemovePlayerFromGroup(player);

        }
        //Connection Event
        private void EventsOnOnPlayerConnected(UnturnedPlayer player)
        {
            List<JConfigTeam> possiblePlayerTeams = new List<JConfigTeam>();
            foreach (var team in Configuration.Instance.Teams)
            {
                if (R.Permissions.GetGroups(player, false).Exists(c => c.Id == team.PermissionGroup))
                {
                    possiblePlayerTeams.Add(team);
                }
            }
            teams().AddPlayerToGroup(player, possiblePlayerTeams.OrderByDescending(c => c.Priority).First().Name);
        }
        //Plugin Unload Function
        protected override void Unload()
        {
            base.Unload();
            Config = null;
            U.Events.OnPlayerConnected -= EventsOnOnPlayerConnected;
            U.Events.OnPlayerDisconnected -= player => teams().RemovePlayerFromGroup(player);
        }
    }
}
