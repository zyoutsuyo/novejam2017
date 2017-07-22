using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class AdvCellModel {
	//侵入可能か否か
	bool mPossibleToInvade;
	//左へ進行可能か？
	bool mPossibleToDoLeft;
	//右へ進行可能か？
	bool mPossibleToDoRight;
	//上へ進行可能か？
	bool mPossibleToDoUp;
	//下へ進行可能か？
	bool mPossibleToDoDown;

	int sideLine;
	public int mYLineNumber{
		get{
			return sideLine;
		}
	}
	public void SetSideLineNumber(int num){
		sideLine = num;
	}

	public string GetValueFromVerticalNumber(int num){
		PropertyInfo[] infoArray = mModel.GetType().GetProperties();
		foreach (var i in infoArray) {
			if (i.Name == GameDef.MAP_PROPERTIE_PREFIX + num) {
				return (string)i.GetValue (mModel, null);
			}
		}
		Debug.LogError ("NotFound");
		return "";
	}

	MapCellModel model;
	public MapCellModel mModel{
		get{
			return model;
		}
	}

	//座標
	Vector2 mCoordinate;
	public AdvCellModel(MapCellModel model){
		this.model = model;
	}
}
