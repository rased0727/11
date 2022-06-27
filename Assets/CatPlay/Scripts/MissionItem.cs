using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CatPlay
{
	public class MissionItem : MonoBehaviour
	{
		public Text _nameTxt;
		public Text _clearCountTxt;
		public Text _rewardTxt;
		public Image _rewardIcon;

		void Start()
        {
			_nameTxt = transform.Find("Name").GetComponent<Text>();
			_clearCountTxt = transform.Find("ClearCount").GetComponent<Text>();
			_rewardTxt = transform.Find("RewardValue").GetComponent<Text>();
			_rewardIcon = transform.Find("RewardIcon").GetComponent<Image>();
		}
        public void SetData(GameData_MissionDaily data)
        {
			// 데이터를 받아서 실제 그 데이터로 내용들을 표시를 한다.
			// 미션이름
			_nameTxt.text = data.name;

			// 진행횟수, 총 완료 횟수(ClearCount)
			int currentCount = 0;
			int totalCount = data.clearCount;
			//_clearCountTxt.text = string.Format("{0}/{1}", currentCount,totalCount);
			_clearCountTxt.text = string.Format($"{currentCount}/{totalCount}");

			// 보상
			_rewardTxt.text = data.gem_reward.ToString();

			// 보상 아이콘
			_rewardIcon.sprite = data.reward_icon_sp;

		}
	}
}

