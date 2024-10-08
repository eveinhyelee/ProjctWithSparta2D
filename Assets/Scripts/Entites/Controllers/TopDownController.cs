using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    protected bool IsAttacking { get; set;}
    // protected ������Ƽ�� �� ���� : ���� �ٲٰ������ �������°� �� ��ӹ޴� Ŭ�����鵵 ���� �ְ�
    protected CharacterStatsHandler stats { get; private set; }

    private float timeSinceLastAttack = float.MaxValue;

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatsHandler>();
    }

    private void Update()
    {
        HandleAttackDelaty();
    }

    private void HandleAttackDelaty()
    {  
        if (timeSinceLastAttack < stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if(IsAttacking && timeSinceLastAttack >= stats.CurrentStat.attackSO.delay)
        { 
            timeSinceLastAttack = 0f;
            CallAttackEvent();
        }
    }


    public void CallMoveEvent(Vector2 direction)
    { 
        OnMoveEvent?.Invoke(direction); //?. ������ ����, ������ �����Ѵ�.
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    private void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
