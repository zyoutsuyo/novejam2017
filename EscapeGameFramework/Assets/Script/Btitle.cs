using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btitle : MonoBehaviour {

	public void GotoNext(){
		Application.LoadLevel ("C_StageSelect");
	}

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();
		Debug.Log ("Reset PlayerPrefs!!!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
