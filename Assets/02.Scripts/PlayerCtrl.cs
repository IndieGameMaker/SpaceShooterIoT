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

        // 콘솔뷰에 메시지를 출력
        Debug.Log("h=" + h + ",v=" + v);

        // Translate(이동방향 * 속도)
        transform.Translate(Vector3.forward * 0.1f * v);
        transform.Translate(Vector3.right * 0.1f * h);

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
