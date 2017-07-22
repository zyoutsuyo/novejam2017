using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameFlags{
}

public enum GameState{
	NONE,
	WAIT,
	GAME_INIT,
	MAIN,
	ADVENTURE,
	GET_ITEM,
}

public class GameManager : SingletonMonoBehaviour<GameManager> {

	/// <summary>
	/// プレイヤーの向きや方角を使うかどうか？
	/// </summary>
	public bool UseDirection = false;

	//ゲーム中の各種フラグを所持
	GameFlags mGameFlags = new GameFlags();
	GameState mGameState = GameState.NONE;
	/// <summary>
	/// アイテムモデルのマスターデータ:Jsonからデシリアライズして生成
	/// </summary>
	List<ItemModel> mMasterItemData = new List<ItemModel> ();
	/// <summary>
	/// ストーリーモデルのマスターデータ:Jsonからデシリアライズして生成
	/// </summary>
	List<StoryModel> mMasterStoryData = new List<StoryModel> ();
	public List<ItemModel> MasterItemData{
		get{
			return mMasterItemData;
		}
	}
	public List<StoryModel> MasterStoryData{
		get{
			return mMasterStoryData;
		}
	}
	/// <summary>
	/// マップのマスターデータ:Jsonからデシリアライズして生成
	/// </summary>
	public List<AdvCellModel> mMasterMapData = new List<AdvCellModel> ();
	/// <summary>
	/// マップのプロパティ個数
	/// </summary>
	/// <value>The m map vertical propati count.</value>
	public int mMapVerticalPropertieCount{
		get{
			return BaseSceneController.Instance.MaxMapVerticalPropertieCount;
		}
	}
	//int mapVerticalPropertieCount=0;
	/// <summary>
	/// ゲームスクリーンのリスト:Jsonからデシリアライズ+Prefab化して生成
	/// </summary>
	List<GameScreenPresenter> mGameScreenList = new List<GameScreenPresenter>();
	//プレイヤー
	PlayerPresenter mPlayer;
	//プレイヤー
	public PlayerPresenter Player{
		get{
			return mPlayer;
		}
	}
	/// <summary>
	/// プレイヤーの所持アイテムを増やす
	/// </summary>
	/// <param name="item">Item.</param>
	public void AddPlayerItem(AdvItemModel item){
		Player.ItemList.Add (item);
		mItemDisplayPresenter.AddPlayerItem (item);
		//セーブデータの更新
		UpDatePlayerItemListSaveData();

	}
	/// <summary>
	/// プレイヤーの所持アイテムを増やす
	/// </summary>
	/// <param name="item">Item.</param>
	public void AddPlayerItem(int id){
		var item = new AdvItemModel(mMasterItemData.Where (i => i.mId == id).FirstOrDefault ());
		AddPlayerItem (item);
	}
	/// <summary>
	/// 対象idのアイテムをプレイヤーが保持しているかいなか
	/// </summary>
	/// <returns><c>true</c> if this instance is possessed target item the specified id; otherwise, <c>false</c>.</returns>
	/// <param name="id">Identifier.</param>
	public bool IsPossessedTargetItem(int id){
		return Player.ItemList.Exists (item => item.ItemModel.mId == id);
	}

	/// <summary>
	/// プレイヤーの所持アイテムを減らす
	/// </summary>
	/// <param name="item">Item.</param>
	public void RemovePlayerItem(AdvItemModel item){
		Player.ItemList.Remove (item);
		mItemDisplayPresenter.RemovePlayerItem (item);
		//セーブデータの更新
		UpDatePlayerItemListSaveData();
	}

	public void UsePlayerItem(AdvItemModel item){
		//アイテムの使用フラグを立てる
		item.UseItem ();
		//アイテム表示リストの更新
		mItemDisplayPresenter.UpDateItemDisplay();
		//セーブデータの更新
		UpDatePlayerItemListSaveData();
	}
	public void UsePlayerItem(int itemId){
		var item = Player.ItemList.Where (i => i.ItemModel.mId == itemId).FirstOrDefault ();
		UsePlayerItem (item);
	}

	/// <summary>
	/// プレイヤーの所持アイテム状態の更新
	/// </summary>
	public void UpDatePlayerItemListSaveData(){
		SaveDataManager.Instance.SavedData.ItemList = Player.ItemList.Select(i => i.ItemModel.mId).ToList();
		SaveDataManager.Instance.SavedData.ItemUseList = Player.ItemList.Select(i => i.IsUsed).ToList();
		SaveDataManager.Instance.SaveData ();
	}
	/// <summary>
	/// プレイヤーの所持アイテム情報を読み込む
	/// </summary>
	public void LoadPlayerItemListSaveData(){
		Player.ItemList = SaveDataManager.Instance.SavedData.ItemList.Select (itemId => new AdvItemModel (itemId)).ToList ();
		for (int i = 0; i < SaveDataManager.Instance.SavedData.ItemUseList.Count; i++) {
			Player.ItemList [i].SetUsedFlag (SaveDataManager.Instance.SavedData.ItemUseList [i]);
		}
	}

