using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleCtrl : MonoBehaviour {
    public byte ButtonTrans = 0;
    public Button Button1;
    public Button Button2;

    public void LeaveGame(){
        if(ButtonTrans > 125)
        {
            Application.Quit();
        }
		
	}


	public void StartGame(){
        if (ButtonTrans > 125)
        {
            SceneManager.LoadScene(1);
        }
	}

	// Use this for initialization
	void Start () {
		
	}
	public void OpenFacebook(){
		Application.OpenURL("https://www.facebook.com/TryHarderOkay");
	}
	// Update is called once per frame
	void Update () {
        if (ButtonTrans < 255)
        {
            ButtonTrans++;
        }
        Button1.GetComponent<Image>().color = new Color32(255, 255, 255, ButtonTrans);
        Button2.GetComponent<Image>().color = new Color32(255, 255, 255, ButtonTrans);
    }
}
