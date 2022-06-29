using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatPlay
{
	public class TestItemUI : MonoBehaviour
	{
		public GameData _gameData;
		public List<TestItem> _itemList;
		void Start()
		{
			TestItem[] array = GetComponentsInChildren<TestItem>();
			// List에 하나를 집어넣을때는 Add, 많이 넣을때는 AddRange
			_itemList.AddRange(array);

			List<GameData_TestItem> TestDataList = _gameData._test_item_data;
			for (int i = 0; i < _itemList.Count; i++)
			{
				GameData_TestItem data = TestDataList[i];
				TestItem item = _itemList[i];
				item.SetData(data); // 일일 미션 데이터를 각 항목에 넣어준다.
			}
		}
		void Update()
		{

		}
	}
}