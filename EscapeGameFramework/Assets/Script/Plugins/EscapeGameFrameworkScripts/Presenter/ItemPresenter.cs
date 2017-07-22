using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ItemPresenter : MonoBehaviour {

	ItemModel mItemModel;
	public AdvItemModel mAdvItemModel{
		get{
			return new AdvItemModel (mItemModel);
		}
	}
	[SerializeField]
	Image mImage;
	/// <summary>
	/// インスペクター表示用アイテム名
	/// </summary>
	[SerializeField]
	string mItemName;
	//Prefabで設定したItemIdからマスターデータをAwakeで読み込む
	[SerializeField]
	int mItemId;
	[SerializeField]
	Button mButton;

	[ContextMenu("データ読み込み")]
	public void Init(){
		GameObject prefab;
		if (GameManager.Instance.MasterItemData.Count == 0) {
			LoadItem (LoadMasterData());
		} else {
			LoadItem (GameManager.Instance.MasterItemData);
		}
		mItemName = mItemModel.mName;
		mButton.targetGraphic = mImage;
		mButton.onClick.AddListener (()=>{
			OnPushItem();
		});
	}

	void LoadItem(List<ItemModel> masterData){
		mItemModel = masterData.Where (i => i.mId == mItemId).FirstOrDefault ();
		var prefab = (GameObject)Resources.Load ("Item/"+mItemModel.mGraphicPath);
		mImage = PrefabFolder.InstantiateTo<Image> (prefab,this.transform);
	}

	List<ItemModel> LoadMasterData(){
		var itemJson = (Resources.Load ("MasterData/Item") as TextAsset).text;
		var ItemWrapJson = ItemJsonHelper.GetWrapJson (itemJson);
		ItemModel[] itemMasterModel = ItemJsonHelper.FromJson<ItemModel> (ItemWrapJson);
		return itemMasterModel.ToList ();
	}
	bool mOnClick = false;
	void OnPushItem(){
		if (mOnClick)
			return;
		mOnClick = true;
		GameManager.Instance.AddPlayerItem (mAdvItemModel);
		Destroy (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		if (mImage != null) {
			DestroyImmediate (mImage.gameObject);
			mImage = null;
		}
		//Init ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
