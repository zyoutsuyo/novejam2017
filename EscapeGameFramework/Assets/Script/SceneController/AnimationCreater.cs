using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AnimationCreater : BaseSceneController {


	[SerializeField]
	CharaController mCharaCon;

	bool end1;
	bool end2;
	bool end3;
	bool end4;
	bool end5;
	bool end6;
	bool end7;
	bool end8;
	bool end9;
	bool end10;

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
			break;
		case "1_3":
			break;
		default:
			break;
		}
	}

	IEnumerator OpenGameSatrtEvent(){
		mCharaCon.SetCharaFace(CharaFaceType.NORMAL);
		yield return new WaitForSeconds (1.0f);
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where(m=>m.id >= 1&&m.id<= 3).ToList()
		).SetEndCallBack(()=>{
			end1 = true;
		});
		while (!end1) {
			yield return null;
		}
		mCharaCon.SetCharaFace(CharaFaceType.EFFECT);
		yield return new WaitForSeconds (1.0f);
		mCharaCon.SetCharaFace(CharaFaceType.DELIGHT);
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where(m=>m.id >= 4&&m.id<= 4).ToList()
		).SetEndCallBack(()=>{
			end2 = true;
		});
		while (!end2) {
			yield return null;
		}
		mCharaCon.SetCharaFace(CharaFaceType.ANGER);
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where(m=>m.id >= 5&&m.id<= 7).ToList()
		).SetEndCallBack(()=>{
			end3 = true;
		});
		while (!end3) {
			yield return null;
		}

	}

	// Use this for initialization
	void Start () {
		StartCoroutine ("OpenGameSatrtEvent");
	}

	// Update is called once per frame
	void Update () {

	}
}
