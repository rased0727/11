using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace TinyTower
{
    public class GameData : MonoBehaviour
    {
        public static GameData I;

        // 상품 데이터 관리
        public TextAsset _product_csv; // csv파일 그 자체
        public List<GameData_Product> _product_dataList;

        //

        //
        void Awake()
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

            //StringReader: System.IO의 클래스, 파일로부터 문자열 읽게 해줌
            using (StringReader reader = new StringReader(text))
            {
                string firstLine = reader.ReadLine(); // 첫번째줄은 읽고 쓰지 않는다(컬럼 이름들이므로)

                if( firstLine != null )
                {
                    string line = null;
                    while((line = reader.ReadLine()) != null )
                    {
                        // csv 값이므로, ',' seperator로 데이터들을 분리해서 저장

                        string[] record = line.Split(',');

                        Debug.Assert(record.Length == 6);

                        GameData_Product temp = new GameData_Product();
                        temp.name = record[0];
                        temp.floor = record[1];
                        temp.cost = Convert.ToInt32( record[2] );
                        temp.time = Convert.ToSingle( record[3] );
                        temp.quantity = Convert.ToInt32(record[4]);
                        temp.sprite = record[5];

                        // 스프라이트 이름을 가지고, 실제 스프라이트 이미지 로드
                        Sprite spObj = Resources.Load<Sprite>(temp.sprite);
                        temp.spriteImg = spObj;


                        // List에 하나를 집어넣을 때는 Add 함수 쓴다
                        _product_dataList.Add(temp);
                    }


                }



            }

        }

    }
}
