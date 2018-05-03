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
                    BotInputSource = EnBotInputSource.Pursuer,
                    IsActive = true
                }
            };
        }

        /// <summary>
        /// returns copy of the control (as there are many of them)
        /// </summary>
        /// <param name="botPlayerSource"></param>
        /// <returns></returns>
        public BotPlayerControl GetPlayer(EnBotInputSource botPlayerSource)
        {
            var control = Controls.SingleOrDefault(x => x.BotInputSource == botPlayerSource);
            return control == null ? null : control.Clone();
        }
    }
}
