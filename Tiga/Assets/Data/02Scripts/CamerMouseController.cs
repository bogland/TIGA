using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMouseController : MonoBehaviour
{
    int m_getCubeCount;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray a_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit a_hit;
            if(Physics.Raycast(a_ray, out a_hit, 100.0f))
            {
                if (a_hit.collider.tag == "cube")
                {
                    if (!PlayerController._uniqueInstance.GetCube())
                    {// 큐브 획득가능 여부.
                        Debug.Log("인벤토리 꽉 참..");
                        return;
                    }

                    a_hit.transform.GetComponent<cube>().ObjSetActive();
                    m_getCubeCount++;

                    if (m_getCubeCount >= CubeManger._uniqueInstance.CUBE.Length)
                    {// 다음 씬을 저장과 동시에 다음 씬으로 전환시킨다.
                        m_getCubeCount = 0;
                        JsonManager._uniqueInstance.SaveScene((int)BaseSceneManager._uniqueInstance.CURSTATE + 1);
                        PlayerController._uniqueInstance.SavePlayerDataToJson();

                        BaseSceneManager._uniqueInstance.SceneMoveAtGame
                            (BaseSceneManager._uniqueInstance.CURSTATE++);
                    }
                }
            }
        }
    }
}
