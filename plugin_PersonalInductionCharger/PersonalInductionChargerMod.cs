using UnityEngine;

public class PersonalInductionChargerMod : FortressCraftMod
{
	public static string ModName = "Personal Induction Charger";
	public static string ModID = "DreadedEntity.PersonalInductionCharger";

	public override ModRegistrationData Register()
	{
		var modRegistrationData = new ModRegistrationData();
		modRegistrationData.RegisterEntityHandler(ModID);

		Debug.Log("PIC: Registered");
		return modRegistrationData;
	}

	//public override ModCreateSegmentEntityResults CreateSegmentEntity(ModCreateSegmentEntityParameters parameters) {
	public override void CreateSegmentEntity(ModCreateSegmentEntityParameters parameters, ModCreateSegmentEntityResults results) {
		Debug.Log("CSE Personal Induction Charger");
		base.CreateSegmentEntity(parameters, results);
		//var result = new ModCreateSegmentEntityResults();
		parameters.ObjectType = SpawnableObjectEnum.Conveyor;
		results.Entity = new PersonalInductionCharger(parameters.Segment, parameters.X, parameters.Y, parameters.Z, parameters.Cube, parameters.Flags, parameters.Value);
		//return result;
		//return base.CreateSegmentEntity(parameters);
	}

	public void IDEK()
	{
		//SurvivalPowerPanel.Heal(lrTime, lrBoost);
		//public static void GivePower(float lrPower)
	}
}