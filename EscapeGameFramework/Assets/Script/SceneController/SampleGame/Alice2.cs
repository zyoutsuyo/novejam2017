using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Alice2 : BaseSceneController {

	bool mFinishedEvent1_2;
	bool mGetMedisun;

	/// <summary>
	/// ここにイベント実行時の処理が入ってきます
	/// </summary>
	/// <param name="itemEventType">Item event type.</param>
	/// <param name="eventId">Event identifier.</param>
	public override void ExcuteGameEvent (int eventId)
	{
		switch (eventId) {
		//何らかのenumを作る
		case 2:
			mGetMedisun = true;
			break;
		default:
			break;
		}
	}

	/// <summary>
	/// ここにアイテムイベント実行時の処理が入ってきます。
	/// </summary>
	/// <param name="itemEventType">Item event type.</param>
	/// <param name="itemId">Item identifier.</param>
	public override void ExcuteItemEvent (int itemId)
	{
		switch (itemId) {
		//何らかのenumを作る
		case 1:
			GameManager.Instance.UsePlayerItem (itemId);
			//次シーンへ遷移するためのイベントを追加
			var window = WindwManager.Instance.OpenStoryWindw (
				             GameManager.Instance.MasterStoryData.Where (m => m.id >= 2).ToList ()
			             );
			window.SetEndCallBack (()=>{
				GameManager.Instance.GoToScene("Alice3");
			});
			break;
		default:
			break;
		}
	}

	/// <summary>
	/// 画面切り替え時に発生するイベントトリガー
	/// </summary>
	/// <param name="gameScreen">Game screen.</param>
	public override void ExcuteScreenChangeEvent (GameScreenPresenter gameScreen)
	{
		switch (gameScreen.mId) {
		//TODO 名前ベタ書きで判定しているがなんか良い方法があったら差し替える
		case "1_2":
			if (!mFinishedEvent1_2) {
				//TODO なんかもっと良さそうな方法がありそうなので後ほど考える
				gameScreen.gameObject.GetComponent<Alice2_1_2>().ExcuteEvent();
				//ここにイベント実行
				mFinishedEvent1_2 = true;
			}
			break;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
