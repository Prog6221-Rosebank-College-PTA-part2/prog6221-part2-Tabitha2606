using Microsoft.VisualBasic;
using ST10483814_POE_PART_2;
using System;   
using System.Collections.Generic;   
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Controls;

namespace ST10483814_POE_PART_2
{
    public class ChatBotResponses
    {
        // Stores the user's name
        private string userName;

        private Random random = new Random(); // An instance to prevent repetitive responses and keep the conversation natural

        private string lastTopic = "";
        private string preferredTopic = "";
        private List<string> storedFacts = new List<string>();


        public ChatBotResponses(string name)
        {
            this.userName = name.Trim();
        }


        public string GetResponse(string lowerInput)
        {


            // Checks for greeting type questions to allow the user to interact with the chatbot
            if (lowerInput.Contains("how are you?") ||
                lowerInput.Contains("how are you doing?") ||
                lowerInput.Contains("how's it going?"))
            {

                string[] responses = new string[] // Store multiple responses in a array to avoid repetition
                {
                    $"I am doing great {userName}, thank you for asking! I am always on guard and ready to keep " +
                    "you safe online. How can I assist you today?",

                    $"I am absolutely fantastic {userName}! Cybersecurity is always on the lockout 24/7 and " +
                    "so is my commitment to your safety. What can I help you with?"

                };

                // Return a randomly selected response from the array
                return responses[random.Next(0, responses.Length)];
            }

            // Checks if the user is asking about the chatbot's purpose or identity
            if (lowerInput.Contains("purpose") ||
                lowerInput.Contains("who are you") ||
                lowerInput.Contains("what do you do") ||
                lowerInput.Contains("what are you"))
            {

                string[] chatResponses = new string[]
                {
                    $"I am so glad you asked {userName}! I am a Cybersecurity Awareness Bot\n " +
                    "created to educate and guide South African citizens on navigating the\n " +
                    "digital world safely.I cover various topics such as, passwords, phishing,\n" +
                    "safe browsing and so much more...Think of me as your personal and go-to cybersecurity expert!",

                    $"I love that question {userName}! I am a Cybersecurity Awareness Bot\n" +
                    "developed to assist South African citizens in protecting themselves against\n" +
                    "the growing threat of cybercrime. I provide detailed guidance on a wide range\n" +
                    "of cybersecurity topics to you remain safe and informed online at all times."

                };

                return chatResponses[random.Next(0, chatResponses.Length)];
            }

            // Checks if the user needs help wants to see available topics
            if (lowerInput.Contains("help") ||
                lowerInput.Contains("topics") ||
                lowerInput.Contains("menu") || 
                lowerInput.Contains("what can i ask you about"))
                
            {
                if (!string.IsNullOrEmpty(preferredTopic))
                {
                    return $"Based on your interest in {preferredTopic}, {userName}, I recommend starting there. " +
                           $"Type '{preferredTopic}' to continue learning about it!";
                }


                return $"I would be happy to help {userName}! Here are some topics I can assist you with today:\n\n" +
                        "  Passwords\n" +
                        "  Phishing\n" +
                        "  Safe Browsing\n" +
                        "  Privacy\n" +
                        "  Malware\n" +
                        "  Social Engineering\n" +
                        "  Please go ahead and type any keyword to recieve more information";
            }


            // Checks for password related queries using multiple keywords that the user might ask about
            if (lowerInput.Contains("password") ||
                lowerInput.Contains("password safety") ||
                lowerInput.Contains("secure password") ||
                lowerInput.Contains("credentials"))

            {
                lastTopic = "password"; 
                string[] chatResponses = new string[]
                {
                    $"Password safety is extremely important {userName}!\n" +
                    "A strong password must be at least 12 characters long and include a mix of letters, numbers and symbols.\n" +
                    "Avoid using your personal details such as your name or birthday, as these are easy for attackers to guess.\n" +
                    "Never share your password with anyone. If there's any sign of compromise, change or update your password\n" +
                    "immediately and review your account activity for any suspicious login.",
                   

                    $"I am so glad you asked about passwords {userName}!\n" +
                    "Many people unknowingly put themselves at risk by reusing the same password across multiple accounts\n" +
                    "using passwords that are too short or simple.Think of your password as your first line of defense.\n" +
                    "The stronger and more unique it is, the harder it becomes for cybercriminals to break in.\n" +
                    "If possible, consider using a password manager to safely store and generate strong passwords."
                };

                return chatResponses[random.Next(0, chatResponses.Length)];

            }

            // Checks for phishing related queries using multiple keywords that the user might ask about
            if (lowerInput.Contains("phishing") ||
                lowerInput.Contains("suspicious email") ||
                lowerInput.Contains("suspicious link") ||
                lowerInput.Contains("fake website"))

            {
                lastTopic = "phishing";
                string[] chatResponses = new string[]
                {
                    "Phishing is a serious cyber threat that continues to catch countless victims off guard every single day.\n" +
                    "It usually comes in the form fake emails specifically to manipulate you into willingly handing over sensitive\n" +
                    "details like your passwords or banking credentials. Before interacting with any email, always check the sender’s\n" +
                    "email address carefully and ask yourself if the message feels expected or suspicious.\n" +
                    "When in doubt, don’t click — rather go directly to the official website.",
                    

                    "Phishing attacks have undergone a remarkable transformation becoming so convincing. Scammers can impersonate trusted\n" +
                    "organisations like banks, SARS, or even delivery services, making their messages look completely legitimate.\n" +
                    "Watch out and sharpen your awareness for warning signs such as urgency, spelling mistakes, or slightly altered website\n" +
                    $"links. If something feels off, trust your instincts, {userName}, and verify before taking action."
            };

                return chatResponses[random.Next(0, chatResponses.Length)];

            }

            // Checks for safe browsing related queries using multiple keywords that the user might ask about
            if (lowerInput.Contains("safe browsing") ||
                lowerInput.Contains("browser") ||
                lowerInput.Contains("internet") ||
                lowerInput.Contains("website"))

            {
               
                lastTopic = "safe browsing";
                string[] chatResponses = new string[]
                {
                    "Safe browsing is an essential habit in today’s digital environment that needs to develop and maintain consistently.\n" +
                    "Always look for the padlock icon and https:// prefix in the address bar before entering any personal information.\n" +
                    "Be very cautious of websites that display random pop-up ads redirect you to unexpecteed pages — these are often signs\n" +
                    "of malicious activity. And remember, not everything online is trustworthy, so always stay alert.",
                    

                    "Browsing the internet on public or shared computers requires a different level of extra caution.\n" +
                    "Be sure to never access sensitive accounts like online banking apps or even social media platforms,\n " +
                    "as they may contain keylogging.Always ensure you completely log out of every account, clear browsing history\n" +
                    "and never allow the browser to save your login creditionals. Your awareness is your best defence in these situations."
            };

          
                return chatResponses[random.Next(0, chatResponses.Length)];
            }

            // Checks for privacy related queries using multiple keywords that the user might ask about
            if (lowerInput.Contains("privacy") ||
                lowerInput.Contains("personal information") ||
                lowerInput.Contains("data protection") ||
                lowerInput.Contains("popia"))

            {
                lastTopic = "privacy";
                string[] chatResponses = new string[]
                {
                    "Protecting your personal privacy online has never been more critically important than it is in today's digital world.\n" +
                    "Start by conducting a thorough review of the permissions you have granted on your phone and computer removing access to " +
                    "what is necessary. Be mindful and selective about the personal information you choose to share online including your full " +
                    "name, home address, or phone number. Cybercriminals can use small pieces of information to build a full profile of you.",
                    

                    "Social media platforms are among the biggest threats to your personal privacy if not managed with extra precautious and\n" +
                    "consistent vigilance. Regularly check and update privacy setting on all accounts so that trusted people can see your posts\n" +
                    "and personal details. Avoid oversharing information like your location or daily routines.\n" +
                    "Remember that anything you post online can potentially remain accessible forever even after you believe you have deleted it."

                };

                return chatResponses[random.Next(0, chatResponses.Length)];
            }

            // Checks for malware related queries using multiple keywords that the user can ask about 
            if (lowerInput.Contains("malware") ||
                lowerInput.Contains("ransomware") ||
                lowerInput.Contains("virus") ||
                lowerInput.Contains("spyware"))

            {
                lastTopic = "malware";
                string[] chatResponses = new string[]
                {
                     $"Malware is any harmful software designed to damage your device or steal your information.\n" +
                     "This includes viruses, spyware, trojans, and ransomware. You can accidentally install malware by\n" +
                     "clicking suspicious links or downloading files from untrusted sources.\n" +
                     $"To stay safe, always keep your system updated and use reliable antivirus software, {userName}.",

                     $"Ransomware is one of the most dangerous types of malware.\n" +
                     "It locks your files and demands payment to restore access — often with no guarantee you’ll get\n" +
                     "your data back.The best defence is prevention: regularly back up your files to a secure location.\n" +
                     $"That way, even if something goes wrong, you won’t lose everything, {userName}."
            };

                return chatResponses[random.Next(0, chatResponses.Length)];

            }

            // Checks for social engineering related queries using keywords that the user might ask about
            if (lowerInput.Contains("social engineering") ||
               lowerInput.Contains("manipulation") ||
               lowerInput.Contains("scam") || 
               lowerInput.Contains("fraud"))

            {
                lastTopic = "social engineering";
                string[] chatResponses = new string[]
                {
                    $"Social engineering targets people rather than systems, {userName}.\n" +
                    "Attackers manipulate emotions like fear, urgency, or trust to trick you\n" +
                    "into giving away sensitive information. They may pretend to be from a bank,\n" +
                    "IT support, or even someone you know.Always take a moment to verify before responding to any request.",

                   $"There are many types of social engineering attacks.\n" +
                   "For example, pretexting involves creating a fake story to gain your trust,\n" +
                   "while baiting uses tempting offers to lure you in. A common tactic is urgency\n" +
                   "— pressuring you to act quickly without thinking.\n" +
                   $"Stay calm, think critically, and never rush into sharing personal information, {userName}."
    };

                return chatResponses[random.Next(0, chatResponses.Length)];

            }

            // This is a follow-up conversation flow that allows the user get more detailed information about the lastTopic asked 
            if (lowerInput.Contains("tell me more") ||
                lowerInput.Contains("elaborate more") ||
                lowerInput.Contains("more details") ||
                lowerInput.Contains("another tip")) 
                
            {
                return ExpandOn(lastTopic);
            }

            // This handles memory recall related queries allowing the user to see what the chatbot has remembered 
            if (lowerInput.Contains("what do you remember") ||
                lowerInput.Contains("what do you know") ||
                lowerInput.Contains("what do you recall") ||
                lowerInput.Contains("what did i tell you"))
            {
                return RecallMemory();
            }

            // This detects if the user is expressing interest based on specific topics
            if (lowerInput.Contains("i am interested in") ||
                lowerInput.Contains("i want to learn about") ||
                lowerInput.Contains("i am concerned about") ||
                lowerInput.Contains("i like"))
            {
                return HandleInterest(lowerInput);
            }


            string sentimentResponse = DetectSentiment(lowerInput);

            if (sentimentResponse != null) 
            {
                return sentimentResponse;
            }


            // Default fallback uses array and random for varied responses when no keywords are matched
            string[] defaultResponses = new string[]
            {
                $"I appreciate your curiosity {userName} but I am not quite sure I understand. Try typing a specific " +
                "keyword like password, phishing or malware. Type 'help' to see all available topics I can assist you with today.",

                $"Hmm I did not quite catch that {userName}. Could you try rephrasing your question? Ask me about " +
                "passwords, phishing, safe browsing, privacy or malware. Type 'help' for a full list of available topics.",

                $"I want to help you stay safe online,{userName} but I am not sure I understand. Ask about a " +
                "specific cybersecurity topic or type 'help' to discover what I can help you with today."

            };  

            // Return a randomly selected default fallback response
            return defaultResponses[random.Next(0, defaultResponses.Length)];

        }


