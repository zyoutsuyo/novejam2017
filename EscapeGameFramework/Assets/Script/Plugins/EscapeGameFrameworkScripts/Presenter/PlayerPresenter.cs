using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct IntVector2{
	public int x;
	public int y;
}

public class PlayerPresenter {

	List<AdvItemModel> mItemList = new List<AdvItemModel>();
	public List<AdvItemModel> ItemList{
		get{
			return mItemList;
		}
		set{
			mItemList = value;
		}
	}

	//座標
	IntVector2 mCoordinate;
	CellPresenter mUnderCell;
	public CellPresenter UnderCell{
		get{
			return mUnderCell;
		}
	}
	/// <summary>
	/// 下部のマスをセット
	/// </summary>
	/// <param name="underCell">Under cell.</param>
	public void SetUnderCell(CellPresenter underCell){
		mUnderCell = underCell;
	}
	public IntVector2 Coordinate{
		get{
			return mCoordinate;
		}
	}
	public void SetCoordinate(int x,int y){
		mCoordinate.x = x;
		mCoordinate.y = y;
	}
	PlayerDirection mCurrentDirection = PlayerDirection.UP;
	public PlayerDirection CurrentDirection{
		get{
			return mCurrentDirection;
		}
	}
	public void SetCurrentDirection(PlayerDirection currentDirection){
		mCurrentDirection = currentDirection;
	}
}
