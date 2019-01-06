using Rocket.API;
using System.Collections.Generic;

namespace JTeams
{
    //Config File
    public class Config : IRocketPluginConfiguration
    {
        public List<JConfigTeam> Teams = new List<JConfigTeam>();

        public void LoadDefaults()
        {
            throw new System.NotImplementedException();
        }
    }
    //01001000 01100101 01111001 00100000 01010010 01101111 01111001 00100000 01100010 01100001 01100010 01100101 01110011 00100000 01101100 01101111 01110110 01100101 00100000 01111001 01101111 01110101 00100000 00111100 00110011
}
