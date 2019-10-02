using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//카메라
public class CameraShake : MonoBehaviour
{
    [SerializeField] float m_force = 0f;           //카메라의 힘세기
    [SerializeField] Vector3 m_Dir = Vector3.zero; //카메라의 흔들림방향

    Quaternion m_originRot; //카메라의 초기값을 저장하는 쿼터니온 변수
    // Start is called before the first frame update
    void Start()
    {
        m_originRot = transform.rotation;
    }//void Start()

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(ShakeCoroutine());
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            StopAllCoroutines();
            StartCoroutine(Reset());
        }
    }//void Update()

    IEnumerator ShakeCoroutine()
    {
        Vector3 t_originEuler = transform.eulerAngles; // 현재 오일러값을 임시 변수에 담는다 
        while (true)
        {
            float t_rotX = Random.Range(-m_Dir.x, m_Dir.x);
            float t_rotY = Random.Range(-m_Dir.y, m_Dir.y);
            float t_rotZ = Random.Range(-m_Dir.z, m_Dir.z);

            //흔들림 값 = 초기값 + 랜덤값 

            Vector3 t_RandomRot = t_originEuler + new Vector3(t_rotX, t_rotY, t_rotZ);

            //흔들림값을 쿼터니온으로 변환 

            Quaternion t_rot = Quaternion.Euler(t_RandomRot);

            //카메라를 목표 값 쿼터니온 값으로 회전시킨다 
            //
            while (Quaternion.Angle(transform.rotation, t_rot) > 0.1f)
            {
                // Quaternion.Slerp 이랑 똑같은기능 Quaternion.RotateTowards
                transform.rotation = Quaternion.RotateTowards(transform.rotation, t_rot, m_force * Time.deltaTime);
                yield return null;
            }
            yield return null;
        }
    }//    IEnumerator ShakeCoroutine()

    IEnumerator Reset()
    {
        while (Quaternion.Angle(transform.rotation, m_originRot) > 0f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_originRot, m_force * Time.deltaTime);
            yield return null;
        }
    }//IEnumerator Reset()
}//public class CameraShake : MonoBehaviour
