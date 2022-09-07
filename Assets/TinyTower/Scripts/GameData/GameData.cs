using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace TinyTower
{
    // 상품 데이터 관리 하는 클래스
    public class GameData : MonoBehaviour
    {
        public static GameData I;
        // 상품 데이터 관리
        public TextAsset _product_csv; // csv 파일 그 자체를 연결
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

            // StringReader : System.IO에 있는 클래스로, 파일로부터 문자열을 읽게 해줌
            using (StringReader reader = new StringReader(text))
            {
                string firstline = reader.ReadLine(); // 첫번째 줄을 읽는데, 첫번째 라인은 컬럼명이어서 버리기 위해 그냥 이렇게 실행만 시켜줌

                if(firstline != null)
                {
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // csv 값이므로 ',' seperator 로 데이터를 분리해서 저장
                        string[] record = line.Split(',');

                        // 한줄의 데이터 개수는 3개다 라고 단언하는 거임. 넘어가면 오류가 남
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

