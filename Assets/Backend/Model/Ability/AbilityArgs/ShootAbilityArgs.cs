using System;
using UnityEngine;

namespace Assets.Backend.Model
{
    [Serializable]
    public class ShootAbilityArgs
    {
        public GameObject Projectile;
        public Transform bulletSpawn;
        public int potency;

    }
}
