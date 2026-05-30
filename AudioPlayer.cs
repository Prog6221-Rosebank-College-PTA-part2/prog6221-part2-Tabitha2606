using System;           
using System.Media;
using System.IO;

git commit -m "Integrated AudioPlayer class from Part 1 which contains the voice greeting"

namespace ST10483814_POE_PART_2
{

    public class AudioPlayer
    {
        // A access modifier is declared to ensure that methods are used internally in a class
        private string fullPath;

        // A construtor 
        public AudioPlayer()
        {

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;



            // Combines with the WAV filename and stores the file path into the class field
            this.fullPath = Path.Combine(baseDirectory, "voiceGreeting.wav");
        }

        public void PlayWav()
        {
            // Attempt to play the voice greeting
            try
            {
                if (!File.Exists(fullPath))
                {
                    System.Diagnostics.Debug.WriteLine("WAV file not found at: " + fullPath);
                    return;
                }


                using (SoundPlayer player = new SoundPlayer(fullPath))
                {
                    player.Load();
                    player.Play(); 
                }
            }
            // Catch any error that occurs while playing the WAV file
            catch (Exception error) 
            {
                System.Diagnostics.Debug.WriteLine("An error occured while playing the audio: " + error.Message);
            }
        }

    }
}
    

