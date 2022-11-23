using System;
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