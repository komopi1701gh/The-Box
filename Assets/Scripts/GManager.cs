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

    public GameObject panelWalls; //�ǑS�̂̃p�l��

    public GameObject buttonMessage;    //�{�^���F���b�Z�[�W
    public GameObject buttonMessageText;//���b�Z�[�W�e�L�X�g

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
    //�E�{�^���v�b�V��
    public void PushButtonRight() {
//        Debug.Log("R");
        wallNo++;
        if (wallNo > WALL_LEFT) {
            wallNo = WALL_FRONT;
        }
        DisplayWall();
    }
    //���{�^���v�b�V��
    public void PushButtonLeft() {
//        Debug.Log("L");
        wallNo--;
        if (wallNo < WALL_FRONT) {
            wallNo = WALL_LEFT;
        }
        DisplayWall();
    }
    //�����Ă�������̕ǂ�\��
    void DisplayWall(){
//        Debug.Log(wallNo);
        switch (wallNo){
            case WALL_FRONT: //�O
                panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case WALL_RIGHT: //�E
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                break;
            case WALL_BACK: //��
                panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                break;
            case WALL_LEFT: //��
                panelWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                break;
        }
    }
    //���b�Z�[�W��\��
    void DisplayMessage(string mes) {
        buttonMessage.SetActive(true);
        buttonMessageText.GetComponent<Text>().text = mes;
    }
    //�������^�b�v
    public void PushButtonMemo() {
        DisplayMessage("�G�b�t�F�����Ə����Ă���");
    }
    public void PushBottonMessage() {
        buttonMessage.SetActive(false); //���b�Z�[�W������
    }
}
