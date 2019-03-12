using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureCellComponent : MonoBehaviour
{
	public FigureCell figureCell;

	public void InitConnection(FigureCell figureCell)
	{
		this.figureCell = figureCell;

		figureCell.figureCellComponent = this;
	}
}
