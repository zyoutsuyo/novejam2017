using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;
using System;

public class StoryWindw : MonoBehaviour {

	string[] scenarios{
		get{
			return mMasterStoryData.Select (s => s.text).ToArray ();
		}
	}
	[SerializeField] Text uiText;
	[SerializeField]
	Image mBackImage;

	[SerializeField][Range(0.001f, 0.3f)]
	float intervalForCharacterDisplay = 0.05f;

	private string currentText = string.Empty;
	private float timeUntilDisplay = 0;
	private float timeElapsed = 1;
	private int currentLine = 0;
	private int lastUpdateCharacter = -1;

	Action mClosedCallBack;
	public void SetEndCallBack(Action callBack){
		mEndCallBack = callBack;
	}
	Action mEndCallBack;

	[SerializeField]
	Button mButton;
	List<StoryModel> mMasterStoryData = new List<StoryModel> ();

	public void Init(List<StoryModel> masterStoryData,Action closedCallBack){
		mMasterStoryData = masterStoryData;
		mClosedCallBack = closedCallBack;
	}

	// 文字の表示が完了しているかどうか
	public bool IsCompleteDisplayText 
	{
		get { return  Time.time > timeElapsed + timeUntilDisplay; }
	}

	void Start()
	{
		
		//test!!!!!!! あとで消す
		//mMasterStoryData = GameManager.Instance.MasterStoryData;
		SoundManager.Instance.PlaySe(5);
		SetNextLine();
		mButton.onClick.AddListener(()=>{
			if(mEndLine){
					if(mMasterStoryData.Count <= currentLine){
						if(!mOnClose){
							Close();
						}
					}else{
						SetNextLine();
					}

				}else{
					timeUntilDisplay = 0;
				}
			
		});
		var rect = mBackImage.GetComponent<RectTransform> ();
		rect.localScale = Vector3.zero;
		rect.DOScale(
			new Vector3(1f, 1f),     // 終了時点のScale
			0.5f                            // アニメーション時間
		).SetEase(Ease.InOutCirc);

	}
	bool mOnClose = false;
	void Close(){
		SoundManager.Instance.PlaySe(6);
		mOnClose = true;
		var rect = mBackImage.GetComponent<RectTransform> ();
		rect.DOScale(
			new Vector3(0, 0),     // 終了時点のScale
			0.5f                            // アニメーション時間
		) .OnComplete(() => {
			Destroy(this.gameObject);
		}).SetEase(Ease.InOutCirc);
		if (mClosedCallBack != null) {
			mClosedCallBack ();
		}
		if (mEndCallBack != null) {
			mEndCallBack ();
		}
	}

	public bool mEndLine = false;

	void Update () 
	{
		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
		if( displayCharacterCount != lastUpdateCharacter ){
			uiText.text = currentText.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		}
		if (displayCharacterCount >= currentText.Length) {
			mEndLine = true;
		}
	}


	void SetNextLine()
	{
		SoundManager.Instance.PlaySe(7);
		mEndLine = false;
		currentText = scenarios[currentLine];
		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
		timeElapsed = Time.time;
		currentLine ++;
		lastUpdateCharacter = -1;
	}

}
