using UnityEngine;
using System;

public class Customer : Character
{

    public Sprite right;
    public Sprite wrong;

    public string endRight;
    public string endWrong;


    public string rightAnswer()
    {
        GetComponent<SpriteRenderer>().sprite = right;
        return endRight;
    }

    public string wrongAnswer()
    {
        GetComponent<SpriteRenderer>().sprite = wrong;
        return endWrong;
    }

}
