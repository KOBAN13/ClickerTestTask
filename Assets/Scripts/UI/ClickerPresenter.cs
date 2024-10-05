using System;
using SOScripts;
using UniRx;
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

        public ClickerPresenter(ClickerModel model, ClickerView view, UIAnimation uiAnimation, ConfigHandler configHandler)
        {
            _clickerModel = model;
            _clickerView = view;
            _uiAnimation = uiAnimation;
            _configHandler = configHandler;
        }

        private void SubscribeButtons()
        {
            _clickerView.ClickButton.OnClickAsObservable().Subscribe(_ =>
            {
                _clickerModel.CountCurrency.Value += _configHandler.ClickerConfig.CountCurrencyValueInClick;
                _clickerModel.CountCurrentEnergy.Value -= _configHandler.ClickerConfig.CountRemoveEnergyInClick;

            }).AddTo(_compositeDisposable);
        }

        private void SubscribeProperty()
        {
            _clickerModel.CountCurrency.Subscribe(value =>
            {
                _clickerView.Currency.text = $"{value}";
                _uiAnimation.PunchAnimation(_clickerView.Currency);

            }).AddTo(_compositeDisposable);

            _clickerModel.CountCurrentEnergy.Subscribe(value =>
            {
                _clickerView.Energy.text = $"{value}/{_configHandler.ClickerConfig.CountEnergy}";
                _uiAnimation.PunchAnimation(_clickerView.Energy);

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