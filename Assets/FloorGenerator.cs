using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour {

    public GameObject floorPrefab;
    public GameObject Jumper1Prefab;
    public GameObject speedUpItemPrefab;
    //player
    private GameObject player;

    //生成位置
    //Start
    private float startPos = 50;
    private float createPos = 1.5f;
    private float createRoteX = 0;
    private float createPosy = -1f;

    //ジャンプ台生成確立(%)
    private int jumpRandom = 5;
    private int speedRandom = 50;

	// Use this for initialization
	void Start () {


        //playerのgameobjectをとる
        player = GameObject.Find("player");


    }
	
	// Update is called once per frame
	void Update () {

        if (this.player.transform.position.z >= startPos-50) {

            //床を生成
            GameObject floor = Instantiate(floorPrefab) as GameObject;
            floor.transform.position = new Vector3(0, createPosy, startPos+createPos);
            //角度を下方調整
            floor.transform.rotation = Quaternion.Euler(createRoteX, 0, 0);

            //ランダムでジャンプ台を生成
            int num = Random.Range(1, 100);
            if (num <= jumpRandom)
            {
                //x軸生成位置のランダム決定
                float jumperPosx = Random.Range(-1.5f, 1.5f);
                //生成
                GameObject jumper1 = Instantiate(Jumper1Prefab) as GameObject;
                //位置決定
                jumper1.transform.position = new Vector3(jumperPosx, createPosy, startPos + createPos);
 
                //transforemからrotationを参照し、角度をランダム決定
                float rotationX = Random.Range(-35f, -15f);
                jumper1.transform.rotation = Quaternion.Euler(rotationX, 0, 0);

                //その中でさらにランダムでスピードアップアイテムを生成
                int num2 = Random.Range(1,100);
                if (num2 <= speedRandom)
                {
                    GameObject SUI = Instantiate(speedUpItemPrefab) as GameObject;
                    //位置決定
                    SUI.transform.position = new Vector3(jumperPosx, createPosy+3f, startPos + createPos+10f);
                }

            }
            //createPosy -= 0.01f;
            startPos += 3;

        }


    }
}
