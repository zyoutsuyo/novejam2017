using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Reflection;

public class MapPresenter : MonoBehaviour {

	[SerializeField]
	PlayerMarkerPresenter mPlayerMarkerPresenter;
	[SerializeField]
	CellPresenter mCellPresenterPrefab;

	/// <summary>
	/// マップのマスターデータ
	/// </summary>
	List<AdvCellModel> mMasterMapData{
		get{
			return GameManager.Instance.mMasterMapData;
		}
	}

	[SerializeField]
	GridLayoutGroup mGrid;

	List<CellPresenter> mCellObjectList = new List<CellPresenter>();
	public List<CellPresenter> CellObjectList{
		get{
			return mCellObjectList;
		}
	}
	public void SetPlayerMarkerDirection(PlayerDirection direction){
		mPlayerMarkerPresenter.SetPlayerMarkerDirection (direction);
	}


	//const string MAP_PROPERTIE_PREFIX = "m_";
	/// <summary>
	/// プレイヤーの座標セット
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	public void SetPlayerMarkerPostion(int x,int y){
		var targetCell = mCellObjectList.Where (c => c.y == y && c.x == x).FirstOrDefault ();
		if (targetCell != null) {
			mPlayerMarkerPresenter.transform.position = targetCell.transform.position;
			GameManager.Instance.Player.SetCoordinate (x, y);
			GameManager.Instance.Player.SetUnderCell (targetCell);
		} else {
			Debug.LogError ("対象のマスがありません");
		}
	}

	void CreateMapUI(){
		Debug.Log ("CreateMapUI");
		foreach (var m in mMasterMapData) {
			PropertyInfo[] infoArray = m.mModel.GetType().GetProperties();
			foreach (var i in infoArray) {
				int verticalNumber = int.Parse(i.Name.Replace(GameDef.MAP_PROPERTIE_PREFIX,""));
				if (m.GetValueFromVerticalNumber (verticalNumber) != "") {
					var cell = PrefabFolder.InstantiateTo<CellPresenter> (mCellPresenterPrefab, mGrid.transform);
					cell.Init (m, verticalNumber);
					mCellObjectList.Add (cell);
				}
			}
		}
	}

	void SetGridWidth(){
		mGrid.GetComponent<RectTransform> ().sizeDelta = new Vector2 (mGrid.cellSize.x*GameManager.Instance.mMapVerticalPropertieCount,0);
	}

	// Use this for initialization
	void Start () {
		CreateMapUI ();
		SetGridWidth ();
	}

	// Update is called once per frame
	void Update () {

	}
}
