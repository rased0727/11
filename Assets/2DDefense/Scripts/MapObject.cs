using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Team
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
        //체력 초기화
        _hp = _maxHp;
        RefreshHpBar();
        UpdateHpBarPos();

        //팀 초기화
        _gameDir = transform.parent.parent.GetComponent<GameDirector>();

        if(transform.parent != null)
        {
            if (transform.parent.gameObject.name == "Red")
            {
                _team = Team.RED;
            }
            else if (transform.parent.gameObject.name == "Blue")
            {
                _team = Team.BLUE;
            }
        }
        
    }
    
    // 체력바 초기화 및 연동
    protected void RefreshHpBar()
    {
        // 체력바 초기화 및 연동
        if (_hpBarTrans != null)
        {
            // fill 이미지 컴포넌트 찾기
            Image fillImg = _hpBarTrans.Find("fill").GetComponent<Image>();
            // 최대 체력 대비 현재 체력 비율을 fillAmount 에 넣어줌
            fillImg.fillAmount = (float)_hp / (float)_maxHp; // fillAmount는 float 이기 때문에 _hp와 _maxHp의 경우 int 여서 형변환 해줌.
        }
    }

    public virtual void DoDamage(int damage)
    {
        _hp -= damage;
        _hp = Math.Max(_hp, 0); // _hp와 0 을 비교해서 큰 값을 넣어준다. 즉 최소값을 0으로 제한하는 코드

        // 체력 연동 함수 호출
        RefreshHpBar();

        // 피격 이펙트 재생 함수 호출
        if (_hitEffectTemplate != null)
        {
            PlayHitEffect();
        }

    }

    // 피격 이펙트 재생
    void PlayHitEffect()
    {
        GameObject hitEffObj = Instantiate(_hitEffectTemplate);
        hitEffObj.SetActive(true);
        hitEffObj.transform.position = transform.position;
    }

    protected void UpdateHpBarPos() // 체력바가 항상 유닛을 따라 다니도록 해주는 메서드
    {
        // 이 유닛의 위치를 가져와서 (월드 좌표)
        Vector3 unitPos = transform.position;

        // 위에서 가져온 월드좌표를 UI좌표(스크린 좌표)로 변환
        Vector3 screenPos = Camera.main.WorldToScreenPoint(unitPos + _hpBarOffset);

        // 혹시 _hpBarTrans 객체에 아직 아무것도 들어 있지 않다면 널체크
        if (_hpBarTrans != null)
        {
            // 체력바의 UI좌표를 위에서 변환한 캐릭터의 UI좌표로 바꿔줌
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
            
            if (arrow != null) // 화살인 경우
            {
                if (arrow._team == _team) // 같은 팀일 경우 통과
                {
                    return;
                }
                Destroy(arrow.gameObject); // 다른 팀일 경우 화살을 충돌 시킨후 없애주기
            }
            else // 화살이 아닌 경우
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
