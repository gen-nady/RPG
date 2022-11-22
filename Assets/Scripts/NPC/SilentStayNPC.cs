using System;
using TMPro.EditorUtilities;
using UnityEngine;

namespace NPC
{
    public class SilentStayNPC : NPC
    {
        private void Awake()
        {
            InitNPC();
        }

        protected override void InitNPC()
        {
            _speakble = new NoSpeakNPC();
        }
    }
}