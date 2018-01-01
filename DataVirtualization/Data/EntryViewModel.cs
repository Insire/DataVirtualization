using System;

namespace DataVirtualization
{
    public class EntryViewModel
    {
        public int Id { get; set; }
        public DateTime Creation { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public EntryViewModel(int id)
        {
            Id = id;
            Creation = DateTime.Now + TimeSpan.FromSeconds(id);
            Amount = id * 100;
            Name = string.Format("Entry ID #{0}", Id);
            Description = string.Format("Entry Name {0}, ID #{1}", Name, Id);
        }

        public override string ToString()
        {
            return string.Format("Entry ID:{0}, Name:{1}", Id, Name);
        }
    }
}
