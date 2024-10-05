using System;
using SaveSystem;
using SOScripts;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ClickerPresenter : IInitializable, IDisposable
    {
        private ClickerModel _clickerModel;
        private ClickerView _clickerView;
        private UIAnimation _uiAnimation;
        private CompositeDisposable _compositeDisposable = new();
        private ConfigHandler _configHandler;
        private readonly SaveSystemController _saveSystemController;

        public ClickerPresenter(ClickerModel model, ClickerView view, UIAnimation uiAnimation, ConfigHandler configHandler, SaveSystemController saveSystemController)
        {
            _clickerModel = model;
            _clickerView = view;
            _uiAnimation = uiAnimation;
            _configHandler = configHandler;
            _saveSystemController = saveSystemController;
        }

        private void SubscribeButtons()
        {
            _clickerView.ClickButton.OnClickAsObservable().Subscribe(_ =>
            {
                var amount = _configHandler.CurrencyConfig.CountCurrencyValueInClick 
                             + _configHandler.AutoСurrencyСollectionConfig.ModificatorBoostCurrencyInPresent 
                             * _configHandler.CurrencyConfig.CountCurrencyValueInClick;

                _clickerModel.CountCurrency.Value += amount;
                _saveSystemController.JsonDataContext.Currency = _clickerModel.CountCurrency.Value;
                _clickerModel.CountCurrentEnergy.Value = Mathf.Clamp(_clickerModel.CountCurrentEnergy.Value - _configHandler.EnergyConfig.CountRecoveryEnergyInOneTime, 0f,
                    _configHandler.EnergyConfig.CountEnergy);
                
                _uiAnimation.ShowFloatingText(_clickerView.CurrencyPrefab, _clickerView.ClickButton.transform.position, amount, _clickerView.Canvas);

            }).AddTo(_compositeDisposable);
        }

        private void SubscribeProperty()
        {
            _clickerModel.CountCurrency.Subscribe(value =>
            {
                _clickerView.Currency.text = $"{value}";
                _uiAnimation.PunchAnimation(_clickerView.Currency.rectTransform);
                _uiAnimation.PunchAnimation(_clickerView.CurrencyImage.rectTransform);

            }).AddTo(_compositeDisposable);

            _clickerModel.CountCurrentEnergy.Subscribe(value =>
            {
                _clickerView.Energy.text = $"{value}/{_configHandler.EnergyConfig.CountEnergy}";
                _uiAnimation.PunchAnimation(_clickerView.Energy.rectTransform);
                _uiAnimation.PunchAnimation(_clickerView.EnergyImage.rectTransform);

            }).AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable?.Clear();
            _compositeDisposable?.Dispose();
        }

        public void Initialize()
        {
            SubscribeProperty();
            SubscribeButtons();
        }
    }
}