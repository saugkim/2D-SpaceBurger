using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Uusi aines", menuName= "Ingredient")]
public class AinesOsa : ScriptableObject {

	public string name;
	public int AinesID;
	public Sprite Kuva;
}
