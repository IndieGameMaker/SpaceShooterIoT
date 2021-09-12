#pragma warning disable IDE0051

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{

    // 콜백함수(Call Back Function) , 이벤트(Event)
    void OnCollisionEnter(Collision coll)
    {
        // if (coll.gameObject.tag == "BULLET")
        if (coll.gameObject.CompareTag("BULLET"))
        {
            Debug.Log("총알 충돌했음 !!!");
            Destroy(coll.gameObject);
        }
    }
}
