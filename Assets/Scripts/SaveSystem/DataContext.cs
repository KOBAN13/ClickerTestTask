using System;
using Zenject;

namespace SaveSystem
{
    public class DataContext
    {
        protected GameData GameDataCurrent;
        
        public float Currency
        {
            get => GameDataCurrent.currency;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                GameDataCurrent.currency = value;
            }
        }

        [Inject]
        private void Construct(GameData gameData) => GameDataCurrent = gameData;
    }
}