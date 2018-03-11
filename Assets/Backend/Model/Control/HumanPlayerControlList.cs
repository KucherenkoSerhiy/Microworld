using Assets.Backend.Model.Control;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Backend.Model.Input
{
    public class HumanPlayerControlList
    {
        private List<HumanPlayerControl> Controls;

        public HumanPlayerControlList()
        {
            Controls = new List<HumanPlayerControl>
            {
                new HumanPlayerControl
                {
                    PlayerInputSource = EnPlayerInputSource.PlayerOne,
                    Input = new PlayerInput {
                        KeyDuck = KeyCode.DownArrow,
                        KeyJump = KeyCode.UpArrow,
                        KeyMoveLeft = KeyCode.LeftArrow,
                        KeyMoveRight = KeyCode.RightArrow,
                        KeyPossess = KeyCode.L
                    },
                    IsActive = true

                    
                },
                new HumanPlayerControl
                {
                    PlayerInputSource = EnPlayerInputSource.PlayerTwo,
                    Input = new PlayerInput {
                        KeyDuck = KeyCode.S,
                        KeyJump = KeyCode.W,
                        KeyMoveLeft = KeyCode.A,
                        KeyMoveRight = KeyCode.D
                    },
                    IsActive = true
                }
            };
        }

        public HumanPlayerControl GetPlayer(EnPlayerInputSource humanPlayerSource)
        {
            return Controls.SingleOrDefault(x => x.PlayerInputSource == humanPlayerSource);
        }
    }
}
