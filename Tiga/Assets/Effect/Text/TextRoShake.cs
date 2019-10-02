using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoDialogBox //회전다이알로그박스
{
    [TextArea]  //여러줄
    public string m_TxtDialog;

}//public class RoDialogBox //회전다이알로그박스

public class TextRoShake : MonoBehaviour
{

    [SerializeField] private Text m_txtDialog;

    public int m_count = 0;    //대사카운트

    private bool isDialog = false;

    [SerializeField] private DialogBox[] m_DialogBox;

    [SerializeField] float m_force = 0f;           //힘세기

    [SerializeField] Vector3 m_RoDir = Vector3.zero; //흔들림 방향

    Quaternion m_OriginRot; //카메라의 초기값을 저장하는 쿼터니온 변수
    // Start is called before the first frame update
    void Start()
    {
        m_OriginRot = m_txtDialog.transform.rotation;
    }//void Start()

    public void ShowDialog()
    {

        OnOff(true);
        m_count = 0;

        //isDialog = true;
        NextDialog();
    }//    public void ShowDialog()

    private void OnOff(bool _flag)
    {
        m_txtDialog.gameObject.SetActive(_flag);

        isDialog = _flag;
    }//private void OnOff(bool _flag)

    private void NextDialog()
    {
        m_txtDialog.text = m_DialogBox[m_count].m_TxtDialog;
        m_count++;
    }//private void NextDialog()

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

        if (isDialog)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (m_count < m_DialogBox.Length)
                    NextDialog();
                else
                    OnOff(false);
            }
        }//   if (isDialog)
    }//void Update()

    IEnumerator ShakeCoroutine()
    {
        Vector3 a_originEuler = transform.eulerAngles; // 현재 오일러값을 임시 변수에 담는다 
        while (true)
        {
            float a_rotX = Random.Range(-m_RoDir.x, m_RoDir.x);
            float a_rotY = Random.Range(-m_RoDir.y, m_RoDir.y);
            float a_rotZ = Random.Range(-m_RoDir.z, m_RoDir.z);

            //흔들림 값 = 초기값 + 랜덤값 

            Vector3 a_RandomRot = a_originEuler + new Vector3(a_rotX, a_rotY, a_rotZ);

            //흔들림값을 쿼터니온으로 변환 

            Quaternion a_rot = Quaternion.Euler(a_RandomRot);

            //카메라를 목표 값 쿼터니온 값으로 회전시킨다 
            //
            while (Quaternion.Angle(m_txtDialog.transform.rotation, a_rot) > 0.1f)
            {
                // Quaternion.Slerp 이랑 똑같은기능 Quaternion.RotateTowards
                m_txtDialog.transform.rotation = Quaternion.RotateTowards(m_txtDialog.transform.rotation, a_rot, m_force * Time.deltaTime);
                yield return null;
            }
            yield return null;
        }
    }//    IEnumerator ShakeCoroutine()

    IEnumerator Reset()
    {
        while (Quaternion.Angle(m_txtDialog.transform.rotation, m_OriginRot) > 0f)
        {
            transform.rotation = Quaternion.RotateTowards(m_txtDialog.transform.rotation, m_OriginRot, m_force * Time.deltaTime);
            yield return null;
        }
    }//IEnumerator Reset()
}
