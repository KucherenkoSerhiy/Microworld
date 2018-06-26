using Assets.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Backend.GameCore.A.I
{
    public class BasicAgressiveNpc : NpcIntelligenceBase
    {
        public BasicAgressiveNpc(Character enemy)
        {
            _state = EnNpcState.Fight;
            _enemy = enemy;
        }

        public override void Activate()
        {
            IsActive = true;
        }

        public override void Act()
        {
            if (!IsActive) return;

            Fight();
        }

        public override void OnDamageReceived()
        {
            throw new NotImplementedException();
        }

        public override void See(object something)
        {
            throw new NotImplementedException();
        }

        protected override void Fight()
        {
            var moveAbility = _character.Abilities.SingleOrDefault(x => x.GetType() == typeof(MoveAbility));

            if (moveAbility != null)
            {
                ((MoveAbility)moveAbility).MoveTo(_enemy.Representation.transform.position);
            }
        }

        protected override void Flee()
        {
            throw new NotImplementedException();
        }

        protected override void Patrol()
        {
            throw new NotImplementedException();
        }

        protected override void Protect()
        {
            throw new NotImplementedException();
        }

        protected override void Sleep()
        {
            throw new NotImplementedException();
        }
    }
}
