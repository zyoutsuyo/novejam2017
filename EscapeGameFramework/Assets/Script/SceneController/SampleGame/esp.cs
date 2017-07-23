using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class esp : BaseSceneController {
	public bool mFinishedEvent1_3;
	public bool mFinishedEvent1_1;

	bool getitem1 = false;
	bool getitem2 = false;
	bool getitem3 = false;
	bool getitem4 = false;
	bool getitem5 = false;
	bool getitem6 = false;

	bool OnOpening;

	/// <summary>
	/// ここにイベント実行時の処理が入ってきます
	/// </summary>
	/// <param name="itemEventType">Item event type.</param>
	/// <param name="eventId">Event identifier.</param>
	public override void ExcuteGameEvent (int eventId)
	{
		if (eventId == 1 && !getitem1) {
			int itemId = 1;
			GameManager.Instance.AddPlayerItem (itemId);
			getitem1 = true;
		} else if (eventId == 2 && !getitem2) {
			int itemId = 2;
			GameManager.Instance.AddPlayerItem (itemId);
			getitem2 = true;
		} else if (eventId == 3 && !getitem3) {
			int itemId = 3;
			GameManager.Instance.AddPlayerItem (itemId);
			getitem3 = true;
		} else if (eventId == 4 && !getitem4) {
			int itemId = 4;
			GameManager.Instance.AddPlayerItem (itemId);
			getitem4 = true;
		} else if (eventId == 5 && !getitem5) {
			int itemId = 5;
			GameManager.Instance.AddPlayerItem (itemId);
			getitem5 = true;
		} else if (eventId == 6) {
			WindwManager.Instance.OpenStoryWindw (
				GameManager.Instance.MasterStoryData.Where(m=>m.id >= 15&&m.id<= 15).ToList()
			);
		} else if (eventId == 7) {
			WindwManager.Instance.OpenStoryWindw (
				GameManager.Instance.MasterStoryData.Where(m=>m.id >= 15&&m.id<= 15).ToList()
			);
		}
	}

	/// <summary>
	/// ここにアイテムイベント実行時の処理が入ってきます。
	/// </summary>
	/// <param name="itemEventType">Item event type.</param>
	/// <param name="itemId">Item identifier.</param>
	public override void ExcuteItemEvent (int itemId)
	{
		if (itemId == 1) {
			//アイテムを消費。(アイテムリストからアイテムを削除)。
			GameManager.Instance.UsePlayerItem (1);
			int _itemId = 6;
			GameManager.Instance.AddPlayerItem (_itemId);
			if(HanteiItem()){
				if(HanteiItem()){
					WindwManager.Instance.OpenStoryWindw (
						GameManager.Instance.MasterStoryData.Where(m=>m.id >= 16&&m.id<= 21).ToList()
					);
				}
			}
		}else if (itemId == 2) {
			//アイテムを消費。(アイテムリストからアイテムを削除)。
			GameManager.Instance.UsePlayerItem (2);
			int __itemId = 7;
			GameManager.Instance.AddPlayerItem (__itemId);
			if(HanteiItem()){
				WindwManager.Instance.OpenStoryWindw (
					GameManager.Instance.MasterStoryData.Where(m=>m.id >= 16&&m.id<= 21).ToList()
				);
			}
		}


	}

	bool HanteiItem(){
		var items = GameManager.Instance.Player.ItemList;
		int count = 0;
		if (items.Exists (item => item.ItemModel.mId == 3))
			count++;
		if (items.Exists (item => item.ItemModel.mId == 4))
			count++;
		if (items.Exists (item => item.ItemModel.mId == 5))
			count++;
		if (items.Exists (item => item.ItemModel.mId == 6))
			count++;
		if (items.Exists (item => item.ItemModel.mId == 7))
			count++;
		return count == 5;
	}

	/// <summary>
	/// 画面切り替え時に発生するイベントトリガー
	/// </summary>
	/// <param name="gameScreen">Game screen.</param>
	public override void ExcuteScreenChangeEvent (GameScreenPresenter gameScreen)
	{
		switch (gameScreen.mId) {
		//TODO 名前ベタ書きで判定しているがなんか良い方法があったら差し替える
		case "1_1":
			if (!mFinishedEvent1_1) {
				//TODO なんかもっと良さそうな方法がありそうなので後ほど考える
				//StartCoroutine("OpenGameSatrtEvent");
				//ここにイベント実行
				//mFinishedEvent1_1 = true;
			}
			break;
		case "1_3":
			if (!OnOpening) {
				StartCoroutine ("OpenGameSatrtEvent");
				OnOpening = true;
				//TODO なんかもっと良さそうな方法がありそうなので後ほど考える
				//gameScreen.gameObject.GetComponent<Alice_1_3> ().ExcuteEvent ();
				//ここにイベント実行
				//mFinishedEvent1_3 = true;
			}

			break;
		default:
			break;
		}
	}

	IEnumerator OpenGameSatrtEvent(){
		yield return new WaitForSeconds (1.0f);
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where(m=>m.id >= 1&&m.id<= 14).ToList()
		);
		while (WindwManager.Instance.IsOpenStoryWindow) {
			//Windowが開いている間はループして待機
			yield return null;
		}
		//ここにうさぎが走りさるイベントを入れる
		/*
		var currentScreen = GameScreenManager.Instance.CurrentGameScreen;
		currentScreen.ExcuteEvent ();
		yield return new WaitForSeconds (1.0f);
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where(m=>m.id == 3).ToList()
		);
		*/
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
