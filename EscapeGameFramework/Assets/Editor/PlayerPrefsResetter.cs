using UnityEngine;
using UnityEditor;

/// <summary>
/// PlayerPrefsを初期化するクラス
/// </summary>
public static class PlayerPrefsResetter {

	[MenuItem("Tools/Reset PlayerPrefs")]
	public static void ResetPlayerPrefs(){
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();
		Debug.Log ("Reset PlayerPrefs!!!");
	}

	[MenuItem("Tools/SaveData")]
	public static void GameSaveData(){
		SaveDataManager.Instance.SaveData ();
		Debug.Log ("ゲームデータをセーブしました。");
	}

	[MenuItem("Tools/LoadData")]
	public static void GameLoadData(){
		SaveDataManager.Instance.LoadData ();
		Debug.Log ("ゲームデータを読み込みました");
	}

}