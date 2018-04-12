using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Assets.Backend.Model
{
	[Serializable]
	public class StickAbilityArgs
	{
		public List<string> TargetTagsToStick;
        public int SlowingFactor;
		internal bool IsSticked;
	}
}