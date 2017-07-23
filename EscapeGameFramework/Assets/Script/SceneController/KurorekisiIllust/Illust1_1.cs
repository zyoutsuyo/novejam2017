using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Illust1_1 : GameScreenEventBase {

	// Use this for initialization
	void Start () {
		ExcuteEvent ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void ExcuteEvent ()
	{
		if (!GameManager.Instance.IsPossessedTargetItem (1)) {
			WindwManager.Instance.OpenStoryWindw (
				GameManager.Instance.MasterStoryData.Where (m => m.id <= 3).ToList ()
			).SetEndCallBack (() => {
				GameManager.Instance.AddPlayerItem (1);
			});
		}
	}
}
