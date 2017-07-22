using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class UIDropObject : MonoBehaviour, IDropHandler {

	[SerializeField]
	Image tragetImage;
	[SerializeField]
	Action<AdvItemModel> mOnDropCallBack;

	public void OnDrop(PointerEventData pointerEventData)
	{
		//ドロップ時の挙動を実装する！！！！
		//IndicationItemPresenter DropedItem = pointerEventData.pointerDrag.GetComponent<IndicationItemPresenter>();
		Debug.Log ("OnDrop="+pointerEventData.pointerDrag.name);

		/*
		if (mOnDropCallBack != null)
			mOnDropCallBack (DropedItem.Item);
		*/


	}
}
