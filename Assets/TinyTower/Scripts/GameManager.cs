using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class GameManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            UserData.I.Init();
            UI_Manager.I.Init();


        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}