using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureGetterManager : MonoBehaviour
{
	public static FigureGetterManager Instance;

	public GameObject[] figurePrefabs;

	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(Instance.gameObject);
		}

		Instance = this;
	}

	public Figure GetRandomFigure()
	{
		FigureBuilder figureBuilder = new FigureBuilder();

		GameObject go = Instantiate(figurePrefabs[Random.Range(0, figurePrefabs.Length)]);

		FigureCellComponent[] figureCellComponents = go.GetComponentsInChildren<FigureCellComponent>();

		Figure figure = figureBuilder.BuildFigure(figureCellComponents);

		return figure;
	}
}
