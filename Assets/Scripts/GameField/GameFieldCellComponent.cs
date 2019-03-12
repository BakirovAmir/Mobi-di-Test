using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldCellComponent : MonoBehaviour
{
	public GameFieldCell gameFieldCell;

	public void InitConnection(GameFieldCell gameFieldCell)
	{
		this.gameFieldCell = gameFieldCell;

		gameFieldCell.gameFieldCellComponent = this;
	}

	public void MoveToCurrentPosition()
	{
		transform.localPosition = new Vector3(gameFieldCell.point.x, 0, gameFieldCell.point.y);
	}
}
