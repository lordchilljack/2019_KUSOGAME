using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCtrl : MonoBehaviour {


	public void LeaveGame(){
		Application.Quit ();
	}


	public void StartGame(){
		SceneManager.LoadScene(1);
	}

	// Use this for initialization
	void Start () {
		
	}
	public void OpenFacebook(){
		Application.OpenURL("https://www.facebook.com/TryHarderOkay");
	}
	// Update is called once per frame
	void Update () {
		
	}
}
