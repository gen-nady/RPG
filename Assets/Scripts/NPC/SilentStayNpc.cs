using System;
using UnityEngine;
using Helper;

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