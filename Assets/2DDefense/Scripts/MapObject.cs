using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour
{
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
        Destroy(gameObject);
        Destroy(_hpBarTrans.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.tag == "AttackCol")
        {
            DoDamage(10);

            // ȭ�� ������ �� �� ȭ�� �����ֱ�
            Arrow arrow = collison.gameObject.GetComponent<Arrow>();
            if (arrow != null)
            {
                Destroy(arrow.gameObject);
            }

        }
    }


}
