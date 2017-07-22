using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellPresenter : MonoBehaviour {
	[SerializeField]
	Image mImage;
	[SerializeField]
	Text mText;

	AdvCellModel model;
	int xNumber;
	/// <summary>
	/// 横番号（Y番号）
	/// </summary>
	/// <value>The m side line number.</value>
	public int y{
		get{
			return model.mYLineNumber;
		}
	}
	/// <summary>
	/// 縦番号(X番号)
	/// </summary>
	/// <value>The m vertical number.</value>
	public int x{
		get{
			return xNumber;
		}
	}
	public string mValue{
		get{
			return model.GetValueFromVerticalNumber (x);
		}
	}
	/// <summary>
	/// 侵入不可
	/// </summary>
	/// <value><c>true</c> if this instance is impossible invade; otherwise, <c>false</c>.</value>
	public bool IsImpossibleInvade{
		get{
			return mValue != "" && mValue != "_";
		}
	}

	/// <summary>
	/// 表示をセット
	/// </summary>
	void SetDisplay(){
		mText.text = x + ":" + y;
		if (mValue != "") {
			if (mValue != "_") {
				mImage.color = Color.gray;
			}
		}
	}

	public void Init(AdvCellModel model,int verticalNumber){
		this.model = model;
		this.xNumber = verticalNumber;
	}

	// Use this for initialization
	void Start () {
		//TODO 一旦は検証用表示
		SetDisplay ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
