using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NETMAUI_Umsatzrechner.Views;

[QueryProperty(nameof(BruttoBetrag), nameof(BruttoBetrag))]
[QueryProperty(nameof(NettoBetrag), nameof(NettoBetrag))]
[QueryProperty(nameof(UstBetrag), nameof(UstBetrag))]
public partial class ErgebnisPage : ContentPage, INotifyPropertyChanged
{
    #region Output Data Binding

    private float _bruttobetrag;
    public float BruttoBetrag
    {
        get => _bruttobetrag;
        set
        {
            SetProperty(ref _bruttobetrag, value);
        }
    }

    private float _nettoBetrag;
    public float NettoBetrag
    {
        get => _nettoBetrag;
        set
        {
            SetProperty(ref _nettoBetrag, value);
        }
    }

    private float _ustBetrag;
    public float UstBetrag
    {
        get => _ustBetrag;
        set
        {
            SetProperty(ref _ustBetrag, value);
        }
    }
    #endregion

    #region Data Binding Integration
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyname)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
    protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] string property = null)
    {
        if (Object.Equals(storage, value)) return;
        storage = value;
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(property));
    }
    #endregion

    public ErgebnisPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alert", $"An error occured. {ex.Message}", "OK");
        }
    }

}