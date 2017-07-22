using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager:SingletonMonoBehaviour<SaveDataManager>{

	GameSaveData mSaveData;
	public GameSaveData SavedData{
		get{
			return mSaveData;
		}
	}

	/// <summary>
	/// データのロード
	/// </summary>
	public void LoadData(){
		var data = PlayerPrefs.GetString(GameDef.GAME_SAVE_KEY);
		mSaveData = JsonUtility.FromJson<GameSaveData> (data);
		if (mSaveData == null) {
			mSaveData = new GameSaveData ();
		}
	}

	/// <summary>
	/// データのセーブ
	/// </summary>
	public void SaveData(){
		var data = JsonUtility.ToJson (mSaveData);
		PlayerPrefs.SetString(GameDef.GAME_SAVE_KEY, data);
	}

	[ContextMenu("データのダンプ")]
	void DumpData(){
		var data = JsonUtility.ToJson (mSaveData);
		Debug.Log (data);
	}

}
