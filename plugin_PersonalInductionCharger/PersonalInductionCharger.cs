using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class PersonalInductionCharger : MachineEntity {
	public bool PlayerNearby { get; set; }
	public bool LowFreqencyUpdate { get; set; }
	public bool LowerFrequencyUpdate { get; set; }
	public int LowFrequencyIterator { get; set; }

	public PersonalInductionCharger(Segment segment, long x, long y, long z, ushort cube, byte flags, ushort lValue) : base(eSegmentEntity.Mod, SpawnableObjectEnum.PowerStorageBlock, x, y, z, cube, flags, lValue, Vector3.zero, segment) {
		this.mbNeedsLowFrequencyUpdate = true;
		PlayerNearby = false;
		LowFrequencyIterator = 0;
	}

	public override void LowFrequencyUpdate() {
		//Only update every 5th update, uses short-circuiting
		if (!LowerFrequencyUpdate && LowFrequencyIterator % 5 == 0) {
			double playerDistance = WorldScript.mLocalPlayer.GetLongVector3().Distance(this.GetLongVector3());
			PlayerNearby = false;
			if (playerDistance > 30) {
				LowerFrequencyUpdate = true;
			} else if (playerDistance > 1) {
				LowerFrequencyUpdate = false;
			} else {
				PlayerNearby = true;
			}
		}
		if (LowFrequencyIterator % 25 == 0 && LowerFrequencyUpdate) {
			double playerDistance = WorldScript.mLocalPlayer.GetLongVector3().Distance(this.GetLongVector3());
			if (playerDistance < 30)
				LowerFrequencyUpdate = false;
		}
		LowFrequencyIterator++;
		if (LowFrequencyIterator == Int32.MaxValue)
			LowFrequencyIterator = 0;
	}

	public void Update() {
		if (PlayerNearby) {
			//TODO give player energy
		}
	}

	public override string GetPopupText() {
		var builder = new StringBuilder();
		var player = WorldScript.mLocalPlayer;
		//builder.AppendLine($"Player X:{player.mnWorldX}");
		//builder.AppendLine($"Player Y:{player.mnWorldY}");
		//builder.AppendLine($"Player Z:{player.mnWorldZ}");
		//builder.AppendLine($"Block X:{this.mnX}");
		//builder.AppendLine($"Block Y:{this.mnY}");
		//builder.AppendLine($"Block Z:{this.mnZ}");
		//builder.AppendLine(Vector3.Distance(player.GetVector3(), this.GetVector3()).ToString());

		//subtract world offset before doing math(!!)
		var playerPoint = player.GetLongVector3();
		var blockPoint = this.GetLongVector3();
		builder.Append(playerPoint.Distance(blockPoint));
		return builder.ToString();
	}
}