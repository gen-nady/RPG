using Helper;

namespace NPC
{
    public class SilentStayNpc : NPC
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