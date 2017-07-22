using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class ItemDisplayPresenter : MonoBehaviour {

	[SerializeField]
	GridLayoutGroup mGrid;
	List<ItemPresenter> mItemPresenterList = new List<ItemPresenter>();
	[SerializeField]
	IndicationItemPresenter mIndicationItemPrefab;
	List<IndicationItemPresenter> ItemList = new List<IndicationItemPresenter> ();

	/// <summary>
	/// プレイヤーの所持アイテムを増やす
	/// </summary>
	/// <param name="item">Item.</param>
	public void AddPlayerItem(AdvItemModel item){
		IndicationItemPresenter iteDisplay = PrefabFolder.InstantiateTo<IndicationItemPresenter> (mIndicationItemPrefab,mGrid.transform);
		iteDisplay.Init (item,RepostionItems);
		ItemList.Add (iteDisplay);
		UpDateItemDisplay ();
	}

	/// <summary>
	/// プレイヤーの所持アイテムを減らす
	/// </summary>
	/// <param name="item">Item.</param>
	public void RemovePlayerItem(AdvItemModel item){
		var targetItem = ItemList.Where (i => i.Item.ItemModel.mId == item.ItemModel.mId).FirstOrDefault ();
		ItemList.Remove (targetItem);
		Destroy (targetItem.gameObject);
		UpDateItemDisplay ();
		//Player.ItemList.Remove (item);
	}

	public void UpDateItemDisplay(){
		foreach (var item in ItemList) {
			//使用済みのアイテムは非表示にする
			if (item.Item.IsUsed) {
				item.gameObject.SetActive (false);
			}
		}
	}

	public void RepostionItems(){
		mGrid.enabled = false;
		mGrid.enabled = true;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
