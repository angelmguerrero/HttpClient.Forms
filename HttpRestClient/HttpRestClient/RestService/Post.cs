using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace HttpRestClient
{
    internal class Post: INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _title;
        
        [JsonProperty("title")]
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                //OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName= null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}
