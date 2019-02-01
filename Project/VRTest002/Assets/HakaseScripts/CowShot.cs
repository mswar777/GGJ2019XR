using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject),typeof(Rigidbody),typeof(BoxCollider))]
public class CowShot : MonoBehaviour
{
    public float offsetRate = 10.0f;
    public GameObject beko = null;
    //ベコをくっつけるオブジェクト
    private GameObject attachPoint = null;
    //ベコを打ち出す力
    public float ShotPower = 0.001f;
    //つかんで打ち出すのに使用するviveコントローラーのボタンを設定する
    public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    //つかむもののタグ
    public string catchTag = "beko";
    //steamvrの処理を行うクラス
    private SteamVR_Behaviour_Pose trackedObj = null;
    //打ち出すか
    private bool isShot = false;
    //打ち出すベコのリスト
    private List<GameObject> shotBekoList;
    //つながっているjointのリスト
    private List<FixedJoint> jointList;
    //つかむか
    private bool isCatch = false;
    //ベコをくっつけるオブジェクトのrigidbody
    private Rigidbody attachRb= null;

    //各種初期化
    private void Awake()
    {
        if (attachPoint == null) attachPoint = gameObject;
        //attachRb = attachPoint.GetComponent<Rigidbody>();
        shotBekoList = new List<GameObject>();
        jointList = new List<FixedJoint>();
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
        isShot = false;
        isCatch = false;
    }

    private void Update()
    {
        //つかむボタンを押していれば
        if (spawn.GetState(trackedObj.inputSource))
        {
            isCatch = true;
            isShot = false;
        }
        //押していなければ
        else
        {
            isCatch = false;
            isShot = false;
        }
        //離したフレームなら
        if (spawn.GetStateUp(trackedObj.inputSource))
        {
            isCatch = false;
            isShot = true;
        }
    }

    private void FixedUpdate()
    {
        if (isShot)
        {
            //rigidbodyのvelocityを使う処理のためFixedUpdateに記述
            Shot();
            isShot = false;
        }
    }

    private void Shot()
    {
        var pos = attachPoint.transform.position;
        pos += -attachPoint.transform.forward * offsetRate;
        var shotBeko = Instantiate(beko,pos,Quaternion.identity);
        //shotBeko.GetComponent<Beko>().release_flg = true;
        var bekoRb = shotBeko.GetComponent<Rigidbody>();
        bekoRb.AddForce(attachPoint.transform.forward * ShotPower);
        //bekoRb.velocity = -attachPoint.transform.forward * ShotPower;
        //bekoRb.angularVelocity = -attachPoint.transform.forward * ShotPower;
        ////全てのジョイントを外す
        //foreach (var joint in jointList)
        //{
        //    DestroyImmediate(joint);
        //}
        ////つかんでいる全てのベコを打ち出す
        //foreach(var cow in shotBekoList)
        //{
        //    var cowRb = cow.GetComponent<Rigidbody>();
        //    cowRb.velocity = gameObject.transform.forward * ShotPower;
        //    cowRb.angularVelocity = gameObject.transform.forward * ShotPower;
        //    cow.GetComponent<Beko>().release_flg = true;
        //}
        ////各リストをクリアする
        //shotBekoList.Clear();
        //jointList.Clear();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (!isCatch) return;
        //if (collision.gameObject.CompareTag(catchTag))
        //{
        //    //ベコのリリースフラグを立てて動かないようにする
        //    collision.gameObject.GetComponent<Beko>().release_flg = true;
        //    //ジョイントで繋ぐ
        //    var joint = collision.gameObject.AddComponent<FixedJoint>();
        //    joint.connectedBody = attachRb;
        //    //各リストに追加
        //    shotBekoList.Add(collision.gameObject);
        //    jointList.Add(joint);
        //}
    }

    private void OnTriggerStay(Collision collision)
    {
        /*
        if (!isCatch)
            return;
        if (collision.gameObject.CompareTag(catchTag) == false)
            return;
        if (shotBekoList.Contains(collision.gameObject))
            return;

        {
            //ベコのリリースフラグを立てて動かないようにする
            collision.gameObject.GetComponent<Beko>().release_flg = true;
            //ジョイントで繋ぐ
            var joint = collision.gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = attachRb;
            //各リストに追加
            shotBekoList.Add(collision.gameObject);
            jointList.Add(joint);
        }
        */
    }
}
