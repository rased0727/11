using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public enum FloorType
    {
        RESIDENTIAL,// 주거
        FOOD_STORE, // 음식점 
        SERVICE,    // 서비스 스토어
        CULTURE,    // 문화시설
        CREATIVE,   // 예술, 창작
        RETAIL,     // 각종 판매점
        BUSINESS    // 사무실, 사업장
    }
    public interface IIncomeCollector
    {
        void CollectGold();
    }

    public class Floor : MonoBehaviour, IIncomeCollector
    {
        public FloorType _type;
        public void CollectGold()
        {
            // 테스트코드
        }
        public void ShowInfo(string name)
        {
            Debug.Log("현재 클릭한 객체 : " + this);
        }
        void OnMouseDown()
        {
            ShowInfo(gameObject.name);
            //Debug.Log("this : " + this);
        }


    }
}

