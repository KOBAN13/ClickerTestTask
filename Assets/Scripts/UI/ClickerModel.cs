using Cysharp.Threading.Tasks;
using SaveSystem;
using SOScripts;
using UniRx;
using Zenject;

namespace UI
{
    public class ClickerModel : IInitializable
    {
        public ReactiveProperty<float> CountCurrency { get; private set; } = new();
        public ReactiveProperty<float> CountCurrentEnergy { get; private set; } = new();
        private ConfigHandler _configHandler;
        private readonly SaveSystemController _saveSystemController;
        
        public ClickerModel(ConfigHandler configHandler, SaveSystemController saveSystemController)
        {
            _configHandler = configHandler;
            _saveSystemController = saveSystemController;
        }

        public async void Initialize()
        {
            CountCurrentEnergy.Value = _configHandler.EnergyConfig.CountEnergy;

            if (_saveSystemController.IsUseSystem)
            {
                await UniTask.WaitUntil(() => _saveSystemController.IsLoad);
                CountCurrency.Value = _saveSystemController.JsonDataContext.Currency;
            }
        }
    }
}