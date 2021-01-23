using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorServerSide.Shared
{
    public class ViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _counterValue;
        public int CounterValue
        {
            get => _counterValue;
            set
            {
                _counterValue = value; 
                OnPropertyChanged(nameof(CounterValue));
            }
        }

        public void IncrementCounter()
            => CounterValue++;
        public void DecrementCounter()
            => CounterValue--;

    }
}
