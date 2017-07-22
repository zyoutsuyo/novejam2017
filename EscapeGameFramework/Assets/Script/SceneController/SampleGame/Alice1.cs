using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Alice1 : BaseSceneController {

	public bool mFinishedEvent1_3;
	public bool mFinishedEvent1_1;

	/// <summary>
	/// ここにイベント実行時の処理が入ってきます
	/// </summary>
	/// <param name="itemEventType">Item event type.</param>
	/// <param name="eventId">Event identifier.</param>
	public override void ExcuteGameEvent (int eventId)
	{
	}

	/// <summary>
	/// ここにアイテムイベント実行時の処理が入ってきます。
	/// </summary>
	/// <param name="itemEventType">Item event type.</param>
	/// <param name="itemId">Item identifier.</param>
	public override void ExcuteItemEvent (int itemId)
	{
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
				StartCoroutine("OpenGameSatrtEvent");
				//ここにイベント実行
				mFinishedEvent1_1 = true;
			}
			break;
		case "1_3":
			if (!mFinishedEvent1_3) {
				//TODO なんかもっと良さそうな方法がありそうなので後ほど考える
				gameScreen.gameObject.GetComponent<Alice_1_3> ().ExcuteEvent ();
				//ここにイベント実行
				mFinishedEvent1_3 = true;
			}

			break;
		default:
			break;
		}
	}

	IEnumerator OpenGameSatrtEvent(){
		yield return new WaitForSeconds (1.0f);
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where(m=>m.id >= 1&&m.id<= 2).ToList()
		);
		while (WindwManager.Instance.IsOpenStoryWindow) {
			//Windowが開いている間はループして待機
			yield return null;
		}
		//ここにうさぎが走りさるイベントを入れる
		var currentScreen = GameScreenManager.Instance.CurrentGameScreen;
		currentScreen.ExcuteEvent ();
		yield return new WaitForSeconds (1.0f);
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where(m=>m.id == 3).ToList()
		);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