        private string ExpandOn(string topic)
        {
            switch (topic) // A switch statement is used here to provide more detailed information based on the last topic discussed
            {
                case "password":
                    return $"Here is more about passwords {userName}!. Consider using a passphrase — a sequence of " +
                           "random words like SpicyNoodles26 which is both significantly longer and easier to remember " +
                           "Make sure that all of your accounts have two-factor authentication enabled for an additional layer of security" +
                           "that goes beyond simply using your password.";


                case "phishing":
                    return "More about phishing! Remember to always hover over links before clicking to view the final UR location." +
                           "Check if the website address matches the official site exactly. False claims that your account would be canceled " +
                           "immediately are frequently used in phishing emails. This approach is never used by trusted businesses," +
                           "so handle any urgent email with extreme caution.";


                case "browser":
                    return "More about safe browsing! Install a reliable ad blocker to reduce your exposure to malicious advertisements+" +
                           "For improved online security, think about utilizing a privacy-focused browser like Firefox or Brave for enhanced protection." +
                           "Clear your browser's cookies and cache on a regular basis to minimize monitoring data that is gathered " +
                           "about your browsing behaviour.";


                case "privacy":
                    return "Here is more about privacy! The Protection of Personal Information Act (POPIA) was implemented in South Africa in 2021. " +
                           "You have rights over your personal data under this law, including the ability to access, update, and request the " +
                           "deletion of your information. You can report an organization to the South African Information Regulator if they handle" +
                           "your data illegally.";


                case "malware":
                    return "More about malware - unexpected pop-ups, abrupt device slowdowns, and programs that open without your input are warning indicators" +
                           "of a viral infection. Disconnect from the internet immediately once and do a thorough antivirus check if you see such warning signs." +
                           "Maintaining regular data backups ensures that crucial information is never completely lost due to an attack.";


                case "social engineering":
                    return "More about social engineering - advance payment fraud, lottery scams, and romance scams, in which con artists create fake connections " +
                           "before demanding money, are typical scams in South Africa. The golden rule is straightforward: if anything seems too good to be true," +
                           "it's probably a fraud. When someone asks for sensitive information through official channels, always be sure they are who they say they are.";


                default:
                    return $"Could you be more specific about the topic you would like to know about {userName}? Try typing a keyword like password phishing malware " +
                           "or any other topic and I will provide more detailed information.";
            }
        }

