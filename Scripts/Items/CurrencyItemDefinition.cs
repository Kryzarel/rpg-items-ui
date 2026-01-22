using System;
using UnityEngine;

namespace Kryz.RPG.Items.UI
{
	[CreateAssetMenu(fileName = nameof(CurrencyItemDefinition), menuName = "Kryz/RPG Items Example/" + nameof(CurrencyItemDefinition))]
	public class CurrencyItemDefinition : BaseItemDefinition, IItemDefinition
	{
		[field: SerializeField]
		public int MaxStacks { get; private set; }

		protected override void OnValidate()
		{
			base.OnValidate();
			if (MaxStacks < 0) MaxStacks = int.MaxValue;
		}
	}
}