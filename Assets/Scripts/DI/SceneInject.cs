using SOScripts;
using UI;
using UnityEngine;
using Zenject;

public class SceneInject : MonoInstaller
{
    [SerializeField] private ClickerView _clickerView;
    [SerializeField] private ConfigHandler _configHandler;
    public override void InstallBindings()
    {
        BindUI();
        BindAnimation();
        BindConfigs();
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
        Container.BindInterfacesAndSelfTo<UIAnimation>().AsSingle().NonLazy();
    }
}
