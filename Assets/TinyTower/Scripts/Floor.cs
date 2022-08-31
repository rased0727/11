using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public enum FloorType
    {
        RESIDENTIAL,// �ְ�
        FOOD_STORE, // ������ 
        SERVICE,    // ���� �����
        CULTURE,    // ��ȭ�ü�
        CREATIVE,   // ����, â��
        RETAIL,     // ���� �Ǹ���
        BUSINESS    // �繫��, �����
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
            // �׽�Ʈ�ڵ�
        }
        public void ShowInfo(string name)
        {
            Debug.Log("���� Ŭ���� ��ü : " + this);
        }
        void OnMouseDown()
        {
            ShowInfo(gameObject.name);
            //Debug.Log("this : " + this);
        }


    }
}

