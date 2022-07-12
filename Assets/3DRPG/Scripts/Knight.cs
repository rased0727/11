using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace RPG3D
{
    public class Knight : Unit
    {
        void Update()
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            {
                // 공격!!
                //m_Character.Attack();                
                Attack();
            }
        }
    }
}
