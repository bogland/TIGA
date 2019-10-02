using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogBox
{
    [TextArea]  //여러줄
    public string m_TxtDialog;
    // public Sprite m_CG;
}

public class TextShake : MonoBehaviour
{
    [SerializeField] private Text m_txtDialog;

    public int m_count = 0;    //대사카운트

    private bool isDialog = false;

    [SerializeField] private DialogBox[] m_DialogBox;

   
    [SerializeField] Vector3 m_PoDir = Vector3.zero; //흔들림방향



    Vector2 m_Origintxt;    //월래위치 저장값
    float next_time;
    public float wait_time;
    // Start is called before the first frame update
    private void Start()
    {
        //Debug.Log("Start");
        // Debug.Log(m_txtDialog.rectTransform.anchoredPosition);
        m_Origintxt = m_txtDialog.rectTransform.anchoredPosition;

        next_time = wait_time;
    }

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("여긴가냐");
            m_PoDir.x = 10;
            m_PoDir.y = 10;
            StartCoroutine(HoriVertiShake());
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            m_PoDir.x = 10;
            m_PoDir.y = 0;
            StartCoroutine(HorizontalShake()); //수평
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            m_PoDir.x = 0;
            m_PoDir.y = 10;
            StartCoroutine(VerticalShake()); //수직
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
        }
    }// void Update()

    IEnumerator HoriVertiShake() //수직 수평
    {


        while (true)
        {
            float a_ranX = Random.Range(-m_PoDir.x, m_PoDir.x);
            float a_ranY = Random.Range(-m_PoDir.y, m_PoDir.y);
            float a_ranZ = Random.Range(-m_PoDir.z, m_PoDir.z);

            //흔들림 값 = 초기값 + 랜덤값 
            Debug.Log("수평수직");


            Vector2 a_RandomTrans = new Vector2(a_ranX, m_Origintxt.y + a_ranY);
            //  Debug.Log(t_rotY);
            // Debug.Log(m_origintxt.x);


            if (next_time < 0.0f)
            {

                m_txtDialog.rectTransform.anchoredPosition = a_RandomTrans;

                next_time = wait_time;
            }

            next_time -= Time.deltaTime;
            yield return null;
        }
    }// IEnumerator HoriVertiShake() //수직 수평

    IEnumerator HorizontalShake() // 수평
    {


        while (true)
        {
            float a_ranX = Random.Range(-m_PoDir.x, m_PoDir.x);
            float a_ranY = Random.Range(-m_PoDir.y, m_PoDir.y);
            float a_ranZ = Random.Range(-m_PoDir.z, m_PoDir.z);

            //흔들림 값 = 초기값 + 랜덤값 
            Debug.Log("수평");

            Vector2 a_RandomTrans = new Vector2(a_ranX, m_Origintxt.y + a_ranY);
            //  Debug.Log(t_rotY);
            // Debug.Log(m_origintxt.x);



            if (next_time < 0.0f)
            {

                m_txtDialog.rectTransform.anchoredPosition = a_RandomTrans;

                next_time = wait_time;
            }

            next_time -= Time.deltaTime;
            yield return null;
        }
    }//IEnumerator HorizontalShake() // 수평

    IEnumerator VerticalShake() //수직
    {


        while (true)
        {
            float a_ranX = Random.Range(-m_PoDir.x, m_PoDir.x);
            float a_ranY = Random.Range(-m_PoDir.y, m_PoDir.y);
            float a_ranZ = Random.Range(-m_PoDir.z, m_PoDir.z);

            //흔들림 값 = 초기값 + 랜덤값 


            Vector2 t_RandomTrans = new Vector2(a_ranX, m_Origintxt.y + a_ranY);


            if (next_time < 0.0f)
            {
                m_txtDialog.rectTransform.anchoredPosition = t_RandomTrans;

                next_time = wait_time;
            }

            next_time -= Time.deltaTime;
            yield return null;
        }
    }//    IEnumerator VerticalShake() //수직

    IEnumerator Reset()
    {
        while (m_txtDialog.rectTransform.anchoredPosition.x > 0f)
        {

            m_txtDialog.rectTransform.anchoredPosition = m_Origintxt;
            Debug.Log(m_txtDialog.rectTransform.anchoredPosition);
            yield return null;
        }
    }//IEnumerator Reset()
}
