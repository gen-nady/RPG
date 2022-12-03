using UnityEngine;

namespace Helper
{
    public class DialogSpeak : ISpeakble
    {
        private string _speakDialog = "Its a Gesha";
        public void Speak()
        {
            Debug.Log(_speakDialog);
        }
    }
}