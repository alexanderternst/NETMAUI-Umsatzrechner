using System.ComponentModel;

namespace NETMAUI_Umsatzrechner.Views;

[QueryProperty(nameof(Bruttobetrag), nameof(Bruttobetrag))]
[QueryProperty(nameof(NettoBetrag), nameof(NettoBetrag))]
[QueryProperty(nameof(UstBetrag), nameof(UstBetrag))]
public partial class ErgebnisPage : ContentPage, INotifyPropertyChanged
{
    private float _bruttobetrag;

    public float Bruttobetrag
    {
        get { return _bruttobetrag; }
        set
        {
            _bruttobetrag = value;
            OnPropertyChanged(nameof(Bruttobetrag));
        }
    }


    private float _nettoBetrag;

    public float NettoBetrag
    {
        get { return _nettoBetrag; }
        set
        {
            _nettoBetrag = value;
            OnPropertyChanged(nameof(NettoBetrag));
        }
    }

    private float _ustBetrag;

    public float UstBetrag
    {
        get { return _ustBetrag; }
        set
        {
            _ustBetrag = value;
            OnPropertyChanged(nameof(UstBetrag));
        }
    }

    public ErgebnisPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyname)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}