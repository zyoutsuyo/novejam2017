using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStageSelect : MonoBehaviour {

	[SerializeField]
	GameObject mESPButton;
	[SerializeField]
	GameObject mMangaButton;

	public void GotoEsp(){
		Application.LoadLevel ("");
	}
	public void GotoManga(){
		Application.LoadLevel ("");
	}

	// Use this for initialization
	void Start () {
		SoundManager.Instance.PlayBgm (0);
		SaveDataManager.Instance.LoadData ();
		if (SaveDataManager.Instance.SavedData.mClearESPGame) {
			mESPButton.SetActive (false);
		}
		if (SaveDataManager.Instance.SavedData.mClearMangeGame) {
			mMangaButton.SetActive (false);
		}
		if (SaveDataManager.Instance.SavedData.mClearESPGame && SaveDataManager.Instance.SavedData.mClearMangeGame) {
			Application.LoadLevel ("C_StageSelect");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
