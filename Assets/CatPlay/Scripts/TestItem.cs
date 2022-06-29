using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CatPlay
{
	public class TestItem : MonoBehaviour
	{
		public Text _id;
		public Text _nameTxt;
		public Text _price;
		public Text _icon_sprite_sp;
		

		void Start()
		{
			_id = transform.Find("Id").GetComponent<Text>();
			_nameTxt = transform.Find("Name").GetComponent<Text>();
			_price = transform.Find("Price").GetComponent<Text>();
			_icon_sprite_sp = transform.Find("Icon").GetComponent<Text>();
		}
		public void SetData(GameData_TestItem data)
		{
			_id.text = data.id.ToString();
			_nameTxt.text = data.name;
			_price.text = data.price.ToString();
			_icon_sprite_sp.text = data.icon_sp;

		}
	}
}

