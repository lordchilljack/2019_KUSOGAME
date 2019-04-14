using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {
    public byte ButtonTrans = 0;
    public Button Button1;
    public Text ButtonText;
    public Text Explain;
    
    public void StartGame()
    {
        if (ButtonTrans > 125)
        {
            SceneManager.LoadScene(2);
        }
    }

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (ButtonTrans < 255)
        {
            ButtonTrans++;
        }
        Button1.GetComponent<Image>().color = new Color32(255, 255, 255, ButtonTrans);
        Explain.color = new Color32(255, 255, 255, ButtonTrans);
        ButtonText.color = new Color32(0, 0, 0, ButtonTrans);
    }
}
