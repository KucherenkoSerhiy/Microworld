using Assets.Backend.Model.Control;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Backend.Model.Input
{
    public class BotPlayerControlList
    {
        private List<BotPlayerControl> Controls; 

        public BotPlayerControlList()
        {
            Controls = new List<BotPlayerControl>
            {
                new BotPlayerControl
                {
                    BotInputSource = EnBotInputSource.BasicPursuer,
                    IsActive = true
                }
            };
        }

        public BotPlayerControl GetPlayer(EnBotInputSource botPlayerSource)
        {
            return Controls.SingleOrDefault(x => x.BotInputSource == botPlayerSource);
        }
    }
}
