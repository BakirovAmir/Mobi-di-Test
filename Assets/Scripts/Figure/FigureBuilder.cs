using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureBuilder
{
	public Figure BuildFigure(FigureCellComponent[] figureCellComponents)
	{
		FigureCell[] figureCells = new FigureCell[figureCellComponents.Length];
		FigureCell headCell = null;

		for (int i = 0; i < figureCells.Length; i++)
		{
			FigureCell figureCell = new FigureCell(0, 0);

			figureCells[i] = figureCell;
			figureCellComponents[i].InitConnection(figureCell);

			if (i == 0)
			{
				headCell = figureCell;
			}
		}

		Figure figure = new Figure(figureCells, headCell);
		return figure;
	}
}