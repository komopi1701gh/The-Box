using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    //�萔�@�Ǖ���
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK  = 3;
    public const int WALL_LEFT  = 4;
    //�萔�@�{�^���J���[
    public const int COLOR_GREEN = 0;
    public const int COLOR_RED   = 1;
    public const int COLOR_BLUE  = 2;
    public const int COLOR_WHITE = 3;

    public GameObject panelWalls; //�ǑS�̂̃p�l��
    public GameObject buttonHammer; //�{�^���F�g���J�`
    public GameObject buttonKey;    //�{�^���F��

    public GameObject imageHammerIcon; //�A�C�R���F�g���J�`
    public GameObject imageKeyIcon;    //�A�C�R���F��

    public GameObject buttonPig;    //�{�^���F������

    public GameObject buttonMessage;    //�{�^���F���b�Z�[�W
    public GameObject buttonMessageText;//���b�Z�[�W�e�L�X�g

    public GameObject[] buttonLamp = new GameObject[3];//�{�^���F����
    public Sprite[] buttonPicture = new Sprite[4];     //�{�^���̊G
    public Sprite hammerPcture;                        //�g���J�`�̊G
    public Sprite keyPicture;                          //���̊G

    private int wallNo; //�ǌ���
    private bool doesHaveHammer; //�g���J�`��������H
    private bool doesHaveKey;    //����������H
    private int[] buttonColor = new int[3]; //���ɂ̃{�^���F

    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_FRONT;
        doesHaveHammer = false; //�g���J�`�����ĂȂ�
        doesHaveKey = false;    //�������ĂȂ�

        buttonColor[0] = COLOR_GREEN;//�{�^���F1�͗�
        buttonColor[1] = COLOR_RED;//�{�^���F2�͐�
        buttonColor[2] = COLOR_BLUE;//�{�^���F3�͐�
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
        DisplayWall();  //�Ǖ\��
        ClearButtons(); //�F�X����
    }
    //���{�^���v�b�V��
    public void PushButtonLeft() {
//        Debug.Log("L");
        wallNo--;
        if (wallNo < WALL_FRONT) {
            wallNo = WALL_LEFT;
        }
        DisplayWall();
        ClearButtons();
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
    //���Ƀ{�^��123�^�b�v
    public void PushButtonLamp1() {
        ChangeButtonColor(0);
    }
    public void PushButtonLamp2() {
        ChangeButtonColor(1);
    }
    public void PushButtonLamp3() {
        ChangeButtonColor(2);
    }
    //���Ƀ{�^���F�ύX
    void ChangeButtonColor(int buttonNo) {
        buttonColor[buttonNo]++;
        if(buttonColor[buttonNo] > COLOR_WHITE) {
            buttonColor[buttonNo] = COLOR_GREEN;
        }
        //�{�^���F�ύX�Z�b�g
        buttonLamp[buttonNo].GetComponent<Image>().sprite =
            buttonPicture[buttonColor[buttonNo]];

        //���āC�{�^���F�����Ă邩�ȁH�H�H
        if((buttonColor[0] ==  COLOR_BLUE)  &&
            (buttonColor[1] == COLOR_WHITE) &&
            (buttonColor[2] == COLOR_RED)) {
            if (doesHaveHammer == false) {//�g���J�`�����ĂȂ����H
                DisplayMessage("���ɂ̒��Ƀg���J�`�������Ă����B");
                buttonHammer.SetActive(true);
                imageHammerIcon.GetComponent<Image>().sprite = hammerPcture;

                doesHaveHammer = true; //������I�I�I
            }
        }
    }
    public void PushButtonHammer() {
        buttonHammer.SetActive(false);
    }
    //�������^�b�v
    public void PushButtonPig() {
        if (doesHaveHammer == false) {//�g���J�`�����Ă�H
            DisplayMessage("�f��ł͊���Ȃ��B");
        }
        else {�@�@�@�@�@�@�@�@�@�@�@�@//�g���J�`�����Ă��
            DisplayMessage("������������Ē����献���o�Ă����B");
            buttonPig.SetActive(false);
            buttonKey.SetActive(true);
            imageKeyIcon.GetComponent<Image>().sprite = keyPicture;

            doesHaveKey = true;
        }
    }
    //���̊G�^�b�v�@����
    public void PushButtonKey() {
        buttonKey.SetActive(false);
    }

    //�{�b�N�X���^�b�v
    public void PushButtonBox() {
        if (doesHaveKey == false) {
            DisplayMessage("�����������Ă���B");
        }
        else {
            SceneManager.LoadScene("ClearScene");
        }
    }

    //�e��\�����N���A
    void ClearButtons() {
        buttonHammer.SetActive(false);
        buttonKey.SetActive(false);
        buttonMessage.SetActive(false);
    }
}
