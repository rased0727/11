using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class FloorManager : MonoBehaviour
    {

        public static FloorManager I;


        public List<GameObject> _floorList;


        [SerializeField] GameObject[] _templates; // ���� ���ø� �迭

        void Awake()
        {
            I = this;
        }

        // Start is called before the first frame update
        public void Init()
        {

            // �÷ξ� �ε�
            string floorList = UserData.I.FloorList;

            GameObject blockObj = transform.Find("block").gameObject;
            Block block = blockObj.GetComponent<Block>();

            if (string.IsNullOrEmpty(floorList) == false)//�� ���ڿ��� �ƴ� ��
            {
                // ���ø�(split) �Լ��� �Ἥ, �޸��� ���е� floor ������ ��������
                string[] floorArray = floorList.Split(", ");
                foreach (string floorName in floorArray)
                {
                    foreach (GameObject t in _templates)
                    {
                        if (t.name == floorName)
                        {
                            _Create(t, blockObj.transform.position);
                            block.Raise(); //  �÷ξ� ���� ��, ��� �÷��ֱ�

                            break;
                        }
                    }
                }
            }
        }

        public void Create(Vector3 blockPos) //�������� ����
        {
            int choice = Random.Range(0, _templates.Length);

            GameObject template = _templates[choice];

            _Create(template, blockPos);

            // �������̷� ����
            UserData.I.SaveFloor(template.name);
        }

        void _Create(GameObject template, Vector3 blockPos) // �����ؼ� ����
        {
            GameObject obj = Instantiate(template);
            obj.SetActive(true);
            obj.name = template.name;


            // �޾ƿ� ����� ��ġ�� ���� ������ ���忡�� �Ѱ��ְ�
            obj.transform.position = blockPos;
            obj.transform.parent = transform; // �÷ξ� �Ŵ����� �ڽİ�ü�� �д�
            _floorList.Add(obj);


        }

    }
}
