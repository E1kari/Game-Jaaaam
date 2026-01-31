using UnityEngine;

public class Bubble : MonoBehaviour
{
        public bool saidByCustomer;
        public string text;
        private Sprite speechBubble;
    
    public void initialize(string text, bool saidByCustomer)
    {
        this.text = text;
        this.saidByCustomer = saidByCustomer;

        if (saidByCustomer)
        {
            speechBubble = Resources.Load<Sprite>("speechBubbleLeft");
        }
        else
        {
            speechBubble = Resources.Load<Sprite>("speechBubbleRight");
        }
        
        GetComponent<SpriteRenderer>().sprite = speechBubble;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
