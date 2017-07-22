using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameEvent : MonoBehaviour {

	[SerializeField]
	int mEvnetID;

	public void OnClickEvent(){
		BaseSceneController.Instance.ExcuteGameEvent (mEvnetID);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
