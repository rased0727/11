using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{

    public interface IIncomeCollector
    {
        void CollectGold();
    }


    public enum FloorType
    {
        RESIDENTIAL, //�ְ�
        FOOD_STORE,  //������
        SERVICE,     //���� �����
        CULTURE,     //��ȭ�ü�
        CREATIVE,    //����, â��
        RETAIL,      //���� �Ǹ���
        BUSINESS     //�繫��, �����
    }


    public class Floor : MonoBehaviour, IIncomeCollector
    {
        public FloorType _type;

        public int _income = 1; // ���� �ð��� ����
        public float _time = 1.0f; // ���� �ð�

        private float _elapsed = 0.0f; // ��� �ð�

        [SerializeField] private string _stopTime = "";

        public void Init()
        {
            if (PlayerPrefs.HasKey("game_stop_time"))
            {
                string lastGameTime = PlayerPrefs.GetString("game_stop_time");

                DateTime now = DateTime.Now;

                DateTime stopTime = DateTime.Parse(lastGameTime);

                TimeSpan span = now - stopTime;
                int incomeTotal = (int)(span.TotalSeconds / _time * _income);

                bool uiRefresh = false;
                UserData.I.AddGold(incomeTotal, null, uiRefresh);
            }
        }


        void Update()
        {
            _elapsed += Time.deltaTime;

            if (_elapsed > _time)
            {
                CollectGold(); // _time �ʸ��� ȣ���� ��

                _elapsed = 0.0f;
            }

        }


        public void CollectGold()
        {
            // �׽�Ʈ �ڵ�: n�� ���� n��� ���� ���� �ϴ� ��ƾ

            // ��� 1 ����
            UserData.I.AddGold(_income);
        }

        public void ShowInfo()
        {
            // �� ������ ������ ǥ��

            // �̸�
            // ����
            // ������
            // ���� ��
            // ���� �ð� �� ����

        }

        void OnMouseDown()
        {
            ShowInfo();
        }

    }
}

