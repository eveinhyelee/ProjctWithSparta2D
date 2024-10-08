using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    //�⺻���ݰ� �߰����ݵ��� ��귡�� ���� ������ ��� �ϴ� ������ ����
    //������ �׳� �⺻ ���ݸ�

    [SerializeField] private CharacterStat baseStat;
    public CharacterStat CurrentStat { get; private set; }
    
    public List<CharacterStat> statModifiers = new List<CharacterStat>(); //�߰����ݸ���Ʈ

    private void Awake()
    {
        UpdateChracterStat();
    }

    private void UpdateChracterStat()
    {
        AttackSO attackSO = null;
        if (baseStat.attackSO != null)
        { 
            attackSO = Instantiate(baseStat.attackSO);
        }
        CurrentStat = new CharacterStat { attackSO = attackSO };
        //TODO ::������ �⺻ �ɷ�ġ�� ���������, �����δ� �ɷ�ġ��ȭ����� ����ȴ�.
        CurrentStat.statsChangType = baseStat.statsChangType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed = baseStat.speed;
    }
}