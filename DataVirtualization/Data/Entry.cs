using System;
using System.ComponentModel;

namespace Tomers.WPF.DataVirtualization.Data
{
    public class Entry : INotifyPropertyChanged
    {
        private bool _isExtended = false;

        public int Id { get; set; }
        public DateTime Creation { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsExtended
        {
            get { return _isExtended; }
            set
            {
                if (_isExtended != value)
                {
                    _isExtended = value;
                    NotifyPropertyChanged("IsExtended");
                }
            }
        }

        public Entry(int id)
        {
            this.Id = id;
            this.Creation = DateTime.Now + TimeSpan.FromSeconds(id);
            this.Amount = id * 100;
            this.Name = string.Format("Entry ID #{0}", Id);
            this.Description = string.Format("Entry Name {0}, ID #{1}", Name, Id);
        }

        public override string ToString()
        {
            return string.Format("Entry ID:{0}, Name:{1}", Id, Name);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
