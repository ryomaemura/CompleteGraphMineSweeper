using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText1;
    [SerializeField] TextMeshProUGUI buttonText2;
    [SerializeField] TextMeshProUGUI buttonText3;
    [SerializeField] TextMeshProUGUI buttonText4;
    [SerializeField] TextMeshProUGUI buttonText5;
    [SerializeField] TextMeshProUGUI buttonText6;
    [SerializeField] TextMeshProUGUI buttonText7;
    [SerializeField] TextMeshProUGUI buttonText8;
    [SerializeField] TextMeshProUGUI buttonText9;
    [SerializeField] TextMeshProUGUI buttonText10;
    [SerializeField] TextMeshProUGUI buttonText11;
    [SerializeField] TextMeshProUGUI buttonText12;
    [SerializeField] TextMeshProUGUI buttonText13;
    [SerializeField] TextMeshProUGUI buttonText14;
    [SerializeField] TextMeshProUGUI buttonText15;
    [SerializeField] TextMeshProUGUI scoreLabel;
    TextMeshProUGUI[] buttonTexts;
    int[] numbers = {1, 2, 3, 4, 5, 0};
    int[] answerNumbers = {1, 2, 3, 4, 5, 0};
    int[, ] relasionshipNumbers = {
    //   1  2  3  4  5    6  7  8  9  10 11 12 13 14 15
        {0, 1, 1, 1, 1,   1},
        {1, 0, 1, 1, 1,   1},
        {1, 1, 0, 1, 1,   1},
        {1, 1, 1, 0, 1,   1},
        {1, 1, 1, 1, 0,   1},

        {1, 1, 1, 1, 1,   0},
    };
    int temp = 0;
    int randomNumber1 = 0;
    int randomNumber2 = 0;
    int scoreNumber = 0;
    int emptyNumber = 5;

    // Start is called before the first frame update
    void Start() {
        buttonTexts = new TextMeshProUGUI[] {buttonText1, buttonText2, buttonText3, buttonText4, buttonText5, buttonText6, buttonText7, buttonText8, buttonText9, buttonText10, buttonText11, buttonText12, buttonText13, buttonText14, buttonText15};

        shuffleNumbers();
        setNumbers();
        scoreReload();
    }

    // Update is called once per frame
    void Update() {
    }

    public void clickButton(int number) {
        for (int i = 0; i < numbers.Length; i++) {
            if (relasionshipNumbers[number - 1, i] == 1 && numbers[i] == 0) {
                temp = numbers[number - 1];
                numbers[number - 1] = numbers[i];
                numbers[i] = temp;

                buttonTexts[number - 1].text = "";
                buttonTexts[i].text = numbers[i].ToString();

                scoreNumber = scoreNumber + 1;
                scoreReload();
            }
        }

        setEmptyNumber();
    }

    public void setNumbers() {
        for (int i = 0; i < numbers.Length; i++) {
            if (numbers[i] != 0) {
                buttonTexts[i].text = numbers[i].ToString();
            } else {
                buttonTexts[i].text = "";
            }
        }
    }

    public void shuffleNumbers() {
        for (int i = 0; i < 30; i++) {
            randomNumber1 = UnityEngine.Random.Range(0, numbers.Length);
            randomNumber2 = UnityEngine.Random.Range(0, numbers.Length);

            temp = numbers[randomNumber1];
            numbers[randomNumber1] = numbers[randomNumber2];
            numbers[randomNumber2] = temp;
        }

        scoreNumber = 0;
        setEmptyNumber();
        scoreReload();
    }

    public void scoreReload() {
        scoreLabel.text = "Move:" + scoreNumber.ToString();
    }

    public void setEmptyNumber() {
        for (int i = 0; i < numbers.Length; i++) {
            if (numbers[i] == 0) {
                emptyNumber = i;
            }
        }
    }
}
