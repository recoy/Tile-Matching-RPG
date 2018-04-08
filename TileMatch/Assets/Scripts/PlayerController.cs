using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private int movesLeft;
    public int maxMoves = 3;
    public Text movesText, blueProb, redProb, greenProb, failed;
    public int green = 0, blue = 0, red = 0;
    public int[] blueProbs = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] greenProbs = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] redProbs = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private PlayerAttributes playerAttributes;
    public DestroyOnClick doc;

    // Use this for initialization
    void Start () {
        playerAttributes = GetComponent<PlayerAttributes>();
        movesLeft = maxMoves;
        //movesText.text = movesLeft.ToString();
        RefreshProbTexts("blue");
        RefreshProbTexts("green");
        RefreshProbTexts("red");
        failed.enabled = false;
    }

    public void RefreshProbTexts(string color)
    {
        if (color == "blue")
        {
            if (blue >= 10)
                blueProb.text = "100%";
            else
                blueProb.text = blue * 10 + "%";
        }
        else if (color == "green")
        {
            if (green >= 10)
                greenProb.text = "100%";
            else
                greenProb.text = green * 10 + "%";
        }
        else
        {
            if (red >= 10)
                redProb.text = "100%";
            else
                redProb.text = red * 10 + "%";
        }
    }

    public void DecreaseMoves()
    {
        movesLeft--;
        movesText.text = movesLeft.ToString();
    }

    public void UseAttack()
    {
        System.Random random = new System.Random();
        int value = redProbs[random.Next(0, redProbs.Length)];
        if (value == 1)
            doc.DamageAnotherPlayer(playerAttributes.attack);
        else
            StartCoroutine(ShowFailedText());
        red = 0;
        RefreshProbTexts("red");
        for(int i = 0; i < redProbs.Length; ++i)
        {
            redProbs[i] = 0;
        }
        Debug.Log(value);
    }

    IEnumerator ShowFailedText()
    {
        failed.enabled = true;
        yield return new WaitForSeconds(1);
        failed.enabled = false;
    }

    public void UseHeal()
    {
        System.Random random = new System.Random();
        int value = blueProbs[random.Next(0, blueProbs.Length)];
        if (value == 1)
        {
            playerAttributes.currentHealth += playerAttributes.heal;
            playerAttributes.RefreshAttributeTexts();
        }
        else
            StartCoroutine(ShowFailedText());
        blue = 0;
        RefreshProbTexts("blue");
        for (int i = 0; i < blueProbs.Length; ++i)
        {
            blueProbs[i] = 0;
        }
        Debug.Log(value);
    }
    public void UseSpecial()
    {
        System.Random random = new System.Random();
        int value = greenProbs[random.Next(0, greenProbs.Length)];
        green = 0;
        RefreshProbTexts("green");
        for (int i = 0; i < greenProbs.Length; ++i)
        {
            greenProbs[i] = 0;
        }
        Debug.Log(value);
    }


    public void TurnEnd()
    {
        movesLeft = maxMoves;
        movesText.text = movesLeft.ToString();
    }
    public void AddProbsToArray(string color)
    {
        if (color == "blue")
        {
            for(int i = 0; i < blueProbs.Length; ++i)
            {
                if(blueProbs[i] == 0)
                {
                    blueProbs[i] = 1;
                    return;
                }
            }
        }
        else if (color == "green")
        {
            for (int i = 0; i < greenProbs.Length; ++i)
            {
                if (greenProbs[i] == 0)
                {
                    greenProbs[i] = 1;
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < redProbs.Length; ++i)
            {
                if (redProbs[i] == 0)
                {
                    redProbs[i] = 1;
                    return;
                }
            }
        }
    }
}
