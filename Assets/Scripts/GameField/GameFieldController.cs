using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldController : MonoBehaviour
{
	[SerializeField]
	private GameObject gameFieldCellPrefab;
	[SerializeField]
	private int width = 5;
	[SerializeField]
	private int height = 3;

	private GameField gameField;

	void Start()
	{
		GameFieldBuilder gameFieldBuilder = new GameFieldBuilder();
		gameField = gameFieldBuilder.BuildGameField(width, height, gameFieldCellPrefab);
	}
}
