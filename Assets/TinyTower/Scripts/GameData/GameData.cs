using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace TinyTower
{
    // ��ǰ ������ ���� �ϴ� Ŭ����
    public class GameData : MonoBehaviour
    {
        public static GameData I;
        // ��ǰ ������ ����
        public TextAsset _product_csv; // csv ���� �� ��ü�� ����
        public List<GameData_Product> _product_dataList;

        private void Awake()
        {
            I = this;
        }

        public void Init()
        {
            Init_ProductData();

        }
        void Init_ProductData()
        {
            string text = _product_csv.text;

            // StringReader : System.IO�� �ִ� Ŭ������, ���Ϸκ��� ���ڿ��� �а� ����
            using (StringReader reader = new StringReader(text))
            {
                string firstline = reader.ReadLine(); // ù��° ���� �дµ�, ù��° ������ �÷����̾ ������ ���� �׳� �̷��� ���ุ ������

                if(firstline != null)
                {
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // csv ���̹Ƿ� ',' seperator �� �����͸� �и��ؼ� ����
                        string[] record = line.Split(',');

                        // ������ ������ ������ 3���� ��� �ܾ��ϴ� ����. �Ѿ�� ������ ��
                        Debug.Assert(record.Length == 5);

                        GameData_Product temp = new GameData_Product();
                        temp.name = record[0];
                        temp.floor = record[1];
                        temp.cost = Convert.ToInt32(record[2]);
                        temp.time = Convert.ToSingle(record[3]);
                        temp.quantity = Convert.ToInt32(record[4]);

                        _product_dataList.Add(temp);
                    }
                }

            }
        }

    }
}