        private string HandleInterest(string lowerInput)
        {
            if (lowerInput.Contains("privacy"))
            {
                preferredTopic = "privacy";
                storedFacts.Add(
                       "I'm is interested in privacy");
                return "Great! I will remember that you are " +
                       $"interested about privacy {userName}.It is essential" +
                       " to maintaining internet safety. You might want to " +
                       "regularly verify the security settings on all of your " +
                       "accounts and use caution when sharing information online " +
                       "if you're concerned about privacy.";
            }

            if (lowerInput.Contains("password"))
            {
                preferredTopic = "password";
                storedFacts.Add(
                       "I'm interested in passwords");
                return $"Noted{userName}! I will keep in mind that you value" +
                       "passwords. Strong unique passwords are your first line of " +
                       "defence online. I will make sure to provide you with the best password " +
                       "guidance throughout our conversation today!";
            }

            if (lowerInput.Contains("phishing"))
            {
                preferredTopic = "phishing";
                storedFacts.Add(
                       "I'm interested in phishing awareness");
                return $"Excellent choice {userName}! Phishing awareness " +
                       "is one of the most crucial cybersecurity skills to acquire. " +
                       "I'll keep this in mind and adjust my responses to best assist you " +
                       "in identifying and avoiding phishing scams.";
            }

            if (lowerInput.Contains("malware"))
            {
                preferredTopic = "malware";
                storedFacts.Add(
                       "I'm interested in malware protection");
                return $"Fantastic {userName}! Malware protection is " +
                       "absolutelycrucial in today's digital world. " +
                       "I will remember your interest and make sure to " +
                       "provide you the most comprehensive malware prevention " +
                       "recommendations.";
            }

            if (lowerInput.Contains("social engineering") ||
                lowerInput.Contains("scam"))
            {
                preferredTopic = "social engineering";
                storedFacts.Add(
                      "I'm intersted about social engineering");
                return $"Very smart {userName}! Social engineering " +
                       "awareness is one of the most valuable cybersecurity " +
                       "skills you can acquire. I will remember this and " +
                       "help you recognise and defend against psychological " +
                       "manipulation techniques used by cybercriminals.";
            }

            return $"Thank you for sharing that {userName}! " +
                   "I will remember your interests and personalise " +
                   "my responses to be most beneficial for you throughout " +
                   "our conversation today.";
        }


