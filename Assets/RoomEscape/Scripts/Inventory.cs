using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RoomEscape
{
    /*
    public class SceneItemInfo
    {
        public string _name;
        public int _count;

    }
    */
    public class Inventory : MonoBehaviour
    {
        public static Inventory I;

        // �Ʒ� �ҽ��� private�� �ΰ� ������ �ν����Ϳ� �����ְ� ���� �� SerializeField �� ����Ѵ�.
        [SerializeField]List<string> _itemList;
        //public List<SceneItemInfo> _itemList; // ���� SceneItemInfo�� �����ؼ� ����ϴ� ��ĵ� ����

        private void Awake()
        {
            I = this;
        }

        public void AddItem(string itemName)
        {

            if (_itemList.Contains(itemName) == false)
            {
                _itemList.Add(itemName);
            }
            else
            {
                Debug.Log("�̹� �������� ����");
            }
        }
    }
}
