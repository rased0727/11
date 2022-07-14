using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace RPG3D
{
    public class Player : Unit
    {
        void Update()
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            {
                Debug.Log("in");
                // 공격!!             
                Attack();
            }
        }
    }
}
