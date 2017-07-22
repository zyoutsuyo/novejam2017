using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Alice_1_1 : MonoBehaviour {
	
	[SerializeField]
	Image mRabbitImage;

	public void RabbitEntryEvent(){
		SoundManager.Instance.PlaySe(5);

		var sequence = DOTween.Sequence();
		sequence.SetEase(Ease.InOutCirc);
		sequence.Append(
			mRabbitImage.rectTransform.DOLocalMove(new Vector3(-110.6f, 0), 1.0f)
		);
		sequence.Append(
			mRabbitImage.rectTransform.DOLocalMove(new Vector3(-110.6f, 0), 1.5f)
		);
		sequence.Append(
			mRabbitImage.rectTransform.DOLocalMove(new Vector3(1000.6f, 0), 0.5f)
		);
		sequence.Play ();
		Debug.Log ("RabbitEntryEvent");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
