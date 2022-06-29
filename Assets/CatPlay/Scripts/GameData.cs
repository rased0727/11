using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameData : MonoBehaviour
{
    // 일일 미션 데이터
    public TextAsset _mission_daily_csv; // 데일리 미션을 가져오는 변수
    public List<GameData_MissionDaily> _mission_daily_data;

    // 상점 아이템 데이터
    public TextAsset _shop_item_csv;
    public List<GameData_ShopItem> _shop_item_data;

    // 시험용 테스 아이템 데이터
    public TextAsset _test_item_csv;
    public List<GameData_TestItem> _test_item_data;

    public SpriteRenderer _testSprite;

    void Start()
    {
        Init_MissionDailyData();
        Init_TestItemData();
    }
    void Init_TestItemData()
    {
        _test_item_data = new List<GameData_TestItem>();

        string text = _test_item_csv.text;

        // StringReader는 1줄 씩 읽기 위해서 쓰이는 기능
        using (StringReader reader = new StringReader(text))
        {
            // 밑의 RaadLine이 실행되면 자동으로 다음줄로 넘어감
            // 첫번째 줄은 컬럼 이름이기때문에 쓰지 않기 위해 아래행을 실행한거임
            string line = reader.ReadLine();

            // 두번째줄 부터 불러올때는 이렇게 한줄을 강제로 읽고 시작
            // while문으로 인해 파일의 끝행에 이를때까지 한줄씩 찍어옴
            while ((line = reader.ReadLine()) != null)
            {
                // csv 값이므로 ',' seperator 로 데이터를 분리해서 저장
                string[] record = line.Split(',');

                // 한줄의 데이터 개수는 3개다 라고 단언하는 거임. 넘어가면 오류가 남
                //Debug.Assert(record.Length == 4);

                GameData_TestItem temp = new GameData_TestItem();
                temp.id = int.Parse(record[0]);
                temp.name = record[1];
                temp.price = int.Parse(record[2]);
                temp.icon_sp = record[3];

                _test_item_data.Add(temp);

            }
        }
    }
    void Init_MissionDailyData()
    {
        _mission_daily_data = new List<GameData_MissionDaily>();

        string text = _mission_daily_csv.text;

        // StringReader는 1줄 씩 읽기 위해서 쓰이는 기능
        using (StringReader reader = new StringReader(text))
        {
            // 밑의 RaadLine이 실행되면 자동으로 다음줄로 넘어감
            string line = reader.ReadLine();

            // 두번째줄 부터 불러올때는 이렇게 한줄을 강제로 읽고 시작
            // while문으로 인해 파일의 끝행에 이를때까지 한줄씩 찍어옴
            while ((line = reader.ReadLine()) != null)
            {
                // csv 값이므로 ',' seperator 로 데이터를 분리해서 저장
                string[] record = line.Split(',');

                Debug.Assert(record.Length == 6);

                GameData_MissionDaily temp = new GameData_MissionDaily();
                temp.id = int.Parse(record[0]);
                temp.name = record[1];
                temp.clearCount = int.Parse(record[2]);
                temp.gem_reward = int.Parse(record[3]);
                temp.reward_icon = record[4];
                temp.desc = record[5];

                // 스프라이트 전체를 가져올 때
                Sprite[] spList = Resources.LoadAll<Sprite>("spritesheet_32x32");
                // 스프라이트 전체의 크기 만큼 반복
                for (int i = 0; i < spList.Length; i++)
                {
                    Sprite sp = spList[i]; // 현재의 아이템만 sp 변수에 넣어준 후
                    if (sp.name == temp.reward_icon) // sp의 이름이 gem_yellow 라면
                    {
                        // 유니티에서 GameData 객체의 GameData_MissionDailly_data에 추가 해줌
                        temp.reward_icon_sp = sp;
                        break;
                    }
                }



                _mission_daily_data.Add(temp);

            }
        }
    }

    void Init_ShopItemData()
    {
        _shop_item_data = new List<GameData_ShopItem>();

        string text = _shop_item_csv.text;

        // StringReader는 1줄 씩 읽기 위해서 쓰이는 기능
        using (StringReader reader = new StringReader(text))
        {
            // 밑의 RaadLine이 실행되면 자동으로 다음줄로 넘어감
            // 첫번째 줄은 컬럼 이름이기때문에 쓰지 않기 위해 아래행을 실행한거임
            string line = reader.ReadLine();

            // 두번째줄 부터 불러올때는 이렇게 한줄을 강제로 읽고 시작
            // while문으로 인해 파일의 끝행에 이를때까지 한줄씩 찍어옴
            while ((line = reader.ReadLine()) != null)
            {
                // csv 값이므로 ',' seperator 로 데이터를 분리해서 저장
                string[] record = line.Split(',');

                // 한줄의 데이터 개수는 3개다 라고 단언하는 거임. 넘어가면 오류가 남
                Debug.Assert(record.Length == 4);

                GameData_ShopItem temp = new GameData_ShopItem();
                temp.id = int.Parse(record[0]);
                temp.name = record[1];
                temp.price = int.Parse(record[2]);
                temp.sprite = record[3];

                _shop_item_data.Add(temp);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
