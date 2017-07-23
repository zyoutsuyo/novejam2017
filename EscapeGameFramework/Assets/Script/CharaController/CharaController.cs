using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharaFaceType{
	NORMAL,//普通
	ANGER,//怒り
	GRIEF,//悲しみ
	DELIGHT,//喜び
	EFFECT,//効果
	OLD_MAN,
}

public class CharaController : MonoBehaviour {
	[SerializeField]
	Image 口ひげ開き;
	[SerializeField]
	Image 口ひげ閉じ;
	[SerializeField]
	Image 眉毛普通;
	[SerializeField]
	Image 眉毛怒り;
	[SerializeField]
	Image 悲しみ;
	[SerializeField]
	Image 怒り;
	[SerializeField]
	Image ニヤニヤ;
	[SerializeField]
	Image 目普通;
	[SerializeField]
	Image 口開く;
	[SerializeField]
	Image 口よだれ;
	[SerializeField]
	Image 口への字;
	[SerializeField]
	Image 効果線;

	public void SetCharaFace(CharaFaceType face){
		HiddenFaceImages ();
		switch (face) {
		case CharaFaceType.NORMAL:
			眉毛普通.gameObject.SetActive (true);
			口開く.gameObject.SetActive (true);
			目普通.gameObject.SetActive (true);
			break;
		case CharaFaceType.GRIEF:
			悲しみ.gameObject.SetActive (true);
			口への字.gameObject.SetActive (true);
			目普通.gameObject.SetActive (true);
			break;
		case CharaFaceType.DELIGHT:
			眉毛普通.gameObject.SetActive (true);
			口よだれ.gameObject.SetActive (true);
			ニヤニヤ.gameObject.SetActive (true);
			break;
		case CharaFaceType.ANGER:
			怒り.gameObject.SetActive (true);
			口開く.gameObject.SetActive (true);
			目普通.gameObject.SetActive (true);
			break;
		case CharaFaceType.EFFECT:
			ニヤニヤ.gameObject.SetActive (true);
			口開く.gameObject.SetActive (true);
			ニヤニヤ.gameObject.SetActive (true);
			効果線.gameObject.SetActive (true);
			break;
		case CharaFaceType.OLD_MAN:
			眉毛普通.gameObject.SetActive (true);
			口ひげ開き.gameObject.SetActive (true);
			目普通.gameObject.SetActive (true);
			break;
		}
	}

	void HiddenFaceImages(){
		口ひげ開き.gameObject.SetActive (false);
		口ひげ閉じ.gameObject.SetActive (false);
		眉毛普通.gameObject.SetActive (false);
		眉毛怒り.gameObject.SetActive (false);
		悲しみ.gameObject.SetActive (false);
		怒り.gameObject.SetActive (false);
		ニヤニヤ.gameObject.SetActive (false);
		目普通.gameObject.SetActive (false);
		口開く.gameObject.SetActive (false);
		口よだれ.gameObject.SetActive (false);
		口への字.gameObject.SetActive (false);
		効果線.gameObject.SetActive (false);
	}
	void Awake(){
		HiddenFaceImages ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
