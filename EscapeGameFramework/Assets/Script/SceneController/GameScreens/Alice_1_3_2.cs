using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Alice_1_3_2 : GameScreenEventBase {
	[SerializeField]
	Image mBlackScreen;
	public override void ExcuteEvent ()
	{
		StartCoroutine ("ExcuteGoToNextEvent");
	}

	IEnumerator ExcuteGoToNextEvent(){
		SoundManager.Instance.PlaySe (1);
		mBlackScreen.gameObject.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		var window = WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where(m=>m.id >= 5&&m.id <= 7).ToList()
		);
		window.SetEndCallBack (()=>{
			//次画面へ遷移
			GameManager.Instance.GoToScene("Alice2");
		});
	}
}
