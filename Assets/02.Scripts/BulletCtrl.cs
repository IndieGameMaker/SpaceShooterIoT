using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 제너릭(Generic) GetComponent<T>()
        // rb = GetComponent("Rigidbody") as Rigidbody;
        // rb = (Rigidbody)GetComponent("Rigidbody");

        rb.AddRelativeForce(Vector3.forward * 800.0f);
    }

}