        /* Displays all the information that the user 
         * has shared with the chatbot during the conversation
        */
        private string RecallMemory()
        {
            if (storedFacts.Count == 0)
            {
                return "As of right now, I do not have anything saved about you " +
                       $"{userName}. Tell me about your interests " +
                       "by saying something like I am interested in " +
                       "privacy and I will remember it for you!";
            }

            string memory =
                $"Here is what I remember about you {userName}:\n\n";

            for (int i = 0; i < storedFacts.Count; i++)
            {
                memory += $"  {i + 1}. {storedFacts[i]}\n";
            }

            return memory;
        }


        private string DetectSentiment(string lowerInput)
        {
            /*
             * Detect worried or scared sentiment
             * respond with reassurance and share
             * a relevant safety tip automatically
             */
            if (lowerInput.Contains("worried") ||
                lowerInput.Contains("scared") ||
                lowerInput.Contains("nevous"))

            {
                string[] scamResponses = new string[]
                {
                   "It is completely understandable to feel that way. Scammers can be very convincing " +
                   "and sophisticated in their approach. Always verify the identity of anyone requesting personal " +
                   "information, and never click on suspicious links Legitimate companies will never ask for your password " +
                   "or banking information by email.",

                   "Your concern is completely valid, and it demonstrates that are already thinking critically about your online safety, " +
                   "whichis just the right approach. Unfortunately, scams are common in South Africa, but information is your most powerful" +
                   "weapon against them. Remember that any unexpected call email or message requesting for money or personal details should" +
                   "always be taken with extreme caution and verified first."

                    };
                    return scamResponses[random.Next(0, scamResponses.Length)];

                }

                /*
                 * Detect frustrated or confused
                 * sentiment and respond with
                 * encouragement and simplification
                 */
                if (lowerInput.Contains("frustrated") ||
                    lowerInput.Contains("confused") ||
                    lowerInput.Contains("overwhelming"))

                {
                    string[] frustratedResponses = new string[]
                    {
                        $"I completely understand your frustration {userName}. Cybersecurity can feel overwhelming " +
                        "at times but I am here to make it simply it for you. Let me break it down into the three " +
                        "crital basics: use strong unique passwords for every account, be wary of suspicious emails and " +
                        "links and keep all your software and devices up to date. " +
                        "Master these three skills and you will already be significantly safer online!",

                        $"I hear you, {userName}, and I want you to know that being confused about cybersecurity is absolutely normal" +
                        "as even many individuls adults struggle with it. The secret is to avoid trying to learn everything at once." +
                        "Start with a single topic, such as passwords, and go to the next as you become more comfortable. I am here to" +
                        "help you at whatever pace is most comfortable for you!"

                    };
                    return frustratedResponses[random.Next(0, frustratedResponses.Length)];

                }

                /*
                 * Detect curious or interested
                 * sentiment and encourage the
                 * user to keep learning more
                 */
                if (lowerInput.Contains("curious") ||
                    lowerInput.Contains("interested") ||
                    lowerInput.Contains("fascinated"))

                {
                    string[] frustratedResponses = new string[]
                    {
                        "I admire your curiousity, {userName}! That is the right attitude approach for staying safe online. The more you know " +
                        "about cyber threats, the better prepared you will be to fight them. Feel free to ask me any questions on cybersecurity," +
                        "and type 'help' to discover what topics I can help you with today!",

                        $"Your interest is admirable and exemplifies a strong cybersecurity mindset {userName}! People who ask questions and want " +
                        "to understand are much less vulnerable to cyber threats. Keep your curiosity alive, and never stop asking questions. " +
                        "I am here to answer all of your questions regarding keeping safe online!"

                    };
                    return frustratedResponses[random.Next(0, frustratedResponses.Length)];

                }

                /*
                 * Detect happy or confident
                 * sentiment and reinforce the
                 * positive attitude with praise
                 */
                if (lowerInput.Contains("happy") ||
                    lowerInput.Contains("confident") ||
                    lowerInput.Contains("excited"))

                {
                    string[] happyResponses = new string[]
                    {
                        "That is absolutely amazing to hear {userName}! Maintaing a positive and confident about your cybersecurity knowledge is ideal to have. " +
                        "When you feel good about what you are learning you are far more likely to apply it in your daily digital life.Keep learning and always" +
                        "stay vigilant online. Is there anything specific you would like to know or learn more about today?",

                        "I enjoy hearing that {userName}! Your excitement for cybersecurity is very inspirational. Did you know that sharing what you've learned" +
                        "with your friends and family is one of the most effective strategies to combat cybercrime in South Africa? The more people are aware," +
                        "the safer our communities become, so keep spreading that great energy and knowledge!"

                    };
                    return happyResponses[random.Next(0, happyResponses.Length)];

                }


                if (lowerInput.Contains("angry") ||
                    lowerInput.Contains("upset") ||
                    lowerInput.Contains("not helping"))

                {
                    string[] angryResponses = new string[]
                    {
                        $"I am truly sorry to hear you are feeling that way {userName}, and I really apologize if I was not as helpful as you needed." +
                        "Please let me try again - could you tell me what topic you need assistance with? I want to make sure you get the most useful information possible.",

                        $"I understand, {userName}, and I apologize for how you are feeling.I really want to help you be safe online.Sometimes cybersecurity topics can be frustrating," +
                        $"especially when the information does not appear to be relevant to your personal situation.Please tell me exactly what you are having trouble with, and I'll do everything I can to help."

                    };
                    return angryResponses[random.Next(0, angryResponses.Length)];

                }


                return null;

            }

             
        public string GetUserName()
        {
            return userName;

        } 
    } 

} 






















            











