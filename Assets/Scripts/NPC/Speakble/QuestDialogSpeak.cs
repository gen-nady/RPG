using UnityEngine;

namespace NPC
{
    public class QuestDialogSpeak : ISpeakble
    {
        private string speakDialog = "Hi. Its Gesha"; 
        public void Speak()
        {
            Debug.Log(speakDialog);
        }
    }
}