using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] float m_speed = 1.0f;

    void Update()
    {
        transform.position += new Vector3(0, 0, 1f) * Time.deltaTime * m_speed;
    }
}
