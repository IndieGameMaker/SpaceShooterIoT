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

    public float attackDist = 2.0f; //공격 사정거리
    public float traceDist = 10.0f; //추적 사정거리

    private Transform playerTr;
    private Transform monsterTr;

    private NavMeshAgent agent;
    private Animator anim;

    public bool isDie = false;

    private int hashTrace = Animator.StringToHash("IsTrace");
    private int hashAttack = Animator.StringToHash("IsAttack");
    private int hashHit = Animator.StringToHash("Hit");
    private int hashDie = Animator.StringToHash("Die");

    private float hp = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        monsterTr = GetComponent<Transform>(); // monsterTr = transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        StartCoroutine(CheckMonsterState());
        StartCoroutine(MonsterAction());
    }

    // 몬스터의 상태를 체크하는 코루틴
    IEnumerator CheckMonsterState()
    {
        while (isDie == false)
        {
            // 몬스터와 주인공간의 거리를 계산
            float distance = Vector3.Distance(monsterTr.position, playerTr.position);

            if (distance <= attackDist)     // 공격사정거리 이내일 경우
            {
                state = State.ATTACK;
            }
            else if (distance <= traceDist) // 추적사정거리 이내인 경우
            {
                state = State.TRACE;
            }
            else
            {
                state = State.IDLE;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    // 몬스터의 상태값에 따라서 행동을 처리하는 코루틴
    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (state)
            {
                case State.IDLE:
                    // 추적 정지
                    agent.isStopped = true;
                    // Idle 애니메이션으로 되돌아가기
                    anim.SetBool(hashTrace, false);
                    break;
                case State.ATTACK:
                    // Attack 애니메이션 실행
                    anim.SetBool(hashAttack, true);
                    monsterTr.LookAt(playerTr.position);
                    break;
                case State.TRACE:
                    // 추적 시작
                    agent.SetDestination(playerTr.position);
                    agent.isStopped = false;
                    // Walk 애니메이션 실행
                    anim.SetBool(hashTrace, true);
                    anim.SetBool(hashAttack, false);
                    break;
                case State.DIE:
                    //
                    break;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);
            anim.SetTrigger(hashHit);
            hp -= 20.0f;
            if (hp <= 0.0f)
            {
                MonsterDie();
            }
        }
    }

    void MonsterDie()
    {
        isDie = true;
        StopAllCoroutines();
        agent.isStopped = true;
        anim.SetTrigger(hashDie);
        GetComponent<CapsuleCollider>().enabled = false;
    }
}

/*
    유한상태머신(Finite State Machine) FSM
    - NPC AI 구현하기 위한 기법(방식)

    - HFSM
    - BT
*/