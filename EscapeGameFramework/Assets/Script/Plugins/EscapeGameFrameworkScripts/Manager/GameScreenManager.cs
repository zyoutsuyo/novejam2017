using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenManager : SingletonMonoBehaviour<GameScreenManager> {

	GameScreenPresenter mCurrentGameScreen;
	public GameScreenPresenter CurrentGameScreen{
		get{
			return mCurrentGameScreen;
		}
	}

	/// <summary>
	/// プレイヤーの位置からゲームスクリーンを更新
	/// </summary>
	/// <param name="player">Player.</param>
	public void UpdateGameScreneFromPlayerPostion(PlayerPresenter player){
		if (mCurrentGameScreen != null) {
			DestroyImmediate (mCurrentGameScreen.gameObject);
			mCurrentGameScreen = null;
		}
		// プレハブを取得
		GameObject prefab;
		if (GameManager.Instance.UseDirection) {
			prefab = (GameObject)Resources.Load ("GameScreens/"+Application.loadedLevelName+"/"+player.Coordinate.x+"_"+player.Coordinate.y+"_"+player.CurrentDirection.ToString());
		} else {
			prefab = (GameObject)Resources.Load ("GameScreens/"+Application.loadedLevelName+"/"+player.Coordinate.x+"_"+player.Coordinate.y);
		}

		mCurrentGameScreen = PrefabFolder.InstantiateTo<GameScreenPresenter> (prefab,this.transform);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
