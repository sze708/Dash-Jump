using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;

    //Playerを移動させるコンポーネント
    private Rigidbody myRigidbody;

    //前進する力
    public float forwardForce;
    public float speedUpForce;
    //左右に移動するための力
    public float turnForce;
    //ジャンプするための力
    public float upForce;
    //左ボタン押下の判定
    private bool isLButtonDown = false;
    //右ボタン押下の判定
    private bool isRButtonDown = false;

    //SpeedUpした時の時間
    private float SpeedUpTime;

    // Use this for initialization
    void Start()
    {

        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 1);

        //Rigidbodyコンポーネントをstart内で取得
        this.myRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //speedup中か否か
        if (SpeedUpTime > 0.0f)
        {
            SpeedUpTime -= Time.deltaTime;
        }
        else if(SpeedUpTime==0.0f)
        {
            forwardForce -= speedUpForce;
        }

        //playerに前方方向の力を加える
        // Rigidbodyクラスの「AddForce」関数は、引数で指定した方向の力をRigidbodyにかけ る関数
        //AddForce(「力をかける方向」＊「力の値」)
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);

        //playerを矢印キーまたはボタンに応じて左右に移動させる
        if ((Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown))
        {
            //左に移動
            this.myRigidbody.AddForce(-this.turnForce, 0, 0);
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown))
        {
            //右に移
            this.myRigidbody.AddForce(this.turnForce, 0, 0);

        }

        //Jumpステートの場合はJumpにfalseをセットする
        //GCASでanimatorの状態を取得（jump),その時の名前がJumpかどうかをisnameで調べている。
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        //ジャンプしていない時にスペースが押されたらジャンプする
        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
        {
            //ジャンプアニメを再生
            this.myAnimator.SetBool("Jump", true);
            //player上方向の力を加える
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }

    //ジャンプボタンを押した場合の処理
    public void GetMyJumpButtonDown()
    {
        if (this.transform.position.y < 0.5f)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }

    //左ボタンを押し続けた場合の処理
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    //左ボタンを離した場合の処理
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    //右ボタンを押し続けた場合の処理
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    //右ボタンを離した場合の処理
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }

    //Itemと接触したときの処理
    private void OnTriggerEnter(Collider other)
    {
        //SpeedUpItemに衝突した場合
        if (other.gameObject.tag == "SpeedUpItem")
        {
            forwardForce += speedUpForce;
            SpeedUpTime += 3.0f;
            Destroy(other.gameObject);
        }
    }       
    }

