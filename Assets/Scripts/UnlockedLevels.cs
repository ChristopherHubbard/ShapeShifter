using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    [Serializable]
    public static class UnlockedLevels
    {
        private static Dictionary<string, bool> unlocked = new Dictionary<string, bool>()
        {
            {"Level 1-1", true },
            {"Level 1-2", false },
            {"Level 1-3", false },
            {"Level 1-4", false },
            {"Level 1-5", false }
        };

        public static Dictionary<string, bool> Unlocked
        {
            get
            {
                return unlocked;
            }
            set
            {
                unlocked = value;
            }
        }
    }
}
