using System;
using UnityEngine;

namespace Kryz.RPG.Items.UI
{
	[CreateAssetMenu(fileName = nameof(EquipableItemDefinition), menuName = "Kryz/RPG Items UI/" + nameof(EquipableItemDefinition))]
	public class EquipableItemDefinition : BaseItemDefinition
	{
		[Space]
		[SerializeField]
		private float[] statBonuses = Array.Empty<float>();
	}
}