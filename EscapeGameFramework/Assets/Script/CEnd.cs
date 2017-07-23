using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SoundManager.Instance.PlayBgm (0);
		Invoke ("GoToTitle",14.0f);
	}

	void GoToTitle(){
		Application.LoadLevel ("B_title");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
