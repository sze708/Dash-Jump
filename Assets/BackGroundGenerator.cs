using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenerator : MonoBehaviour {

    public float ScrollSpeed;


    // Use this for initialization
    void Start()
    {
        //対象オブジェクトのZ軸方向の長さを取得

    }

    // Update is called once per frame
    void Update()
    {
        //z軸方向にオブジェクトを動かす
        this.transform.position += new Vector3(0, 0,Time.deltaTime*-ScrollSpeed);
    }
}
