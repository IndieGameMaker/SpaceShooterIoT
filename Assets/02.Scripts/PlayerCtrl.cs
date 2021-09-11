using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        float v = Input.GetAxis("Vertical");  // -1.0f ~ 0.0f ~ +1.0f
        float r = Input.GetAxis("Mouse X");

        // 콘솔뷰에 메시지를 출력
        // Debug.Log("h=" + h + ",v=" + v);

        // (전진후진벡터) + (좌우벡터)
        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);

        Debug.Log("dir=" + dir.magnitude);
        Debug.Log("정규화 벡터 dir=" + dir.normalized.magnitude);

        // 이동처리
        transform.Translate(dir.normalized * 0.1f);

        // 회전처리
        transform.Rotate(Vector3.up * 100.0f * r);

        // Translate(이동방향 * 속도)
        // transform.Translate(Vector3.forward * 0.1f * v);
        // transform.Translate(Vector3.right * 0.1f * h);

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
