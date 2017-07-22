using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Alice_1_3 : GameScreenEventBase {
	[SerializeField]
	Image mRabbit;
	public override void ExcuteEvent ()
	{
		StartCoroutine ("ExcuteRabbitEvent");
	}

	IEnumerator ExcuteRabbitEvent(){
		mRabbit.gameObject.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where (m => m.id == 4).ToList ()
		).SetEndCallBack (()=>{mRabbit.gameObject.SetActive (false);});
	}
}
