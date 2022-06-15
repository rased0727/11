using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameData : MonoBehaviour
{
    
    public TextAsset _mission_daily_csv; // 데일리 미션을 가져오는 변수
    public List<GameData_MissionDaily> _mission_daily_data;

    void Start()
    {
        _mission_daily_data = new List<GameData_MissionDaily>();

        string text = _mission_daily_csv.text;
        using (StringReader reader = new StringReader(text))
        {
            // string line; // 첫줄부터 불러올 때
            string line = reader.ReadLine(); // 두번째줄 부터 불러올때는 이렇게 한줄을 강제로 읽고 시작
            while ((line = reader.ReadLine()) != null) // 끝에 이르기까지 한줄씩 찍어옴
            {
                Debug.Log("데이터 " + line);

                // csv 값이므로 ',' seperator 로 데이터를 분리해서 저장
                string[] record = line.Split(',');

                Debug.Assert(record.Length == 5);

                GameData_MissionDaily temp = new GameData_MissionDaily();
                temp.id = int.Parse(record[0]);
                temp.name = record[1];
                temp.clearCount = int.Parse(record[2]);
                temp.gem_reward = int.Parse(record[3]);
                temp.desc = record[4];

                _mission_daily_data.Add(temp);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
