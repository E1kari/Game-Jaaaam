using UnityEngine;

public class Character : MonoBehaviour
{

    public Emotions emotion;


    public string dialougeInfo1;
    public string dialougeInfo2;
    public string dialougeInfo3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum Emotions
    {
        happy,
        sad,
        angry,
        surprise,
        disgust,
        fear
    }

    
}
