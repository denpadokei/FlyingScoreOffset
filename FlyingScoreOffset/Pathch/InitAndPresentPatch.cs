using FlyingScoreOffset.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FlyingScoreOffset.Pathch
{
    [HarmonyPatch(typeof(FlyingObjectEffect), nameof(FlyingObjectEffect.InitAndPresent),
        new Type[] { typeof(float), typeof(Vector3), typeof(Quaternion), typeof(bool) })]
    public class InitAndPresentPatch
    {
        public static void Prefix(ref float duration, ref Vector3 targetPos, ref Quaternion rotation, ref bool shake)
        {
            var newPos = new Vector3(targetPos.x + PluginConfig.Instance.Offset.x, targetPos.y + PluginConfig.Instance.Offset.y, targetPos.z + PluginConfig.Instance.Offset.z);
            targetPos = newPos;
        }
    }
}