	/// <summary>
	/// ゲーム中のメインUIの親
	/// </summary>
	[SerializeField]
	GameUIParentPresenter mGameUIParentPresenter;
	public List<CellPresenter> CellObjectList{
		get{
			return mGameUIParentPresenter.MapPresenter.CellObjectList;
		}
	}
	/// <summary>
	/// 所持アイテムの表示用UI
	/// </summary>
	[SerializeField]
	ItemDisplayPresenter mItemDisplayPresenter;
	/// <summary>
	/// 現在再生中のシーン名
	/// </summary>
	/// <value>The name of the current scene.</value>
	public string CurrentSceneName{
		get{
			return Application.loadedLevelName;
		}
	}

	/// <summary>
	/// プレイヤーのマーカー位置を変更
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	public void SetPlayerPostion(int x,int y){
		SaveDataManager.Instance.SavedData.PlayerPostionX = x;
		SaveDataManager.Instance.SavedData.PlayerPostionY = y;
		//データのセーブ
		SaveDataManager.Instance.SaveData ();
		mGameUIParentPresenter.MapPresenter.SetPlayerMarkerPostion (x,y);
	}

	/// <summary>
	/// 上ボタンを押したとき
	/// </summary>
	public void OnPushUpButton(){
		OnPushButtonCommonFanction ();
		SetPlayerMarkerDirection (PlayerDirection.UP);
		//y=0の時は移動不可
		if(mPlayer.Coordinate.y == 0)return;
		//一つ上のCellを取得
		var targetCell = GetCellFromCoordinate (mPlayer.UnderCell.x,mPlayer.UnderCell.y-1);
		if (targetCell == null || targetCell.IsImpossibleInvade) {
			//ゲームスクリーンの更新		
			GameScreenManager.Instance.UpdateGameScreneFromPlayerPostion(Player);
			return;
		}
		SetPlayerPostion (targetCell.x,targetCell.y);
		//ゲームスクリーンの更新		
		GameScreenManager.Instance.UpdateGameScreneFromPlayerPostion(Player);
	}
	/// <summary>
	/// 下ボタンを押したとき
	/// </summary>
	public void OnPushDownButton(){
		OnPushButtonCommonFanction ();
		SetPlayerMarkerDirection (PlayerDirection.DOWN);
		//一番したの時は移動不可
		if(mPlayer.Coordinate.y == mMasterMapData.Count-1)return;
		//一つ下のCellを取得
		var targetCell = GetCellFromCoordinate (mPlayer.UnderCell.x,mPlayer.UnderCell.y+1);
		if (targetCell == null || targetCell.IsImpossibleInvade) {
			//ゲームスクリーンの更新		
			GameScreenManager.Instance.UpdateGameScreneFromPlayerPostion(Player);
			return;
		}
		SetPlayerPostion (targetCell.x,targetCell.y);
		//ゲームスクリーンの更新		
		GameScreenManager.Instance.UpdateGameScreneFromPlayerPostion(Player);
	}
	/// <summary>
	/// 左ボタンを押したとき
	/// </summary>
	public void OnPushLeftButton(){
		OnPushButtonCommonFanction ();
		SetPlayerMarkerDirection (PlayerDirection.LEFT);
		//x=0の時は移動不可
		if(mPlayer.Coordinate.x == 0)return;
		//一つ左のCellを取得
		var targetCell = GetCellFromCoordinate (mPlayer.UnderCell.x-1,mPlayer.UnderCell.y);
		if (targetCell == null || targetCell.IsImpossibleInvade) {
			//ゲームスクリーンの更新		
			GameScreenManager.Instance.UpdateGameScreneFromPlayerPostion(Player);
			return;
		}
		SetPlayerPostion (targetCell.x,targetCell.y);
		//ゲームスクリーンの更新		
		GameScreenManager.Instance.UpdateGameScreneFromPlayerPostion(Player);
	}
	/// <summary>
	/// 右ボタンを押したとき
	/// </summary>
	public void OnPushRightButton(){
		OnPushButtonCommonFanction ();
		SetPlayerMarkerDirection (PlayerDirection.RIGHT);
		//x=一番右の時は移動不可
		if(mPlayer.Coordinate.x == BaseSceneController.Instance.MaxMapVerticalPropertieCount-1)return;
		//一つ上のCellを取得
		var targetCell = GetCellFromCoordinate (mPlayer.UnderCell.x+1,mPlayer.UnderCell.y);
		if (targetCell == null || targetCell.IsImpossibleInvade) {
			//ゲームスクリーンの更新		
			GameScreenManager.Instance.UpdateGameScreneFromPlayerPostion(Player);
			return;
		}
		SetPlayerPostion (targetCell.x,targetCell.y);
		//ゲームスクリーンの更新		
		GameScreenManager.Instance.UpdateGameScreneFromPlayerPostion(Player);
	}

