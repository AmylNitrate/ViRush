using UnityEngine;
using System.Collections.Generic;

public class WMG_X_Tutorial_1 : MonoBehaviour {


	public GameObject emptyGraphPrefab;

	public WMG_Axis_Graph graph;

	public WMG_Series series1, series2, series3, series4;

	//public List<Vector2> series1Data, series2Data, series3Data, series4Data;
	//public bool useData2;
	//public List<string> series1Data2, series2Data2, series3Data2, series4Data2;

	// Use this for initialization
	void Start () 
	{
		GameObject graphGO = GameObject.Instantiate(emptyGraphPrefab);
		graphGO.transform.SetParent(this.transform, false);
		graph = graphGO.GetComponent<WMG_Axis_Graph>();
		graph.legend.legendType = WMG_Legend.legendTypes.Right;


		series1 = graph.addSeries();
		series2 = graph.addSeries ();
		series3 = graph.addSeries ();
		series4 = graph.addSeries ();

		graph.xAxis.AxisMaxValue = 5;

//		if (useData2) 
//		{
//			List<string> groups = new List<string>();
//			List<Vector2> data = new List<Vector2>();
//			for (int i = 0; i < series1Data2.Count; i++) 
//			{
//				string[] row = series1Data2[i].Split(',');
//				groups.Add(row[0]);
//				if (!string.IsNullOrEmpty(row[1])) 
//				{
//					float y = float.Parse(row[1]);
//					data.Add(new Vector2(i+1, y));
//				}
//			}
//
//			graph.groups.SetList(groups);
//			graph.useGroups = true;
//
//			graph.xAxis.LabelType = WMG_Axis.labelTypes.groups;
//			graph.xAxis.AxisNumTicks = groups.Count;
//
//			series1.seriesName = "Orange Virus";
//
//			series1.UseXDistBetweenToSpace = true;
//
//			series1.pointValues.SetList(data);
//		}
//		else 
//		{
		series1.seriesName = "Orange Virus";
		series2.seriesName = "Blue Virus";
		series3.seriesName = "Green Virus";
		series4.seriesName = "Pink Virus";

		series1.lineColor = Color.yellow;
		series2.lineColor = Color.blue;
		series3.lineColor = Color.green;
		series4.lineColor = Color.red;

		series1.pointValues.SetList(Data.control.series1Data);
		series2.pointValues.SetList(Data.control.series2Data);
		series3.pointValues.SetList(Data.control.series3Data);
		series4.pointValues.SetList(Data.control.series4Data);
//		}
	}



}
