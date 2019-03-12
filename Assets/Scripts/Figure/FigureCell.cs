using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureCell 
{
	public FigureCellComponent figureCellComponent;
	public Point point;

	public bool onDesk = false;

	public FigureCell(int x, int y)
	{
		point.x = x;
		point.y = y;
	}
}
