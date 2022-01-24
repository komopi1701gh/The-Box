using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    //定数　壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK  = 3;
    public const int WALL_LEFT  = 4;
    //定数　ボタンカラー
    public const int COLOR_GREEN = 0;
    public const int COLOR_RED   = 1;
    public const int COLOR_BLUE  = 2;
    public const int COLOR_WHITE = 3;

    public GameObject panelWalls; //壁全体のパネル
    public GameObject buttonHammer; //ボタン：トンカチ
    public GameObject buttonKey;    //ボタン：鍵

    public GameObject imageHammerIcon; //アイコン：トンカチ
    public GameObject imageKeyIcon;    //アイコン：鍵

    public GameObject buttonPig;    //ボタン：貯金箱

    public GameObject buttonMessage;    //ボタン：メッセージ
    public GameObject buttonMessageText;//メッセージテキスト

    public GameObject[] buttonLamp = new GameObject[3];//ボタン：金庫
    public Sprite[] buttonPicture = new Sprite[4];     //ボタンの絵
    public Sprite hammerPcture;                        //トンカチの絵
    public Sprite keyPicture;                          //鍵の絵

    private int wallNo; //壁向き
    private bool doesHaveHammer; //トンカチ取ったか？
    private bool doesHaveKey;    //鍵取ったか？
    private int[] buttonColor = new int[3]; //金庫のボタン色

    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_FRONT;
        doesHaveHammer = false; //トンカチ持ってない
        doesHaveKey = false;    //鍵持ってない

        buttonColor[0] = COLOR_GREEN;//ボタン色1は緑
        buttonColor[1] = COLOR_RED;//ボタン色2は赤
        buttonColor[2] = COLOR_BLUE;//ボタン色3は青
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
        DisplayWall();  //壁表示
        ClearButtons(); //色々消す
    }
    //左ボタンプッシュ
    public void PushButtonLeft() {
//        Debug.Log("L");
        wallNo--;
        if (wallNo < WALL_FRONT) {
            wallNo = WALL_LEFT;
        }
        DisplayWall();
        ClearButtons();
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
    //金庫ボタン123タップ
    public void PushButtonLamp1() {
        ChangeButtonColor(0);
    }
    public void PushButtonLamp2() {
        ChangeButtonColor(1);
    }
    public void PushButtonLamp3() {
        ChangeButtonColor(2);
    }
    //金庫ボタン色変更
    void ChangeButtonColor(int buttonNo) {
        buttonColor[buttonNo]++;
        if(buttonColor[buttonNo] > COLOR_WHITE) {
            buttonColor[buttonNo] = COLOR_GREEN;
        }
        //ボタン色変更セット
        buttonLamp[buttonNo].GetComponent<Image>().sprite =
            buttonPicture[buttonColor[buttonNo]];

        //さて，ボタン色合ってるかな？？？
        if((buttonColor[0] ==  COLOR_BLUE)  &&
            (buttonColor[1] == COLOR_WHITE) &&
            (buttonColor[2] == COLOR_RED)) {
            if (doesHaveHammer == false) {//トンカチ持ってないか？
                DisplayMessage("金庫の中にトンカチが入っていた。");
                buttonHammer.SetActive(true);
                imageHammerIcon.GetComponent<Image>().sprite = hammerPcture;

                doesHaveHammer = true; //取った！！！
            }
        }
    }
    public void PushButtonHammer() {
        buttonHammer.SetActive(false);
    }
    //貯金箱タップ
    public void PushButtonPig() {
        if (doesHaveHammer == false) {//トンカチ持ってる？
            DisplayMessage("素手では割れない。");
        }
        else {　　　　　　　　　　　　//トンカチ持ってれば
            DisplayMessage("貯金箱が割れて中から鍵が出てきた。");
            buttonPig.SetActive(false);
            buttonKey.SetActive(true);
            imageKeyIcon.GetComponent<Image>().sprite = keyPicture;

            doesHaveKey = true;
        }
    }
    //鍵の絵タップ　消す
    public void PushButtonKey() {
        buttonKey.SetActive(false);
    }

    //ボックスをタップ
    public void PushButtonBox() {
        if (doesHaveKey == false) {
            DisplayMessage("鍵がかかっている。");
        }
        else {
            SceneManager.LoadScene("ClearScene");
        }
    }

    //各種表示をクリア
    void ClearButtons() {
        buttonHammer.SetActive(false);
        buttonKey.SetActive(false);
        buttonMessage.SetActive(false);
    }
}
