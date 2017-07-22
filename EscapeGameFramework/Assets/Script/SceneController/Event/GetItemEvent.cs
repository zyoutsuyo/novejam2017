using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemEvent : MonoBehaviour {

	[SerializeField]
	GameObject mItemGameObject;
	const int ITEM_ID = 1;

	public void GetItem(){
		mItemGameObject.SetActive (false);
		GameManager.Instance.AddPlayerItem (ITEM_ID);
	}

	// Use this for initialization
	void Start () {
		if (GameManager.Instance.IsPossessedTargetItem (ITEM_ID)) {
			mItemGameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
