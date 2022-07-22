using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG3D
{
    public class Slime : Monster
    {
        protected override void ProcessHit(int damage, Unit attacker)
        {
            base.ProcessHit(damage, attacker);
        }
    }
}
