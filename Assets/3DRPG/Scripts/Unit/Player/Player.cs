using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace RPG3D
{
    public class Player : Unit
    {
        bool _isJump = false;

        void Update()
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            {     
                Attack();
            }
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                if (_isJump == false)
                {
                    Jump();
                    _isJump = true;
                    Invoke("JumpActive", 1.0f);
                }
            }
        }
        void JumpActive()
        {
            _isJump = false;
        }
    }
}
