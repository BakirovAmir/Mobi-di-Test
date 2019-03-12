using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldBuilder
{

	public GameField BuildGameField(int fieldSizeX, int fieldSizeY, GameObject fieldCellPrefab)
	{
		GameField gameField = new GameField();

		GameFieldCell[,] gameFieldCells = new GameFieldCell[fieldSizeX, fieldSizeY];

		GameObject gameFieldParent = new GameObject();
		gameFieldParent.name = "GameFieldParent";

		for (int i = 0; i < fieldSizeX; i++)
		{
			for (int j = 0; j < fieldSizeY; j++)
			{
				GameFieldCell gameFieldCell = new GameFieldCell(i, j);

				GameObject go = GameObject.Instantiate(fieldCellPrefab);
				go.transform.SetParent(gameFieldParent.transform);

				GameFieldCellComponent gameFieldCellComponent = go.GetComponent<GameFieldCellComponent>();
				gameFieldCellComponent.InitConnection(gameFieldCell);
				gameFieldCellComponent.MoveToCurrentPosition();

				gameFieldCells[i, j] = gameFieldCell;
			}
		}

		gameField.gameFieldCells = gameFieldCells;
		return gameField;
	}
}
