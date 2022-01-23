using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

    public GameObject panelWalls; //壁全体のパネル

    public GameObject buttonMessage;    //ボタン：メッセージ
    public GameObject buttonMessageText;//メッセージテキスト

    private int wallNo;

    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_FRONT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //右ボタンプッシュ
    public void PushButtonRight() {
//        Debug.Log("R");
        wallNo++;
        if (wallNo > WALL_LEFT) {
            wallNo = WALL_FRONT;
        }
        DisplayWall();
    }
    //左ボタンプッシュ
    public void PushButtonLeft() {
//        Debug.Log("L");
        wallNo--;
        if (wallNo < WALL_FRONT) {
            wallNo = WALL_LEFT;
        }
        DisplayWall();
    }
    //向いている方向の壁を表示
    void DisplayWall(){
//        Debug.Log(wallNo);
        switch (wallNo){
            case WALL_FRONT: //前
                panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case WALL_RIGHT: //右
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                break;
            case WALL_BACK: //後
                panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                break;
            case WALL_LEFT: //左
                panelWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                break;
        }
    }
    //メッセージを表示
    void DisplayMessage(string mes) {
        buttonMessage.SetActive(true);
        buttonMessageText.GetComponent<Text>().text = mes;
    }
    //メモをタップ
    public void PushButtonMemo() {
        DisplayMessage("エッフェル塔と書いてある");
    }
    public void PushBottonMessage() {
        buttonMessage.SetActive(false); //メッセージを消す
    }
}
