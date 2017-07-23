using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Illust_scene2 : GameScreenEventBase {

	[SerializeField]
	Transform sword;

	// Use this for initialization
	void Start () {
		sword.gameObject.SetActive(false);
		StartCoroutine (Light());
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

		yield return new WaitForSeconds (0.8f);

		for (float f = 0; f <= 1; f += 0.03f) {
			c.color = new Color (1, 1, 1, 1.0f - f);
			yield return new WaitForSeconds (0.03f);
		}
		StartNext();
	}

	void StartNext(){
			
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where (m => 7 == m.id || (13 <= m.id && m.id <= 14)).ToList ()
		).SetEndCallBack (() => {
			// GameManager.Instance.AddPlayerItem (1);
			if (!GameManager.Instance.IsPossessedTargetItem (1)) {
				sword.gameObject.SetActive (true);
			};
		});

	}

	public override void ExcuteEvent ()
	{
	}
}
