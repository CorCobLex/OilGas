using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using KakUgodno;
using OilGas.Annotations;
using RestSharp;
using Xamarin.Forms;

namespace OilGas
{
    class MainViewModel: INotifyPropertyChanged
    {
        private Page _ownPage;
        private int? _inventoryNum;
        private string _selectedName;
        private int? _selectedCode;
        private int? _selectedInventoryNumber;
        private int? _selectedId;

        private BackgroundWorker _bwFindElement;


        public MainViewModel(Page page)
        {
            _bwFindElement = new BackgroundWorker();
            _bwFindElement.WorkerSupportsCancellation = true;
            _bwFindElement.DoWork += BwFindElementOnDoWork;
            _bwFindElement.RunWorkerCompleted += BwFindElementOnRunWorkerCompleted;
            _ownPage = page;
        }

        private void BwFindElementOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedCode));
            OnPropertyChanged(nameof(SelectedName));
            OnPropertyChanged(nameof(SelectedId));
            OnPropertyChanged(nameof(SelectedInventoryNumber));
        }

        private void BwFindElementOnDoWork(object sender, DoWorkEventArgs e)
        {
            FindElement();
        }

        public string SelectedName
        {
            get => _selectedName;
            set
            {
                _selectedName = value;
                OnPropertyChanged(nameof(SelectedName));
            }
        }

        public int? SelectedCode
        {
            get => _selectedCode;
            set
            {
                _selectedCode = value;
                OnPropertyChanged(nameof(SelectedCode));
            }
        }

        public int? SelectedInventoryNumber
        {
            get => _selectedInventoryNumber;
            set
            {
                _selectedInventoryNumber = value;
                OnPropertyChanged(nameof(SelectedInventoryNumber));
            }
        }

        public int? SelectedId
        {
            get => _selectedId;
            set
            {
                _selectedId = value;
                OnPropertyChanged(nameof(SelectedId));
            }
        }

        public int? InventoryNum
        {
            get => _inventoryNum;
            set
            {
                _inventoryNum = value;
                if (_bwFindElement.IsBusy)
                {
                    _bwFindElement.CancelAsync();
                }
                _bwFindElement.RunWorkerAsync();

                OnPropertyChanged(nameof(InventoryNum));
            }

        }

        public async void FindElement()
        {
            
            var keyvalues = new List<KeyValuePair<string, string>>
            {

            };
            var request = new HttpRequestMessage(HttpMethod.Get, "https://192.168.0.242:45456/InventNumber?inventNumber=5");
            request.Content = new FormUrlEncodedContent(keyvalues);

            var client = new HttpClient();

           // var num = GetSertificate();
            var response = await client.GetAsync("https://192.168.0.242:45456/InventNumber?inventNumber=5");
            Debug.WriteLine(response.Content);


            /*
                        var request = new RestRequest();

                       // var response = client.Get(request);



                        var responce = await client.GetAsync<InventNumber>(request);
                        Debug.WriteLine(responce);*/

        }

        public Command OpenNewElementFormCommand => new Command(() =>
        {
            _ownPage.Navigation.PushAsync(new NewElementPage());
        });

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
