using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;


/// <summary>
/// MapのJson変換補助クラス
/// </summary>
public static class MapJsonHelper
{

	public static string GetWrapJson(string json){
		json = "{\"MapCellModel\":" + json + "}";
		return json;
	}

	public static T[] FromJson<T>(string json)
	{
		Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.MapCellModel;
	}

	[Serializable]
	private class Wrapper<T>
	{
		public T[] MapCellModel;
	}
}

/// <summary>
/// ItemのJson変換補助クラス
/// </summary>
public static class ItemJsonHelper
{

	public static string GetWrapJson(string json){
		json = "{\"ItemModel\":" + json + "}";
		return json;
	}

	public static T[] FromJson<T>(string json)
	{
		Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.ItemModel;
	}

	[Serializable]
	private class Wrapper<T>
	{
		public T[] ItemModel;
	}
}

/// <summary>
/// StoryのJson変換補助クラス
/// </summary>
public static class StoryJsonHelper
{

	public static string GetWrapJson(string json){
		json = "{\"StoryModel\":" + json + "}";
		return json;
	}

	public static T[] FromJson<T>(string json)
	{
		Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.StoryModel;
	}

	[Serializable]
	private class Wrapper<T>
	{
		public T[] StoryModel;
	}
}
