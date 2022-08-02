using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace RoomEscape
{
	public class SceneObject : MonoBehaviour
	{
		public RectTransform _infoTextTrans;
		public string _infoText;
		void Start()
		{
		}
		void Update()
		{
		}
		private void OnMouseEnter()
		{
			Debug.Log("OnMouseEnter: " + gameObject.name);

			_infoTextTrans.gameObject.SetActive(true);
			Text text = _infoTextTrans.GetComponent<Text>();
			text.text = _infoText;

		}
		private void OnMouseExit()
		{
			Debug.Log("OnMouseExit: " + gameObject.name);
			_infoTextTrans.gameObject.SetActive(false);

		}
	}
}
