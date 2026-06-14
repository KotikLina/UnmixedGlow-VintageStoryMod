using HarmonyLib;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace UnmixedGlow
{
    public class UnmixedGlowModSystem : ModSystem
    {
        private static Harmony harmonyInstance;
        private const string HarmonyId = "configurablehandheldlightlevels.mainpatch";

        public override bool ShouldLoad(EnumAppSide side)
        {
            return side == EnumAppSide.Client;
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            base.StartClientSide(api);

            if (harmonyInstance == null)
            {
                harmonyInstance = new Harmony(HarmonyId);

                var originalGetter = AccessTools.PropertyGetter(typeof(EntityPlayer), nameof(EntityPlayer.LightHsv));
                var postfixMethod = new HarmonyMethod(typeof(EntityPlayerLightPatch), nameof(EntityPlayerLightPatch.Postfix));

                harmonyInstance.Patch(originalGetter, postfix: postfixMethod);
                api.Logger.Notification("[SingleLightSource] Полный патч LightHsv (все слоты носки + руки) успешно запущен!");
            }
        }

        public override void Dispose()
        {
            if (harmonyInstance != null)
            {
                harmonyInstance.UnpatchAll(HarmonyId);
                harmonyInstance = null;
            }
            base.Dispose();
        }
    }

    public static class EntityPlayerLightPatch
    {
        public static void Postfix(EntityPlayer __instance, ref byte[] __result)
        {
            IPlayer player = __instance?.Player;
            if (player == null) return;

            byte[] absoluteBestLight = null;
            byte maxBrightnessFound = 0;

            EvaluateSlotLight(__instance.RightHandItemSlot, ref absoluteBestLight, ref maxBrightnessFound);
            EvaluateSlotLight(__instance.LeftHandItemSlot, ref absoluteBestLight, ref maxBrightnessFound);

            if (player.InventoryManager != null)
            {
                string characterInvId = "character-" + player.PlayerUID;
                IInventory gearInv = player.InventoryManager.GetInventory(characterInvId);

                if (gearInv != null)
                {
                    foreach (var slot in gearInv)
                    {
                        EvaluateSlotLight(slot, ref absoluteBestLight, ref maxBrightnessFound);
                    }
                }
            }

            if (absoluteBestLight != null)
            {
                __result = absoluteBestLight;
            }
            else
            {
                __result = null;
            }
        }

        private static void EvaluateSlotLight(ItemSlot slot, ref byte[] bestLight, ref byte maxBrightness)
        {
            if (slot == null || slot.Empty || slot.Itemstack == null) return;

            if (slot.Itemstack.Class == EnumItemClass.Block && slot.Itemstack.Block == null) return;
            if (slot.Itemstack.Class == EnumItemClass.Item && slot.Itemstack.Item == null) return;

            byte[] itemHsv = slot.Itemstack.Class == EnumItemClass.Block
                ? slot.Itemstack.Block.LightHsv
                : slot.Itemstack.Item.LightHsv;

            if (itemHsv != null && itemHsv.Length >= 3 && itemHsv[2] > maxBrightness)
            {
                maxBrightness = itemHsv[2];
                bestLight = itemHsv;
            }
        }
    }
}
