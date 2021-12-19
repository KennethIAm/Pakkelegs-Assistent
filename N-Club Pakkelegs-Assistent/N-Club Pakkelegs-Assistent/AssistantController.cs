using System;
using System.Diagnostics;
using System.Media;
using System.Text.RegularExpressions;

namespace N_Club_Pakkelegs_Assistent
{
    class AssistantController
    {
        private string _data;
        private string _username;
        private int _gifts = 3000;
        private int _userGifts;
        private int _desiredPresents;
        private string _generalMessage = "";
        private DataManager _dManager = new DataManager();
        private SoundPlayer player;

        public int UserGifts
        {
            get { return _userGifts; }
        }

        public int DesiredGifts
        {
            get { return _desiredPresents; }
        }

        public string GeneralMessage
        {
            get { return _generalMessage; }
        }

        public AssistantController(string username, int desiredPresents)
        {
            _username = username;
            _desiredPresents = desiredPresents;
        }

        // Get the current data from N-Club
        private void UpdateData()
        {
            _data = _dManager.GetWebsiteData();
            TrimData();
        }

        // Remove all the irrelevant data
        private void TrimData()
        {
            int index;
            _data = _data.Replace("\t", "");

            while (!_data.Remove(100, _data.Length - 100).Contains("christmas_box"))
            {
                index = _data.IndexOf("<div class=" + '"' + "clear" + '"' + "></div>");
                _data = _data.Remove(0, index + 26);
            }

            index = _data.IndexOf("<h2>SÃ¥dan fungerer pakkelegen</h2>");
            _data = _data.Remove(index - 1, _data.Length - index - 1);
        }

        // Updates the console colour
        public void UpdateTextColour(int count)
        {

            if (count >= _desiredPresents)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (count <= _desiredPresents && count > -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (count == -1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
        }

        // Count the amount of times the element appears
        private int CountOccurrencesOfString(string text, string countElement)
        {
            int count = 0;

            foreach (Match m in Regex.Matches(text, countElement))
            {
                count++;
            }

            return count;
        }

        // Create a status message to be displayed in the console
        private string CreateStatusMessage(int count)
        {
            string timestamp = DateTime.Now.ToString("HH:mm");

            return "[" + timestamp + "]" + " " + _username + " har " + count + " ud af " + _gifts + " gaver";
        }

        // Count the number of gifts remaining
        private void GetNumberOfGifts()
        {
            int currentAmountOfGifts = CountOccurrencesOfString(_data, "christmas_box");

            if (_gifts == 3000)
            {
                _gifts = currentAmountOfGifts;
            }
            else if (currentAmountOfGifts != _gifts)
            {
                _generalMessage = "\n~~| Denne runde er nu slut |~~\n";
                _gifts = currentAmountOfGifts;
            }
        }

        // Plays an audio file
        public void NotifyUser(int soundValue)
        {
            switch (soundValue)
            {
                case 1:
                    player = new System.Media.SoundPlayer(@".\Sounds\Pay Attention.wav");
                    player.Play();
                    break;
                case 2:
                    player = new System.Media.SoundPlayer(@".\Sounds\Train Tune.wav");
                    player.Play();
                    break;
            }
            IconFlasher.FlashWindow(Process.GetCurrentProcess().MainWindowHandle);
        }

        // Clears _generalMessage
        public void ClearGeneralMessage()
        {
            _generalMessage = "";
        }

        // Update status and return a message to display
        public string GetCurrentStatus()
        {
            UpdateData();
            _userGifts = CountOccurrencesOfString(_data, _username);
            GetNumberOfGifts();
            UpdateTextColour(_userGifts);
            return CreateStatusMessage(_userGifts);
        }
    }
}
