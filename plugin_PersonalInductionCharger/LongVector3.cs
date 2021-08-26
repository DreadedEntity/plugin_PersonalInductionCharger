using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Obsolete]
class LongVector3 {
	public long X { get; set; }
	public long Y { get; set; }
	public long Z { get; set; }

	public LongVector3(long x, long y, long z) {
		X = x;
		Y = y;
		Z = z;
	}
	public LongVector3(Player player) {
		X = player.mnWorldX;
		Y = player.mnWorldY;
		Z = player.mnWorldZ;
	}
	public LongVector3(SegmentEntity segmentEntity) {
		X = segmentEntity.mnX;
		Y = segmentEntity.mnY;
		Z = segmentEntity.mnZ;
	}

	public double CaclulateDistance(LongVector3 p2) {
		double g1 = p2.X - X;
		double g2 = p2.Y - Y;
		double g3 = p2.Z - Z;

		return Math.Sqrt((g1*g1)+(g2*g2)+(g3*g3));
	}

	public override string ToString() {
		return $"{X}, {Y}, {Z}";
	}
	public string ToStringLong() {
		var builder = new StringBuilder();
		builder.AppendLine(X.ToString());
		builder.AppendLine(Y.ToString());
		builder.AppendLine(Z.ToString());
		return builder.ToString();
	}
}