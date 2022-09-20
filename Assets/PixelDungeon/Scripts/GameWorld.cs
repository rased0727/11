using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelDungeon
{
    public class GameWorld : MonoBehaviour
    {
        public static GameWorld I;
        // Start is called before the first frame update
        void Awake()
        {
            I = this;
        }

    }
}

