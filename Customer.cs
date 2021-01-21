using System;
using System.ComponentModel;


public class Customer: INotifyPropertyChanged
{
    public Customer(string name)
    {
        Name = name;
    }
    private string name;
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
            OnPropertyChanged("Name");
        }
    }
            
}
