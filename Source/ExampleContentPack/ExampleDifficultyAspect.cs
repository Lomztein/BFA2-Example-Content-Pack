using Lomztein.BFA2.Enemies;
using Lomztein.BFA2.Scenes.Battlefield.Difficulty.Aspects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleContentPack
{
    public class ExampleDifficultyAspect : IDifficultyAspect
    {
        public string Name => "Example Difficulty Aspect";
        public string Description => string.Empty;
        public string CategoryIdentifier => "Core.Enemies";

        public void Apply()
        {
            RoundController.Instance.OnNewWave += Instance_OnNewWave;
        }

        private void Instance_OnNewWave(Lomztein.BFA2.Enemies.Waves.WaveTimeline obj)
        {
            obj.ForEach(x => x.EnemyIdentifier = "Example.ExampleEnemy");
        }
    }
}

