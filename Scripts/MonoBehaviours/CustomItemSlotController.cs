using Kryz.RPG.Items.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Kryz.RPG.Items.UI
{
	public sealed class CustomItemSlotController : ItemSlotController
	{
		[SerializeField] InputActionReference? pickUpAction;
		[SerializeField] InputActionReference? cancelPickUpAction;

		private void Start()
		{
			if (cancelPickUpAction != null)
			{
				cancelPickUpAction.action.performed += ctx => EndDrag();
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (pickUpAction != null) pickUpAction.action.Enable();
			if (cancelPickUpAction != null) cancelPickUpAction.action.Disable();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (pickUpAction != null) pickUpAction.action.Disable();
			if (cancelPickUpAction != null) cancelPickUpAction.action.Disable();
		}

		protected override bool StartDrag(IItemSlotView slotView, int count)
		{
			if (base.StartDrag(slotView, count))
			{
				if (pickUpAction != null) pickUpAction.action.Enable();
				if (cancelPickUpAction != null) cancelPickUpAction.action.Enable();
				return true;
			}
			return false;
		}

		protected override void EndDrag()
		{
			base.EndDrag();
			if (pickUpAction != null) pickUpAction.action.Enable();
			if (cancelPickUpAction != null) cancelPickUpAction.action.Disable();
		}

		public override bool OnPointerClick(IItemSlotView itemSlotView, PointerEventData eventData)
		{
			if (HandleItemPickup(itemSlotView))
			{
				return true;
			}

			return base.OnPointerClick(itemSlotView, eventData);
		}

		private bool HandleItemPickup(IItemSlotView itemSlotView)
		{
			if (dragController == null || pickUpAction == null || !pickUpAction.action.WasPerformedThisFrame())
			{
				return false;
			}

			ItemStack dragBefore = dragController.CursorSlot?.ItemStack ?? default;
			ItemStack dropBefore = itemSlotView.ItemStack;

			if (TryDrop(itemSlotView))
			{
				ItemStack dragAfter = dragController.CursorSlot?.ItemStack ?? default;
				ItemStack dropAfter = itemSlotView.ItemStack;
				bool notEmpty = dragBefore != default && dragAfter != default;
				bool swapped = notEmpty && dragBefore == dropAfter && dropBefore == dragAfter;

				EndDrag();

				if (swapped)
				{
					StartDrag(itemSlotView, itemSlotView.ItemStack.Count);
				}
				return true;
			}

			return StartDrag(itemSlotView, itemSlotView.ItemStack.Count);
		}
	}
}