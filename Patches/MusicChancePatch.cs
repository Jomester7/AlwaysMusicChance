using HarmonyLib;
using UnityEngine;

namespace AlwaysMusicChance.Patches
{
    class MusicChancePatch
    {
        [HarmonyPatch(typeof(WakeGel), nameof(WakeGel.Spawned))]
        [HarmonyPostfix]
        static void Spec2Patch(WakeGel __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.music);
        }

        [HarmonyPatch(typeof(Spec3Controller), nameof(Spec3Controller.Spawned))]
        [HarmonyPostfix]
        static void Spec3Patch(Spec3Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.specMusic);
        }

        [HarmonyPatch(typeof(Spec4Controller), nameof(Spec4Controller.Spawned))]
        [HarmonyPostfix]
        static void Spec4Patch(Spec4Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.music);
        }

        [HarmonyPatch(typeof(EMSpec4Controller), nameof(EMSpec4Controller.Spawned))]
        [HarmonyPostfix]
        static void EMSpec4Patch(EMSpec4Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.music);
        }

        [HarmonyPatch(typeof(Spec5Controller), nameof(Spec5Controller.Spawned))]
        [HarmonyPostfix]
        static void Spec5Patch(Spec5Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.music);
        }

        [HarmonyPatch(typeof(Spec6Controller), nameof(Spec6Controller.Spawned))]
        [HarmonyPostfix]
        static void Spec6Patch(Spec6Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.music);
        }

        //spec 7 track always plays

        [HarmonyPatch(typeof(Spec8Controller), nameof(Spec8Controller.Spawned))]
        [HarmonyPostfix]
        static void Spec8Patch(Spec8Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.music);
        }

        //spec 9 track always plays

        [HarmonyPatch(typeof(Spec10Controller), nameof(Spec10Controller.Spawned))]
        [HarmonyPostfix]
        static void Spec10Patch(Spec10Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.music);
        }

        [HarmonyPatch(typeof(Spec11Controller), nameof(Spec11Controller.Spawned))]
        [HarmonyPostfix]
        static void Spec11Patch(Spec11Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.music);
        }

        //12 is weird. keep searching for his EM stuff

        [HarmonyPatch(typeof(Spec13Controller), nameof(Spec13Controller.Spawned))]
        [HarmonyPostfix]
        static void Spec13Patch(Spec13Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.music);
        }

        //unknown spec 1 track always plays (white face my beloved <3)

        [HarmonyPatch(typeof(UnknownSpecimen2Controller), nameof(UnknownSpecimen2Controller.Spawned))]
        [HarmonyPostfix]
        static void UnknownSpec2Patch(UnknownSpecimen2Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.music);
        }

        [HarmonyPatch(typeof(UnknownSpecimen3Controller), nameof(UnknownSpecimen3Controller.Spawned))]
        [HarmonyPostfix]
        static void UnknownSpec3Patch(UnknownSpecimen3Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.music);
        }

        [HarmonyPatch(typeof(UnknownSpecimen4Controller), nameof(UnknownSpecimen4Controller.Spawned))]
        [HarmonyPostfix]
        static void UnknownSpec4Patch(UnknownSpecimen4Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.music);
        }

        //unknown spec 5 track always plays

        [HarmonyPatch(typeof(EMKHMonster4Controller), nameof(EMKHMonster4Controller.Spawned))]
        [HarmonyPostfix]
        static void Monster4Patch(EMKHMonster4Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.chaseMusic);
        }

        //monster 5 track always plays

        [HarmonyPatch(typeof(EMKHMonster6Controller), nameof(EMKHMonster6Controller.Spawned))]
        [HarmonyPostfix]
        static void Monster6Patch(EMKHMonster6Controller __instance)
        {
            EnsureTrack(__instance.gameObject, __instance.music);
        }

        //[HarmonyPatch(typeof(GameManager), "Update")]
        //[HarmonyPostfix]
        //static void DebugStuff()
        //{
        //    //force spawn specific specimen
        //    if (Input.GetKeyDown(KeyCode.Alpha2))
        //    {
        //        MusicChancePlugin.Logger.LogInfo("Forcefully spawning new specimen");
        //        ServiceLocator.GetService<SpecimenManager>().StartSpecimen("EMHookedDoll", false);
        //    }
        //}

        /// <summary>
        /// Ensures the track plays if it is not currently playing.
        /// </summary>
        /// <param name="spec">The specimen's GameObject.</param>
        /// <param name="track">The audio clip that should be playing.</param>
        static void EnsureTrack(GameObject spec, AudioClip track)
        {
            if (ServiceLocator.GetService<AmbientSoundsController>().npcMusics.ContainsValue(track))
            {
                MusicChancePlugin.Logger.LogInfo("Track was intended to play - doing nothing");
                return;
            }

            MusicChancePlugin.Logger.LogInfo("Track was intended to skip - forced it to play");
            ServiceLocator.GetService<AmbientSoundsController>().PlayNpcMusic(spec, track);
        }
    }
}
