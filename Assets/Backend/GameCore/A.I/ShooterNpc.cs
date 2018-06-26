using Assets.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Backend.GameCore.A.I
{
    public class ShooterNpc : NpcIntelligenceBase
    {
        public ShooterNpc(Character enemy)
        {
            _state = EnNpcState.Sleep;
            _enemy = enemy;
        }

        public override void Activate()
        {
            IsActive = true;
        }

        public override void Act()
        {
            if (!IsActive) return;

            switch (_state)
            {
                case EnNpcState.Sleep:
                    break;
                case EnNpcState.Patrol:
                    break;
                case EnNpcState.Fight:
                    Fight();
                    break;
                case EnNpcState.Protect:
                    break;
                case EnNpcState.Flee:
                    break;
            }
        }

        public override void OnDamageReceived()
        {
            throw new NotImplementedException();
        }

        public override void Watch()
        {
            Transform transform = _character.Representation.transform;
            Transform enemytransform = _enemy.Representation.transform;

            float charDist = Vector3.Distance(transform.transform.position, enemytransform.position);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, charDist);
            if (hit.collider == null || hit.collider.gameObject.name != "Player1")
                hit = Physics2D.Raycast(transform.position, Vector2.right, charDist);
            if (hit.collider != null && hit.collider.gameObject.name == "Player1")
            {
                _state = EnNpcState.Fight;
            }
        }

        protected override void Fight()
        {
            var moveAbility = _character.Abilities.SingleOrDefault(x => x.GetType() == typeof(MoveAbility));

            if (moveAbility != null)
            {
                ((MoveAbility)moveAbility).MoveTo(_enemy.Representation.transform.position);
            }

            var shootAbility = _character.Abilities.SingleOrDefault(x => x.GetType() == typeof(ShootAbility));

            if (shootAbility != null)
            {
                ((ShootAbility)shootAbility).Shoot();
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
