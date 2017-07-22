using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice2_2_1 : GameScreenEventBase {

	[SerializeField]
	GameEvent mGetMedisun;
	const int MEDIA_ITEM_ID = 1;

	public override void ExcuteEvent ()
	{
		mGetMedisun.gameObject.SetActive (false);
		//TODO リファクタ
		GameManager.Instance.AddPlayerItem (MEDIA_ITEM_ID);
	}

	// Use this for initialization
	void Start () {
		//アイテムを保持している場合はアイテムを消す
		if (GameManager.Instance.IsPossessedTargetItem (MEDIA_ITEM_ID)) {
			mGetMedisun.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
