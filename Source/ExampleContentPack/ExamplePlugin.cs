using Lomztein.BFA2;
using Lomztein.BFA2.LocalizationSystem;
using Lomztein.BFA2.Plugins;
using Lomztein.BFA2.UI;
using Lomztein.BFA2.UI.Messages;
using System;

namespace ExampleContentPack
{
    public class ExamplePlugin : IPlugin
    {
        private bool _hasDisplayed = false;

        public void Start()
        {
            Facade.MainMenu.OnWindowChanged += MainMenu_OnWindowChanged;
        }

        private void AskQuestion ()
        {
            Question.Open("..Are you sure about that?",
                new Question.Option("Most definitely", Yes),
                new Question.Option("..maybe?", Maybe),
                new Question.Option("lol no", No));
        }

        private void Yes ()
        {
            Prompt.Open("Whats your name, sailor?", WhatsYourNameSailor);
        }

        private void WhatsYourNameSailor (string name)
        {
            Alert.Open("Well, hello there " + name);
        }

        private void Maybe()
        {
            Alert.Open("Better figure it out then!");
        }

        private void No ()
        {
            Alert.Open("aw :c");
        }

        private void MainMenu_OnWindowChanged(Lomztein.BFA2.MainMenu.MenuWindow arg1, Lomztein.BFA2.MainMenu.MenuWindow arg2)
        {
            Message.Send("Example plugin says window changed from " + arg1.Name + " to " + arg2.Name, Message.Type.Minor);
            if (!_hasDisplayed)
            {
                Confirm.Open("You have the Example Plugin enabled.", AskQuestion);
                _hasDisplayed = true;
            }
        }

        public void Stop()
        {
            Facade.MainMenu.OnWindowChanged -= MainMenu_OnWindowChanged;
        }
    }
}
