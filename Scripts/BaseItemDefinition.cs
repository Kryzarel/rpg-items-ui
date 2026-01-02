using UnityEngine;

namespace Kryz.RPG.Items.UI
{
	public abstract class BaseItemDefinition : ScriptableObject, IItemDefinition
	{
		[field: SerializeField]
		public Sprite? Icon { get; private set; }
		[field: SerializeField]
		public string Name { get; private set; } = string.Empty;
		[field: SerializeField, TextArea]
		public string Description { get; private set; } = string.Empty;
		[field: SerializeField]
		public int MaxStacks { get; private set; } = 1;

		private void OnValidate()
		{
			if (MaxStacks <= 0) MaxStacks = int.MaxValue;
		}

		public IItem CreateWith(IItemFactory factory) => factory.GetOrCreate(this);
	}
}