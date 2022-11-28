using System;
using UnityEngine;

namespace NPC
{
    public class SilentStayNpc : NPCObject
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