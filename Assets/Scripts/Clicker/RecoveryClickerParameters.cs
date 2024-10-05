using System;
using SaveSystem;
using SOScripts;
using UI;
using UniRx;
using UnityEngine;
using Zenject;

namespace Clicker
{
    public class RecoveryClickerParameters : IInitializable
    {
        private ClickerModel _clickerModel;
        private ConfigHandler _configHandler;
        private readonly SaveSystemController _saveSystemController;

        private CompositeDisposable _compositeDisposable = new();
        private Action _recoveryEnergy = delegate { };
        private Action _recoveryCurrency = delegate { };

        public RecoveryClickerParameters(ClickerModel clickerModel, ConfigHandler configHandler)
        {
            _clickerModel = clickerModel;
            _configHandler = configHandler;
        }

        private void InitActions()
        {
            _recoveryEnergy = () =>
            {
                _clickerModel.CountCurrentEnergy.Value = Mathf.Clamp(_clickerModel.CountCurrentEnergy.Value + _configHandler.EnergyConfig.CountRecoveryEnergyInOneTime, 0f,
                    _configHandler.EnergyConfig.CountEnergy);
            };
            _recoveryCurrency = () =>
                _clickerModel.CountCurrency.Value += _configHandler.AutoСurrencyСollectionConfig.CurrentAutoCurrency;
        }


        private void SubscribeTimers()
        {
            Timer(_configHandler.EnergyConfig.TimeToRecoveryEnergy, _recoveryEnergy);
            Timer(_configHandler.AutoСurrencyСollectionConfig.CurrencyCollectionTimeInSecond, _recoveryCurrency);
        }

        private void Timer(float time, Action action)
        {
            Observable
                .Timer(TimeSpan.FromSeconds(time), TimeSpan.FromSeconds(time))
                .Subscribe(_ => action());
        }

        public void Initialize()
        {
            InitActions();
            SubscribeTimers();
        }
    }
}