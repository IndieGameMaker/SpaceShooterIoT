using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    // 총알의 충돌 횟수를 누적
    private int hitCount = 0;
    // 폭발효과 프리팹
    [SerializeField] private GameObject expEffect;
    // 텍스처를 저장하기 위한 배열
    public Texture[] textures;
    // 하위에 있는 MeshRenderer 컴포넌트를 저장하기 위한 변수
    public MeshRenderer renderer;

    void Start()
    {
        expEffect = Resources.Load<GameObject>("BigExplosionEffect");
        renderer = GetComponentInChildren<MeshRenderer>();

        int idx = Random.Range(0, textures.Length); // Random.Range(0, 3) => 0, 1, 2
        // 하위에 있는 MeshRenderer에 연결된 머티리얼의 텍스처를 변경
        renderer.material.mainTexture = textures[idx];
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3)
            {
                // 드럼통을 폭발
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 1200.0f);

        Destroy(this.gameObject, 2.0f);
        GameObject obj = Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(obj, 5.0f);
    }
}
