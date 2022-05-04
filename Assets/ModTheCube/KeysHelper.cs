using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.ModTheCube
{
    /// <summary>
    /// from https://forum.unity.com/threads/find-out-which-key-was-pressed.385250/
    /// </summary>
    public static class KeysHelper
    {
        
        static readonly KeyCode[] _keyCodes =
            System.Enum.GetValues(typeof(KeyCode))
                .Cast<KeyCode>()
                .Where(k => k < KeyCode.Mouse0)
                .ToArray();

        /// <summary>
        /// Get information about interesting keys pressed
        /// </summary>
        /// <param name="interestingCodes"></param>
        /// <returns>True if any of provided keys is down</returns>
        public static bool IsAnyKeyDown(params KeyCode[] interestingCodes)
        {
            return Enumerable.Intersect(GetCurrentKeys(), interestingCodes).Any();
        }

        /// <summary>
        /// Get information about interesting keys pressed
        /// </summary>
        /// <param name="interestingCodes">Interesting key codes</param>
        /// <returns>True if all of provided keys is down</returns>
        public static bool IsAllKeyDown(params KeyCode[] interestingCodes)
        {
            return Enumerable.SequenceEqual(GetCurrentKeys(), interestingCodes);
        }

        /// <summary>
        /// Get current keys pressed on keyboard including special keys like <see cref="KeyCode.LeftControl"/>
        /// </summary>
        /// <returns>Iterator with pressed keys. If nothing is pressed, empty iterator is returned</returns>
        /// <remarks>Be careful with FirstOrDefault. It will return KeyCode.None if nothing is pressed because of its implementation</remarks>
        public static IEnumerable<KeyCode> GetCurrentKeys()
        {
            if (Input.anyKeyDown)
            {
                for (int i = 0; i < _keyCodes.Length; i++)
                    if (Input.GetKey(_keyCodes[i]))
                        yield return _keyCodes[i];
            }
        }

        /// <summary>
        /// Get current keys of interest pressed on keyboard including special keys like <see cref="KeyCode.LeftControl"/>
        /// </summary>
        /// <returns>Iterator with pressed keys. If nothing is pressed, empty iterator is returned</returns>
        /// <remarks>Be careful with FirstOrDefault. It will return KeyCode.None if nothing is pressed because of its implementation</remarks>
        public static IEnumerable<KeyCode> GetCurrentInterestedKeys(KeyCode[] interestingCodes)
        {
            if (Input.anyKey)
            {
                for (int i = 0; i < interestingCodes.Length; i++)
                    if (Input.GetKey(interestingCodes[i]))
                        yield return interestingCodes[i];
            }
        }

        /// <summary>
        /// Get current keys unpressed on keyboard including special keys like <see cref="KeyCode.LeftControl"/>
        /// </summary>
        /// <returns>Iterator with unpressed keys. If nothing is pressed, empty iterator is returned</returns>
        /// <remarks>Be careful with FirstOrDefault. It will return KeyCode.None if nothing is pressed because of its implementation</remarks>
        public static IEnumerable<KeyCode> GetCurrentKeysUp()
        {
            for (int i = 0; i < _keyCodes.Length; i++)
                if (Input.GetKeyUp(_keyCodes[i]))
                    yield return _keyCodes[i];
        }
    }
}