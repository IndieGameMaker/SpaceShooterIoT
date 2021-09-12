using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            // 총알 생성
            // Instantiate (생성할객체, 위치, 각도)
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}
