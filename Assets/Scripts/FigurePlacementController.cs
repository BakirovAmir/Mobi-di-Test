using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigurePlacementController : MonoBehaviour
{
	[SerializeField]
	private Camera myCamera;

	private Figure usingFigure;

	private Transform usingFigureTransform;

	private Transform usingFigureTransformVirtual;
	private Transform[] usingFigureCellTransformsVirtual;

	private bool figureSettedOnDesk = false;

	private Vector3 fromFigureTohead;

	private Vector3 up = Vector3.up;

	void Update()
	{
		UpdateUsingFigure();

		RaycastHit hit;
		Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit))
		{
			if (hit.collider.name.Equals("FieldCellCollider"))
			{
				GameFieldCellComponent gameFieldCellComponent = hit.collider.transform.parent.GetComponent<GameFieldCellComponent>();

				if (gameFieldCellComponent != null)
				{
					SetFigureOnCell(gameFieldCellComponent, usingFigureTransformVirtual);

					var gameFieldCellsComponentsUnderFigureVirtual = GetGameFieldUnderFigure(usingFigureCellTransformsVirtual);

					if (gameFieldCellsComponentsUnderFigureVirtual != null && IsFreeSpace(gameFieldCellsComponentsUnderFigureVirtual))
					{
						SetFigureOnCell(gameFieldCellComponent, usingFigureTransform);

						figureSettedOnDesk = true;
					}

					if (figureSettedOnDesk && Input.GetKeyDown(KeyCode.Mouse0))
					{
						var gameFieldCellsComponentTransforms = GetFicureCellTransforms();
						var gameFieldCellsComponentsUnderFigure = GetGameFieldUnderFigure(gameFieldCellsComponentTransforms);
						LockGameFieldUnderFigure(gameFieldCellsComponentsUnderFigure);
						LoseFigure();
					}
				}
			}
		}
	}

	private void SetFigureOnCell(GameFieldCellComponent gameFieldCellComponent, Transform usingFigureTransform)
	{
		usingFigureTransform.position = gameFieldCellComponent.transform.position + up * 0.5f - fromFigureTohead;
	}

	private bool IsFreeSpace(List<GameFieldCellComponent> gameFieldCellsComponentsUnderFigure)
	{
		for (int i = 0; i < gameFieldCellsComponentsUnderFigure.Count; i++)
		{
			if (gameFieldCellsComponentsUnderFigure[i].gameFieldCell.locked)
			{
				return false;
			}
		}

		return true;
	}

	private Transform[] GetFicureCellTransforms()
	{
		Transform[] ficureCellTransforms = new Transform[usingFigure.figureCells.Length];

		for (int i = 0; i < ficureCellTransforms.Length; i++)
		{
			ficureCellTransforms[i] = usingFigure.figureCells[i].figureCellComponent.transform;
		}

		return ficureCellTransforms;
	}

	private List<GameFieldCellComponent> GetGameFieldUnderFigure(Transform[] points)
	{
		List<GameFieldCellComponent> gameFieldCellComponentList = new List<GameFieldCellComponent>();

		for (int i = 0; i < points.Length; i++)
		{
			RaycastHit hit;
			Ray ray = new Ray(points[i].position, -up);

			if (Physics.Raycast(ray, out hit))
			{
				gameFieldCellComponentList.Add(hit.collider.transform.parent.GetComponent<GameFieldCellComponent>());
			}
			else
			{
				return null;
			}
		}

		return gameFieldCellComponentList;
	}

	private void LockGameFieldUnderFigure(List<GameFieldCellComponent> gameFieldCellsComponentsUnderFigure)
	{
		if (gameFieldCellsComponentsUnderFigure == null)
		{
			return;
		}

		for (int i = 0; i < gameFieldCellsComponentsUnderFigure.Count; i++)
		{
			gameFieldCellsComponentsUnderFigure[i].gameFieldCell.locked = true;
		}
	}

	private void LoseFigure()
	{
		usingFigure = null;

		Destroy(usingFigureTransformVirtual.gameObject);
	}

	private void UpdateUsingFigure()
	{
		if (usingFigure == null)
		{
			usingFigure = FigureGetterManager.Instance.GetRandomFigure();
			var usingFigureHeadTransform = usingFigure.headCell.figureCellComponent.transform;
			usingFigureTransform = usingFigureHeadTransform.parent;

			fromFigureTohead = usingFigureHeadTransform.position - usingFigureTransform.position;

			usingFigureTransformVirtual = new GameObject().transform;
			usingFigureTransformVirtual.position = usingFigureTransform.position;

			usingFigureCellTransformsVirtual = new Transform[usingFigure.figureCells.Length];
			for (int i = 0; i < usingFigure.figureCells.Length; i++)
			{
				usingFigureCellTransformsVirtual[i] = new GameObject().transform;
				usingFigureCellTransformsVirtual[i].position = usingFigure.figureCells[i].figureCellComponent.transform.position;
				usingFigureCellTransformsVirtual[i].SetParent(usingFigureTransformVirtual);
			}

			figureSettedOnDesk = false;
		}
	}
}
