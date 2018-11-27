using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
[CreateAssetMenu(fileName ="New Burger", menuName= "Burger")]

public class Hampurilanen : ScriptableObject {

	public string name;
	public Sprite Image;
	public int layers;
	public List<int> Ingredients;
}
