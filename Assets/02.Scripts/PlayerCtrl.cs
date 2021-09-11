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
    public float turnSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 컴포넌트를 추출해서 변수에 대입
        anim = GetComponent<Animation>();
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

        // Translate(이동방향 * 속도)
        /*
            정규화 벡터(Normalized Vector), 단위 벡터(Unit Vector)

            Vector3.forward = Vector3(0, 0, 1)
            Vector3.up      = Vector3(0, 1, 0)
            Vector3.right   = Vector3(1, 0, 0)

            Vector3.one = Vector3(1, 1, 1)
            Vector3.zero = Vector3(0, 0, 0)
        */

    }

}


/*
    Animation Type

    - Legacy : 하위 호환성 , Code (Animation 컴포넌트)

    - Mecanim : Visual Editor (Animator 컴포넌트)
        - Generic
        - Humanoid : Retargetting, 2족 보행, 15개 필수 Born

*/