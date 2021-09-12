using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FireCtrl : MonoBehaviour
{
    [SerializeField]
    private new AudioSource audio;

    public GameObject bulletPrefab;
    public Transform firePos;
    public AudioClip fireSfx;

    [System.NonSerialized]
    [HideInInspector]
    public MeshRenderer muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
        muzzleFlash.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Fire();
        }
    }

    void Fire()
    {
        // 총알 생성
        // Instantiate (생성할객체, 위치, 각도)
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        // 사운드 발생
        audio.PlayOneShot(fireSfx, 0.8f);

        // 총구화염 효과
        StartCoroutine(ShowMuzzleFlash());
    }

    IEnumerator ShowMuzzleFlash()
    {
        // (0, 0), (0.5, 0) , (0, 0.5), (0.5, 0.5) 
        /*
        Random.Range(0, 3) ==> 0, 1, 2 
        Random.Range(0.0f, 3.0f) ==> 0.0f ~ 3.0f
        */
        // 텍스처의 오프셋을 변경
        Vector2 offset = new Vector2(Random.Range(0, 2) * 0.5f, Random.Range(0, 2) * 0.5f);
        muzzleFlash.material.mainTextureOffset = offset;

        // 크기변경
        float scale = Random.Range(1.0f, 3.0f);
        muzzleFlash.transform.localScale = Vector3.one * scale; // new Vector3(scale, scale, scale)

        // MuzzleFlash의 회전
        float angle = Random.Range(0, 360);
        muzzleFlash.transform.localRotation = Quaternion.Euler(Vector3.forward * angle);

        // MeshRenderer 컴포넌트를 활성화
        muzzleFlash.enabled = true;

        // Waitting...
        yield return new WaitForSeconds(0.2f);

        // MeshRenderer 컴포넌트를 비활성화
        muzzleFlash.enabled = false;
    }
}


/*
    Muzzle Flash (총구 화염)


*/
