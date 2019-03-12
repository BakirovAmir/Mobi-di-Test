using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldCell
{
	public Point point;
	public bool locked;
	public GameFieldCellComponent gameFieldCellComponent;

	public GameFieldCell(int x, int y)
	{
		point.x = x;
		point.y = y;
	}
}
