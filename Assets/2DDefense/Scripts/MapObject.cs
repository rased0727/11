using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Team // ������ ����� ������ �����صΰ� �Ʒ����� �θ�ü�� �̸��� �ľ� �� ���� �����ֱ�
{
    NONE,

    BLUE,
    RED,
}

public class MapObject : MonoBehaviour
{
    public Team _team;
    public GameDirector _gameDir;

    public RectTransform _hpBarTrans;
    public Vector3 _hpBarOffset;
    public int _maxHp = 100;
    public int _hp = 0;

    public GameObject _hitEffectTemplate;

    protected virtual void Start()
    {
        //ü�� �ʱ�ȭ
        _hp = _maxHp;
        RefreshHpBar();
        UpdateHpBarPos();

        //�� �ʱ�ȭ
        _gameDir = transform.parent.parent.GetComponent<GameDirector>();

        if(transform.parent != null)
        {
            if (transform.parent.gameObject.name == "Red") // ��� �����̳� �ǹ����� ���� �̸��� ���� �ִ� �θ�ü�� ���� �ִµ�, �װ����� ������ �ҽ��ڵ忡�� ��ġ���ش�.
            {
                _team = Team.RED;
            }
            else if (transform.parent.gameObject.name == "Blue")
            {
                _team = Team.BLUE;
            }
        }
        
    }
    
    // ü�¹� �ʱ�ȭ �� ����
    protected void RefreshHpBar()
    {
        // ü�¹� �ʱ�ȭ �� ����
        if (_hpBarTrans != null)
        {
            // fill �̹��� ������Ʈ ã��
            Image fillImg = _hpBarTrans.Find("fill").GetComponent<Image>();
            // �ִ� ü�� ��� ���� ü�� ������ fillAmount �� �־���
            fillImg.fillAmount = (float)_hp / (float)_maxHp; // fillAmount�� float �̱� ������ _hp�� _maxHp�� ��� int ���� ����ȯ ����.
        }
    }

    public virtual void DoDamage(int damage)
    {
        _hp -= damage;
        _hp = Math.Max(_hp, 0); // _hp�� 0 �� ���ؼ� ū ���� �־��ش�. �� �ּҰ��� 0���� �����ϴ� �ڵ�

        // ü�� ���� �Լ� ȣ��
        RefreshHpBar();

        // �ǰ� ����Ʈ ��� �Լ� ȣ��
        if (_hitEffectTemplate != null)
        {
            PlayHitEffect();
        }

    }

    // �ǰ� ����Ʈ ���
    void PlayHitEffect()
    {
        GameObject hitEffObj = Instantiate(_hitEffectTemplate);
        hitEffObj.SetActive(true);
        hitEffObj.transform.position = transform.position;
    }

    protected void UpdateHpBarPos() // ü�¹ٰ� �׻� ������ ���� �ٴϵ��� ���ִ� �޼���
    {
        // �� ������ ��ġ�� �����ͼ� (���� ��ǥ)
        Vector3 unitPos = transform.position;

        // ������ ������ ������ǥ�� UI��ǥ(��ũ�� ��ǥ)�� ��ȯ
        Vector3 screenPos = Camera.main.WorldToScreenPoint(unitPos + _hpBarOffset);

        // Ȥ�� _hpBarTrans ��ü�� ���� �ƹ��͵� ��� ���� �ʴٸ� ��üũ
        if (_hpBarTrans != null)
        {
            // ü�¹��� UI��ǥ�� ������ ��ȯ�� ĳ������ UI��ǥ�� �ٲ���
            _hpBarTrans.position = screenPos;
        }
    }
    protected void Disappear()
    {
        if (_team == Team.RED)
        {
            List<GameObject> redList = new List<GameObject>(_gameDir._red_List);
            redList.Remove(gameObject);

            _gameDir._red_List = redList.ToArray();
        }
        else if (_team == Team.BLUE)
        {
            List<GameObject> blueList = new List<GameObject>(_gameDir._blue_List);
            blueList.Remove(gameObject);

            _gameDir._blue_List = blueList.ToArray();
        }
        Destroy(gameObject);

        if (_hpBarTrans != null)
        {
            Destroy(_hpBarTrans.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.tag == "AttackCol")
        {
            
            Arrow arrow = collison.gameObject.GetComponent<Arrow>();
            
            if (arrow != null) // ȭ���� ���
            {
                if (arrow._team == _team) // ���� ���� ��� ���
                {
                    return;
                }
                Destroy(arrow.gameObject); // �ٸ� ���� ��� ȭ���� �浹 ��Ų�� �����ֱ�
            }
            else // ȭ���� �ƴ� ���
            {
                MapObject attacker = collison.transform.parent.GetComponent<MapObject>();
                if (attacker != null)
                {
                    if (attacker._team == _team)
                    {
                        return;
                    }
                }
            }
            DoDamage(10);

        }
    }


}
