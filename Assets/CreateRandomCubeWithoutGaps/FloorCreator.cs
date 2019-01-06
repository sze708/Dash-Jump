using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCreator : MonoBehaviour
{
    [SerializeField] GameObject m_floorObject;
    GameObject m_lastCreatedFloorObject;

    void Start()
    {
        if (m_floorObject == null)
        {
            m_floorObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
        m_lastCreatedFloorObject = m_floorObject;
    }

    void Update()
    {
        if (Camera.main.transform.position.z > m_lastCreatedFloorObject.transform.position.z)
        {
            float zAxisPosition = m_lastCreatedFloorObject.transform.position.z + m_lastCreatedFloorObject.transform.localScale.z / 2;
            m_lastCreatedFloorObject = Instantiate(m_floorObject, new Vector3(0, 0, zAxisPosition), Quaternion.identity);
            m_lastCreatedFloorObject.transform.SetParent(transform);
            float random = Random.Range(0f, 2f);
            m_lastCreatedFloorObject.transform.localScale += new Vector3(1f, 0, 1f) * random;
            m_lastCreatedFloorObject.transform.position += new Vector3(0, 0, 1f) * m_lastCreatedFloorObject.transform.localScale.z / 2;
        }
    }
}
