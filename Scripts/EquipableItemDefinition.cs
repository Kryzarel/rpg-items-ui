using UnityEngine;

namespace Kryz.RPG.Items.UI
{
	[CreateAssetMenu(fileName = nameof(EquipableItemDefinition), menuName = "Kryz/RPG Items Example/" + nameof(EquipableItemDefinition))]
	public class EquipableItemDefinition : BaseItemDefinition
	{
		[SerializeField]
		private (string, float)[] statBonuses;
	}
}