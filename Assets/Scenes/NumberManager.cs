using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberManager : MonoBehaviour
{
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] Button button5;
    [SerializeField] Button button6;
    Button[] buttons;
    [SerializeField] TextMeshProUGUI buttonText1;
    [SerializeField] TextMeshProUGUI buttonText2;
    [SerializeField] TextMeshProUGUI buttonText3;
    [SerializeField] TextMeshProUGUI buttonText4;
    [SerializeField] TextMeshProUGUI buttonText5;
    [SerializeField] TextMeshProUGUI buttonText6;
    TextMeshProUGUI[] buttonTexts;
    [SerializeField] TextMeshProUGUI bombText;
    [SerializeField] TextMeshProUGUI gameOverText;
    int[] numbers = {0, 0, 0, 0, 0, 0};
    int bombNumber = 1;
    int randomNumber = 0;
    int[,] relasionshipNumbers = {
        {0, 1, 1, 1,   1, 1},
        {1, 0, 1, 1,   1, 1},
        {1, 1, 0, 1,   1, 1},
        {1, 1, 1, 0,   1, 1},

        {1, 1, 1, 1,   0, 1},
        {1, 1, 1, 1,   1, 0},
    };
    int relasionshipBombsNumber = 0;

    // Start is called before the first frame update
    void Start() {
        buttons = new Button[] {button1, button2, button3, button4, button5, button6};
        buttonTexts = new TextMeshProUGUI[] {buttonText1, buttonText2, buttonText3, buttonText4, buttonText5, buttonText6};

        resetBomb();
    }

    // Update is called once per frame
    void Update() {
    }

    public void resetBomb() {
        for (int i = 0; i < numbers.Length; i++) {
            numbers[i] = 0;
            buttons[i].GetComponent<Image>().color = new Color32(100, 0, 200, 255);
            buttonTexts[i].text = "";
        }

        for (int i = 0; i < bombNumber; i++) {
            // output 0 ~ numbers.length - 1
            randomNumber = UnityEngine.Random.Range(0, numbers.Length);

            if (numbers[randomNumber] != 1) {
                numbers[randomNumber] = 1;
            } else {
                i--;
            }
        }

        bombText.text = "Bomb:" + bombNumber.ToString();
        gameOverText.text = "";
    }

    public void clickNumberButton(int buttonNumber) {
        relasionshipBombsNumber = 0;

        if (numbers[buttonNumber] == 0) {
            // not bomb
            buttons[buttonNumber].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            for (int i = 0; i < numbers.Length; i++) {
                if (relasionshipNumbers[buttonNumber, i] == 1 && numbers[i] == 1) {
                    relasionshipBombsNumber++;
                }
            }

            buttonTexts[buttonNumber].text = relasionshipBombsNumber.ToString();
        } else {
            // bomb
            buttons[buttonNumber].GetComponent<Image>().color = new Color32(255, 0, 0, 255);

            gameOverText.text = "Game Over";
        }
    }
}
