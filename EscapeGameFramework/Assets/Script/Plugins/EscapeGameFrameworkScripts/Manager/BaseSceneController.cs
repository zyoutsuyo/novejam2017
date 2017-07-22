using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーンコントローラーの基底クラス
/// </summary>
public abstract class BaseSceneController : SingletonMonoBehaviour<BaseSceneController> {

	[SerializeField]
	Vector2 mPlayerDefaltPostion;
	[SerializeField]
	public int mMaxMapVerticalPropertieCount = 4;
	public int MaxMapVerticalPropertieCount{
		get{
			return mMaxMapVerticalPropertieCount;
		}
	}
	public Vector2 PlayerDefaltPostion{
		get{
			return mPlayerDefaltPostion;
		}
	}

	/// <summary>
	/// イベントの実行
	/// </summary>
	/// <param name="itemEventType">Item event type.</param>
	public abstract void ExcuteGameEvent(int eventId);

	/// <summary>
	/// Itemイベントの実行
	/// </summary>
	/// <param name="itemEventType">Item event type.</param>
	public abstract void ExcuteItemEvent(int itemId);

	/// <summary>
	/// 画面切り替え時に発生するイベントトリガー
	/// </summary>
	/// <param name="gameScreen">Game screen.</param>
	public abstract void ExcuteScreenChangeEvent (GameScreenPresenter gameScreen);

}
