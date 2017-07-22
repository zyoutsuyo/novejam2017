using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Alice4 : BaseSceneController {


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
		switch (itemId) {
		case 1:
			SoundManager.Instance.PlaySe(8);
			GameManager.Instance.UsePlayerItem(1);
			WindwManager.Instance.OpenStoryWindw (
				GameManager.Instance.MasterStoryData.Where(m=>m.id >= 1&& m.id <= 2).ToList()
			).SetEndCallBack(()=>{
				GameManager.Instance.GoToScene("E_Ending");
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

	}
		


}
