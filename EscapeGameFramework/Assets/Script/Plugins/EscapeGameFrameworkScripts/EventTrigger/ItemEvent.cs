using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class ItemEvent : MonoBehaviour {
	

	[SerializeField]
	int mTargetItemID;

	public void IndicationItemDropedEvent(IndicationItemPresenter item){
		
		if (mTargetItemID == item.Item.ItemModel.mId) {
			BaseSceneController.Instance.ExcuteItemEvent (mTargetItemID);
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
