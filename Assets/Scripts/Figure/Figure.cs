using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure
{
	public FigureCell[] figureCells;
	public FigureCell headCell;

	public Figure(FigureCell[] figureCells, FigureCell headCell)
	{
		this.figureCells = figureCells;
		this.headCell = headCell;
	}
}
