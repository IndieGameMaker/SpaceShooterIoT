using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    // 몬스터의 상태 정의
    public enum State
    {
        IDLE,
        TRACE,
        ATTACK,
        DIE
    }
    // 몬스터의 상태를 저장할 변수
    public State state = State.IDLE;

    public Transform playerTr;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerTr.position);
    }
}

/*
    유한상태머신(Finite State Machine) FSM
    - NPC AI 구현하기 위한 기법(방식)

    - HFSM
    - BT
*/