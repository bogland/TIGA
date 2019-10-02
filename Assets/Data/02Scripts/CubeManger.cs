using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManger : MonoBehaviour
{
    public static CubeManger _uniqueInstance;
    [SerializeField] GameObject[] m_cube;

    public GameObject[] CUBE
    {
        get { return m_cube; }
        set { m_cube = value; }
    }

    void Start()
    {
        _uniqueInstance = this;

        for (int n = 0; n < m_cube.Length; n++)
        {
            GameObject go = Instantiate(m_cube[Random.Range(0, m_cube.Length)], new Vector3(Random.Range(-3.5f, 3.5f), 1, 0), Quaternion.identity);
            go.transform.parent = transform;
        }
        //CubeList.Add(new Item(m_cube[0], 0, "Red Cube", "This is Red Cube!"));
        //CubeList.Add(new Item(m_cube[1], 1, "Blue Cube", "This is Blue Cube!"));
        //CubeList.Add(new Item(m_cube[2], 2, "Green Cube", "This is Green Cube!"));        
    }

}
