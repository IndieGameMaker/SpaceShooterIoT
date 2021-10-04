using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCtrl : MonoBehaviour
{
    /*
        파스칼 표기법(Pascal Phase) - 클래스, 메소드(함수) 명
        낙타형 표기법(Camel Phase)  - 변수명
    */

    private Animation anim;

    // 이동속도
    public float moveSpeed = 8.0f;  // 낙타형 표기법 (Camel)
    // 회전속도
    public float _turnSpeed = 100.0f;
    private float turnSpeed;

    // HP
    private float initHp = 100.0f; // 초기 생명수치
    private float currHp = 100.0f; // 현재 생명수치

    private GameManager gameManager;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // 컴포넌트를 추출해서 변수에 대입
        anim = this.gameObject.GetComponent<Animation>();

        anim.Play("Idle");

        turnSpeed = 0.0f;
        yield return new WaitForSeconds(0.3f);
        turnSpeed = _turnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        float v = Input.GetAxis("Vertical");  // -1.0f ~ 0.0f ~ +1.0f
        float r = Input.GetAxis("Mouse X");

        // (전진후진벡터) + (좌우벡터)
        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);

        // Debug.Log("dir=" + dir.magnitude);
        // Debug.Log("정규화 벡터 dir=" + dir.normalized.magnitude);

        // 이동처리
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);

        // 회전처리
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * r);

        // 애니메이션 처리
        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)
    {
        if (v >= 0.1f) // 전진
        {
            // 애니메이션을 부드럽게 전환
            anim.CrossFade("RunF", 0.3f);
        }
        else if (v <= -0.1f) // 후진
        {
            anim.CrossFade("RunB", 0.3f);
        }
        else if (h >= 0.1f) // 오른쪽
        {
            anim.CrossFade("RunR", 0.3f);
        }
        else if (h <= -0.1f) // 왼쪽
        {
            anim.CrossFade("RunL", 0.3f);
        }
        else
        {
            anim.CrossFade("Idle", 0.3f);
        }
    }

    /*
        void OnCollisionEnter, ~ Exit, ~ Stay
        void OnTriggerEnter, ~ Exit, ~ Stay
    */
    void OnTriggerEnter(Collider coll)
    {
        if (currHp > 0.0f && coll.CompareTag("PUNCH"))
        {
            currHp -= 10.0f;
            if (currHp <= 0.0f)
            {
                PlayerDie();
            }
        }
    }

    void PlayerDie()
    {
        gameManager.IsGameOver = true;

        //Debug.Log("주인공 사망 !!!");
        // 스테이지에 있는 모든 몬스터를 검색(Tag)
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("MONSTER");

        foreach (GameObject monster in monsters)
        {
            monster.SendMessage("YouWin", SendMessageOptions.DontRequireReceiver);
        }
    }

}



/*
    Animation Type

    - Legacy : 하위 호환성 , Code (Animation 컴포넌트)

    - Mecanim : Visual Editor (Animator 컴포넌트)
        - Generic
        - Humanoid : Retargetting, 2족 보행, 15개 필수 Born

*/