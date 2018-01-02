using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Create level", order = 1)]
public class Level : ScriptableObject {
	public int index;
	public string code;
	public string levelName;
}