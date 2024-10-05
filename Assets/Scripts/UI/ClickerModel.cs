using UniRx;

namespace UI
{
    public class ClickerModel
    {
        public ReactiveProperty<float> CountCurrency { get; private set; } = new();
        public ReactiveProperty<int> CountCurrentEnergy { get; private set; } = new();
    }
}