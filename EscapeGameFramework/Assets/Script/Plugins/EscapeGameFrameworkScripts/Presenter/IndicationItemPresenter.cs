using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class IndicationItemPresenter : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	AdvItemModel mItem;
	public AdvItemModel Item{
		get{
			return mItem;
		}
	}
	[SerializeField]
	Image mImage;
	Action mEndDragCallback;
	public void Init(AdvItemModel item,Action endDragCallback){
		this.mItem = item;
		var prefab = (GameObject)Resources.Load ("Item/"+item.ItemModel.mGraphicPath);
		mImage = PrefabFolder.InstantiateTo<Image> (prefab,this.transform);
		var rect = this.GetComponent<RectTransform> ();
		mImage.rectTransform.sizeDelta = rect.sizeDelta;
		mEndDragCallback = endDragCallback;
	}

	public void OnBeginDrag(PointerEventData pointerEventData)
	{
		this.transform.position = pointerEventData.position;
	}

	public void OnDrag(PointerEventData pointerEventData)
	{
		//draggingObject.transform.position = pointerEventData.position;
		this.transform.position = pointerEventData.position;
	}

	public void OnEndDrag(PointerEventData pointerEventData)
	{
		//gameObject.GetComponent<Image>().color = Vector4.one;
		//Destroy(draggingObject);
		mEndDragCallback();
		//Debug.Log (pointerEventData.pointerDrag.name);
		// レイキャスト結果のリストを作成
		List<RaycastResult> list = new List<RaycastResult>();
		// レイを飛ばしてヒットするオブジェクトを取得
		EventSystem.current.RaycastAll(pointerEventData, list);
		// オブジェクトがヒットしたか
		foreach (var item in list) {
			//ItemEventが入ったオブジェクトだけ取得
			if (item.gameObject.HasComponent<ItemEvent> ()) {
				var itemEvent = item.gameObject.GetComponent<ItemEvent> ();
				itemEvent.IndicationItemDropedEvent (this);
			}

		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

/// <summary>
/// GameObject 型の拡張メソッドを管理するクラス
/// </summary>
public static class GameObjectExtensions
{
	/// <summary>
	/// 指定されたコンポーネントがアタッチされているかどうかを返します
	/// </summary>
	public static bool HasComponent<T>(this GameObject self) where T : Component
	{
		return self.GetComponent<T>() != null;
	}
}
