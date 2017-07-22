using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIParentPresenter : MonoBehaviour {

	[SerializeField]
	MapPresenter mMapPresenter;
	public MapPresenter MapPresenter{
		get{
			return mMapPresenter;
		}
	}
	public void SetPlayerMarkerPostion(int x,int y){
		mMapPresenter.SetPlayerMarkerPostion (x,y);
	}

	public List<CellPresenter> CellObjectList{
		get{
			return mMapPresenter.CellObjectList;
		}
	}
	public void SetPlayerMarkerDirection(PlayerDirection direction){
		mMapPresenter.SetPlayerMarkerDirection (direction);
	}
	[SerializeField]
	Button mArrowLeftButton;
	[SerializeField]
	Button mArrowRightButton;
	[SerializeField]
	Button mArrowUpButton;
	[SerializeField]
	Button mArrowDownButton;

	ItemDisplayPresenter mItemDisPlayPresenter;

	void SetButtonsEvent(){
		mArrowUpButton.onClick.AddListener (() => {
			GameManager.Instance.OnPushUpButton();
		});
		mArrowDownButton.onClick.AddListener (() => {
			GameManager.Instance.OnPushDownButton();
		});
		mArrowLeftButton.onClick.AddListener (() => {
			GameManager.Instance.OnPushLeftButton();
		});
		mArrowRightButton.onClick.AddListener (() => {
			GameManager.Instance.OnPushRightButton();
		});
	}

	// Use this for initialization
	void Start () {
		SetButtonsEvent ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
