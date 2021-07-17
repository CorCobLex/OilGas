using System.ComponentModel;
using System.Runtime.CompilerServices;
using OilGas.Annotations;
using Xamarin.Forms;

namespace OilGas
{
    public class NewElementViewModel : INotifyPropertyChanged
    {
        private Page _ownPage;
        private string _name;
        private int? _code;
        private int? _inventoryNumber;

        public NewElementViewModel(Page ownPage)
        {
            _ownPage = ownPage;
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int? Code
        {
            get => _code;
            set
            {
                _code = value;
                OnPropertyChanged(nameof(Code));
            }
        }

        public int? InventoryNumber
        {
            get => _inventoryNumber;
            set
            {
                _inventoryNumber = value;
                OnPropertyChanged(nameof(InventoryNumber));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}