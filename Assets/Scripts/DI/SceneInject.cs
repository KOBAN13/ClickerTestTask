using Clicker;
using SaveSystem;
using SOScripts;
using UI;
using UnityEngine;
using Zenject;

public class SceneInject : MonoInstaller
{
    [SerializeField] private ClickerView _clickerView;
    [SerializeField] private ConfigHandler _configHandler;
    [SerializeField] private UIAnimation _uiAnimation;
    [SerializeField] private SaveSystemController _saveSystem;

    public override void InstallBindings()
    {
        BindUI();
        BindAnimation();
        BindConfigs();
        BindRecovery();
        BindData();
    }

    private void BindRecovery()
    {
        Container.BindInterfacesAndSelfTo<RecoveryClickerParameters>().AsSingle().NonLazy();
    }

    private void BindConfigs()
    {
        Container.BindInterfacesAndSelfTo<ConfigHandler>().FromInstance(_configHandler).AsSingle().NonLazy();
    }

    private void BindUI()
    {
        Container.BindInterfacesAndSelfTo<ClickerPresenter>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ClickerView>().FromInstance(_clickerView).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ClickerModel>().AsSingle().NonLazy();
    }

    private void BindAnimation()
    {
        Container.BindInterfacesAndSelfTo<UIAnimation>().FromInstance(_uiAnimation).AsSingle().NonLazy();
    }
    
    private void BindData()
    {
        Container.Bind<GameData>().To<GameData>().AsSingle().NonLazy();
        Container.Bind<JsonDataContext>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<SaveSystemController>().FromInstance(_saveSystem).AsSingle().NonLazy();
    }
}
