using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Illust_scene3 : GameScreenEventBase {

	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {

	}

	IEnumerator Light(){
		var c = transform.Find ("Color").GetComponent<Image>();
		for (float f = 0; f <= 1; f += 0.04f) {
			c.color = new Color (f, f, f);
			yield return new WaitForSeconds (0.05f);
		}

		StartNext();
	}

	void StartNext(){
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where (m => 7 == m.id || (13 <= m.id && m.id <= 14)).ToList ()
		).SetEndCallBack (() => {
			// GameManager.Instance.AddPlayerItem (1);
		});
	}

	public override void ExcuteEvent ()
	{
	}
}
