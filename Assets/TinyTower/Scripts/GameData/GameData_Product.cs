using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    // 게임 데이터 형식을 지정하는 클래스
    [Serializable]
    public class GameData_Product
    {
        public string name;
        public string floor;
        public int cost;
        public float time;
        public int quantity;
    }
}

