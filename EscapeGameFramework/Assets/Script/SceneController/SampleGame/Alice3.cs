using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Alice3 : BaseSceneController {

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
				OpenGameEndEvent();
				mFinishedEvent1_1 = true;
			}
			break;
		default:
			break;
		}
	}

	void OpenGameEndEvent(){
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where(m=>m.id >= 1).ToList()
		).SetEndCallBack(()=>{
			GameManager.Instance.GoToScene("E_Ending");
		});
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
