using System;
using Kryz.RPG.Items.Views;
using UnityEngine;

namespace Kryz.RPG.Items.UI
{
	public class Initializer : MonoBehaviour
	{
		private readonly ItemFactory itemFactory = new();
		private readonly Inventory inventory = new(12);

		[SerializeField]
		private InventoryView? inventoryView;
		[SerializeField]
		private BaseItemDefinition[] itemDefinitions = Array.Empty<BaseItemDefinition>();
		[SerializeField]
		private int[] itemCounts = Array.Empty<int>();

		private void OnValidate()
		{
			Array.Resize(ref itemCounts, itemDefinitions.Length);
			for (int i = 0; i < itemCounts.Length; i++)
			{
				ref int count = ref itemCounts[i];
				if (count <= 0) count = 1;
			}
		}

		private void Awake()
		{
			itemFactory.Register(new CurrencyItemCreator());
			itemFactory.Register(new EquipableItemCreator());
		}

		private void Start()
		{
			inventoryView!.SetInventory(inventory);

			for (int i = 0; i < itemDefinitions.Length; i++)
			{
				inventory.TrySet(i, new ItemStack(itemDefinitions[i].CreateWith(itemFactory), itemCounts[i]));
			}
		}
	}
}