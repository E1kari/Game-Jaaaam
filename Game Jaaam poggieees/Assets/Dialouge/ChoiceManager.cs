using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ChoiceManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void loadMaskScene()
    {
        SceneManager.LoadScene("Masks", LoadSceneMode.Additive); // Load menu without unloading game
    }
}
