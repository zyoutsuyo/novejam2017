using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Illust_scene1 : GameScreenEventBase {

	// Use this for initialization
	void Start () {
		ExcuteEvent ();
	}


	// Update is called once per frame
	void Update () {

	}

	public override void ExcuteEvent ()
	{
			WindwManager.Instance.OpenStoryWindw (
				GameManager.Instance.MasterStoryData.Where (m => m.id <= 4).ToList ()
			).SetEndCallBack (() => {

				var c = transform.Find ("Color").GetComponent<Image>();
				c.color = new Color(1, 0, 0);

				WindwManager.Instance.OpenStoryWindw (
					GameManager.Instance.MasterStoryData.Where (m => 5 <= m.id && m.id <= 6).ToList ()
				).SetEndCallBack (() => {
					StartCoroutine(Blink());
				});
			});
	}

	IEnumerator Blink(){
		var c = transform.Find ("Color").GetComponent<Image>();
		for (int i = 0; i < 10; i++) {
			c.color = new Color (1, 1, 1);
			yield return new WaitForSeconds (0.05f);
			c.color = new Color (0,0,0);
			yield return new WaitForSeconds (0.05f);
		}


		StartCoroutine(StartNext());
	}


	IEnumerator StartNext(){
		yield return new WaitForSeconds (0.5f);
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where (m => 7 <= m.id && m.id <= 11).ToList ()
		).SetEndCallBack (() => {
			// GameManager.Instance.AddPlayerItem (1);
		});
	}
}