	/// <summary>
	/// 矢印ボタン押下時の共通処理
	/// </summary>
	void OnPushButtonCommonFanction(){
		SoundManager.Instance.PlaySe(8);
	}

	void SetPlayerMarkerDirection(PlayerDirection direction){
		mGameUIParentPresenter.SetPlayerMarkerDirection (direction);
	}

	CellPresenter GetCellFromCoordinate(int x,int y){
		return CellObjectList.Where (c => c.y == y && c.x == x).FirstOrDefault ();
	}

	public void LoadMasterData(){
		// MapJsonを取得
		//TODO 定数
		var mapJson = (Resources.Load("MasterData/"+Application.loadedLevelName+"/"+"Map") as TextAsset).text;
		var WrapJson = MapJsonHelper.GetWrapJson(mapJson);
		MapCellModel[] mapMasterModel = MapJsonHelper.FromJson<MapCellModel> (WrapJson);
		mMasterMapData = mapMasterModel.Select (m => new AdvCellModel (m)).ToList ();
		for (int i = 0; i < mMasterMapData.Count; i++) {
			mMasterMapData [i].SetSideLineNumber (i);
		}
		//-----------------------
		// ItemJsonを取得
		//TODO 定数
		var itemJson = (Resources.Load("MasterData/"+Application.loadedLevelName+"/"+"Item") as TextAsset).text;
		var ItemWrapJson = ItemJsonHelper.GetWrapJson(itemJson);
		ItemModel[] itemMasterModel = ItemJsonHelper.FromJson<ItemModel> (ItemWrapJson);
		mMasterItemData = itemMasterModel.ToList ();
		//-----------------------
		// StoryJsonを取得
		//TODO 定数
		var storyJson = (Resources.Load("MasterData/"+Application.loadedLevelName+"/"+"Story") as TextAsset).text;
		var StoryWrapJson = StoryJsonHelper.GetWrapJson(storyJson);
		StoryModel[] storyMasterModel = StoryJsonHelper.FromJson<StoryModel> (StoryWrapJson);
		mMasterStoryData = storyMasterModel.ToList ();

	}

	void Awake(){
		//セーブデータのロード
		SaveDataManager.Instance.LoadData ();
		//マスターデータのロード
		LoadMasterData ();
		//TODO PlayerPresenterとplayerMarkerが同一の方が良さげ
		mPlayer = new PlayerPresenter ();

	}

	/// <summary>
	/// セーブデータからプレイヤー情報を復元
	/// </summary>
	[ContextMenu("プレイヤー情報をセーブデータから読み込み")]
	void LoadPlayerPostionFromSaveData(){
		//セーブデータからプレイヤーの座標をセット
		SetPlayerPostion (
			SaveDataManager.Instance.SavedData.PlayerPostionX,
			SaveDataManager.Instance.SavedData.PlayerPostionY
		);
		//ゲームスクリーンの更新		
		GameScreenManager.Instance.UpdateGameScreneFromPlayerPostion(Player);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (mGameState) {
		case GameState.NONE:
			//初期の状態　ここからGameInitのステートへ以降
			mGameState = GameState.GAME_INIT;
			break;
		case GameState.GAME_INIT://ここでゲームの初期化を行う

			//セーブデータの読み込み
			if (SaveDataManager.Instance.SavedData.IsEnteredFirstTime) {//初回の場合
				SetPlayerPostion (
					(int)BaseSceneController.Instance.PlayerDefaltPostion.x,
					(int)BaseSceneController.Instance.PlayerDefaltPostion.y
				);
				//ゲームスクリーンの更新		
				GameScreenManager.Instance.UpdateGameScreneFromPlayerPostion(Player);
				SaveDataManager.Instance.SavedData.IsEnteredFirstTime = false;
				SaveDataManager.Instance.SaveData ();
			} else {//すでにステージに来たことがある場合
				LoadPlayerPostionFromSaveData ();
			}
			LoadPlayerItemListSaveData ();
			//BGMの再生を行う
			SoundManager.Instance.PlayBgm(0);
			//所持アイテム表示欄の更新
			foreach (var item in mPlayer.ItemList) {
				mItemDisplayPresenter.AddPlayerItem (item);
			}

			//ゲームを初期化したのでステートを切り替える
			mGameState = GameState.MAIN;
			break;
		case GameState.MAIN:
			break;
		default:
			break;
		}
	}
	[ContextMenu("プレイヤーの所持アイテムを出力")]
	void DebugDumpPlayerItemList(){
		foreach (var item in Player.ItemList) {
			Debug.Log (item.ItemModel.mName);
		}
	}

	/// <summary>
	/// 別シーンへ遷移
	/// </summary>
	/// <param name="sceneName">Scene name.</param>
	public void GoToScene(string sceneName){
		Application.LoadLevel (sceneName);
	}

}
