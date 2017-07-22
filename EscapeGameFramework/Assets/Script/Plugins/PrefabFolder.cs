using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabFolder {
	public static T InstantiateTo<T>(MonoBehaviour obj,Transform parent)where T : Component{
		var script = Object.Instantiate(obj).GetComponent<T>();
		//script.transform.parent = parent;
		script.transform.SetParent (parent);
		script.transform.localPosition = Vector3.zero;
		return script;
	}
	public static T InstantiateTo<T>(GameObject obj,Transform parent)where T : Component{
		var script = Object.Instantiate(obj).GetComponent<T>();
		//script.transform.parent = parent;
		script.transform.SetParent (parent);
		script.transform.localPosition = Vector3.zero;
		return script;
	}
}
