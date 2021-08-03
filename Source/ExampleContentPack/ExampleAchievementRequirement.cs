using Lomztein.BFA2;
using Lomztein.BFA2.Player.Progression.Achievements.Requirements;
using Lomztein.BFA2.Serialization;
using Lomztein.BFA2.Serialization.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleContentPack
{
    public class ExampleAchievementRequirement : IAchievementRequirement
    {
        public bool Binary => false;
        public float Progression => _clicks / (float)TargetClicks;
        public bool Completed => _clicks >= TargetClicks;

        private int _clicks;
        [ModelProperty]
        public int TargetClicks;

        private Action _onCompletedCallback;
        private Action _onProgressedCallback;

        public void DeserializeProgress(ValueModel source)
        {
            _clicks = (source as PrimitiveModel).ToObject<int>();
        }

        public void End()
        {
            Input.PrimaryClickStarted -= ClickStarted;
            Input.SecondaryClicKStarted -= ClickStarted;
        }

        public void Init(Action onCompletedCallback, Action onProgressedCallback)
        {
            _onCompletedCallback = onCompletedCallback;
            _onProgressedCallback = onProgressedCallback;
            Input.PrimaryClickStarted += ClickStarted;
            Input.SecondaryClicKStarted += ClickStarted;
        }

        private void ClickStarted(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!Completed)
            {
                _clicks++;
                _onProgressedCallback();
                if (Completed)
                {
                    _onCompletedCallback();
                }
            }
        }

        public ValueModel SerializeProgress()
        {
            return new PrimitiveModel(_clicks);
        }
    }
}
