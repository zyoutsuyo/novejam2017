using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public enum ItemType{
	NONE,
}
[Serializable]
public class ItemModel {
	public int mId=0;
	public string mName="";
	public string mGraphicPath="";
	public int mItemType= 0;
	//public ItemType mItemType= ItemType.NONE;
}

public class AdvItemModel{
	ItemModel mItemModel;
	public ItemModel ItemModel{
		get{
			return mItemModel;
		}
	}
	public AdvItemModel(ItemModel model){
		mItemModel = model;
	}
	public AdvItemModel(int itemId){
		mItemModel = GameManager.Instance.MasterItemData.Where (item => item.mId == itemId).FirstOrDefault ();
	}
	bool mIsUsed = false;
	public bool IsUsed{
		get{
			return mIsUsed;
		}
	}
	/// <summary>
	/// アイテム使用
	/// </summary>
	public void UseItem(){
		//後々。Switch分岐を入れる
		mIsUsed = true;
		GameManager.Instance.UpDatePlayerItemListSaveData ();
	}

	/// <summary>
	/// 使用済みか否かのフラグを立てる
	/// </summary>
	/// <param name="flag">If set to <c>true</c> flag.</param>
	public void SetUsedFlag(bool flag){
		mIsUsed = flag;
	}

}

