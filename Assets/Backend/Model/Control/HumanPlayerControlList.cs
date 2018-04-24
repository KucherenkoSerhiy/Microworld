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
//                new HumanPlayerControl
//                {
//                    PlayerInputSource = EnPlayerInputSource.PlayerOne,
//                    Input = new PlayerInput {
//                        KeyDuck = KeyCode.DownArrow,
//                        KeyJump = KeyCode.UpArrow,
//                        KeyMoveLeft = KeyCode.LeftArrow,
//                        KeyMoveRight = KeyCode.RightArrow,
//                        KeyPossess = KeyCode.L,
//                        KeyDash = KeyCode.J
//                    },
//                    IsActive = true
//                },
                new HumanPlayerControl
                {
                    PlayerInputSource = EnPlayerInputSource.PlayerOne,
                    Input = new PlayerInput {
                        KeyDuck = KeyCode.Joystick1Button1,
                        KeyJump = KeyCode.Joystick1Button0,
                        KeyMoveLeft = KeyCode.Joystick1Button4,
                        KeyMoveRight = KeyCode.Joystick1Button5,
                        KeyPossess = KeyCode.Joystick1Button2,
                        KeyDash = KeyCode.Joystick1Button3
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
                },
//                new HumanPlayerControl
//                {
//                    PlayerInputSource = EnPlayerInputSource.PlayerTwo,
//                    Input = new PlayerInput {
//                        KeyDuck = KeyCode.,
//                        KeyJump = KeyCode.,
//                        KeyMoveLeft = KeyCode.,
//                        KeyMoveRight = KeyCode.
//                    },
//                    IsActive = true
//                }
            };
        }

        public HumanPlayerControl GetPlayer(EnPlayerInputSource humanPlayerSource)
        {
            return Controls.SingleOrDefault(x => x.PlayerInputSource == humanPlayerSource);
        }
    }
}


/*
 * Inputs joystick cotroller 
A 								-> joystick button 0
B 								-> joystick button 1
X 								-> joystick button 2
Y 								-> joystick button 3
Left Bumper 					-> joystick button 4
Right Bumper 					-> joystick button 5
View (Back) 					-> joystick button 6
Menu (Start) 					-> joystick button 7
Left Stick Button 				-> joystick button 8
Right Stick Button 				-> joystick button 9
Left Stick “Horizontal” 		-> X Axis 		-> -1 to 1
Left Stick “Vertical” 			-> Y Axis		-> 1 to -1
Right Stick “HorizontalTurn” 	-> 4th Axis 	-> -1 to 1
Right Stick “VerticalTurn” 		-> 5th Axis 	-> 1 to -1
DPAD – Horizontal 				-> 6th Axis 	-> -1 (.64) 1
DPAD – Vertical 				-> 7th Axis 	-> -1 (.64) 1
Left Trigger 					-> 9th Axis 	-> 0 to 1
Right Trigger 					-> 10th Axis 	-> 0 to 1
Left Trigger Shared Axis 		-> 3rd Axis 	-> 0 to 1
Right Trigger Shared Axis 		-> 3rd Axis 	-> 0 to -1
 * 
 */
 