using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class UnityHelper {
	public static Vector3 GetLongVector3(this Player player) => new Vector3(player.mnWorldX, player.mnWorldY, player.mnWorldZ);
	public static Vector3 GetLongVector3(this SegmentEntity segmentEntity) => new Vector3(segmentEntity.mnX, segmentEntity.mnY, segmentEntity.mnZ);
	public static string GetCoords(this Vector3 v) => $"{v.x}, {v.y}, {v.z}";
	public static double Distance(this Vector3 v1, Vector3 v2) {
		double g1 = v2.x - v1.x;
		double g2 = v2.y - v1.y;
		double g3 = v2.z - v1.z;

		return Math.Sqrt((g1 * g1) + (g2 * g2) + (g3 * g3));
	}
}