using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ゲーム中のセーブデータを保持
/// </summary>

[Serializable]
public class GameSaveData{
	//テスト確認用フラグ
	public bool GetTestItem = false;
	public int PlayerPostionX = GameDef.PLAYER_DEFALT_POSTHION_X;
	public int PlayerPostionY = GameDef.PLAYER_DEFALT_POSTHION_Y;
	public List<int> ItemList = new List<int>();
	public List<bool> ItemUseList = new List<bool>();
	public bool IsEnteredFirstTime = true;
	public bool mClearESPGame = false;
	public bool mClearMangeGame = false;
}
