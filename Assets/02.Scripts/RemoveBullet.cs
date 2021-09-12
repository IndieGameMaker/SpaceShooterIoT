#pragma warning disable IDE0051

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    // 콜백함수(Call Back Function) , 이벤트(Event)
    void OnCollisionEnter(Collision coll)
    {
        // if (coll.gameObject.tag == "BULLET") ==> Garbage Collection
        if (coll.gameObject.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);

            ContactPoint cp = coll.GetContact(0);
            // 충돌한 객체의 법선벡터(반대 방향의 벡터)
            Vector3 _normal = -cp.normal;

            //쿼터니언 타입의 각도
            Quaternion rot = Quaternion.LookRotation(_normal);

            GameObject obj = Instantiate(sparkEffect, cp.point, rot);
            Destroy(obj, 0.4f);
        }
    }
}
/*
    OnCollisionEnter    1
    OnCollisionStay     n
    OnCollisionExit     1

    쿼터니언 (Quaternion) 사원수 (x, y, z, w) : 복소수 4차원벡터

    오일러회전(Euler) x -> y -> z
    짐벌락(Gimbal Lock) : 김벌락


    Audio

    AudioListner : 소리를 듣는 역할, 씬에 1개만 존재해야 함.
    AudioSource  : 소리를 발생시키는 역할, 복수가능.
*/
