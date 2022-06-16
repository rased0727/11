using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatPlay
{
	public class MissionDailyUI : MonoBehaviour
	{
		public GameData _gameData;
		public List<MissionItem> _itemList;
	    void Start()
	    {
			MissionItem[] array = GetComponentsInChildren<MissionItem>();
			// List에 하나를 집어넣을때는 Add, 많이 넣을때는 AddRange
			_itemList.AddRange(array);

			List<GameData_MissionDaily> missionDataList = _gameData._mission_daily_data;
			for (int i = 0; i < _itemList.Count; i++)
            {
				GameData_MissionDaily data = missionDataList[i];
				MissionItem item = _itemList[i];
				item.SetData(data); // 일일 미션 데이터를 각 항목에 넣어준다.
			}
	    }
	    void Update()
	    {
	        
	    }
	}
}

