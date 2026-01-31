using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private List<GameObject> dialogue = new();

    public GameObject contentPanel;
    public GameObject bubblePrefab;

    public Sprite speechBubbleRight;
    public Sprite speechBubbleLeft;

    public struct Bubble
    {
        public string text;
        public Sprite sprite;
    }

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Bubble bubble;
            if (i % 2 == 0)
            {
                bubble = new Bubble { text = "Hello " + (i + 1), sprite = speechBubbleLeft };
            }
            else
            {
                bubble = new Bubble { text = "Hello " + (i + 1), sprite = speechBubbleRight };
            }

            addDialogue(bubble);
        }
    }

    public void addDialogue(Bubble bubble)
    {
        GameObject bubbleHolder = Instantiate(bubblePrefab);
        bubbleHolder.GetComponent<Image>().sprite = bubble.sprite;
        bubbleHolder.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = bubble.text;

        bubbleHolder.transform.SetParent(contentPanel.transform);

        dialogue.Add(bubbleHolder);
        int index = dialogue.Count - 1;

        dialogue[index].GetComponent<RectTransform>().position = new Vector2(0, 0);
        determineYPosition(index);
        determineXPosition(index);


        var panelTransform = contentPanel.GetComponent<RectTransform>();
        panelTransform.sizeDelta = new Vector2(panelTransform.sizeDelta.x, panelTransform.sizeDelta.y + dialogue[index].GetComponent<RectTransform>().sizeDelta.y);
    }

    public void determineYPosition(int index)
    {
        var thisRect = dialogue[index].GetComponent<RectTransform>();
        Vector2 pos = thisRect.anchoredPosition;

        if (index == 0)
        {
            pos = new Vector2(pos.x, 0);
        }
        else
        {
            var lastRect = dialogue[index - 1].GetComponent<RectTransform>();
            pos = new Vector2(pos.x, lastRect.anchoredPosition.y - (lastRect.sizeDelta.y / 2));
        }

        pos = new Vector2(pos.x, pos.y - (thisRect.sizeDelta.y / 2));
        thisRect.anchoredPosition = pos;
    }

    public void determineXPosition(int index)
    {
        GameObject bubbleHolder = dialogue[index];
        Sprite sprite = bubbleHolder.GetComponent<Image>().sprite;

        var thisRect = dialogue[index].GetComponent<RectTransform>();
        Vector2 pos = thisRect.anchoredPosition;

        if (sprite == speechBubbleRight)
        {
            bubbleHolder.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
            bubbleHolder.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
            pos = new Vector2(thisRect.sizeDelta.x / 2, pos.y);
        }
        else
        {
            bubbleHolder.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
            bubbleHolder.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            pos = new Vector2(-(thisRect.sizeDelta.x) / 2, pos.y);
        }

        thisRect.anchoredPosition = pos;
    }
}
