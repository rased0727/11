using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    // Inventory ��ü�� ������ ����Ʈ�� Ȯ���ؼ�
    // �״�� �κ��丮 UI ȭ�鿡 �ѷ��ش�


    public class UI_Inventory : MonoBehaviour
    {
        public List<UI_InvenItem> _itemList;

        public GameObject _itemTemplate;

        // Start is called before the first frame update
        void Start()
        {
            // ������ ���ø� ��������(���۽� ������)
            _itemTemplate = transform.Find("Scroll View/Viewport/Content/UI_InvenItem(template)").gameObject;
            _itemTemplate.SetActive(false);

            UI_InvenItem[] array = GetComponentsInChildren<UI_InvenItem>();

            // List�� ������(�迭)�� ������� ���� AddRange �Լ� ����
            // (�� ���� ������� ���� Add �Լ�)
            _itemList.AddRange(array);


            // Inventory ��ü�� _itemList�� Ȯ���ؼ�, �� �������
            // UI_InvenItem �� �������ش�.
            for(int i=0; i< Inventory.I._itemList.Count; i++)
            {
                GameObject cloneObj = Instantiate(_itemTemplate);
                cloneObj.transform.parent = _itemTemplate.transform.parent;
                cloneObj.SetActive(true);
            }

        }
        public void Add()
        {
            GameObject cloneObj = Instantiate(_itemTemplate);
            cloneObj.transform.parent = _itemTemplate.transform.parent;
            cloneObj.SetActive(true);
        }
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
