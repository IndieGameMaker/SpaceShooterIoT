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
            Debug.Log("총알 충돌했음 !!!");
            Destroy(coll.gameObject);

            Instantiate(sparkEffect, coll.GetContact(0).point, Quaternion.identity);
        }
    }
}
/*
    OnCollisionEnter    1
    OnCollisionStay     n
    OnCollisionExit     1
*/
