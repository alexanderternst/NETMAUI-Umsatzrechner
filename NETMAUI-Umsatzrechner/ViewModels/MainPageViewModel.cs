using NETMAUI_Umsatzrechner.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;


namespace NETMAUI_Umsatzrechner
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Input Data Binding Properties
        private string _isNetto;

        public string IsNetto
        {
            get { return _isNetto; }
            set
            {
                _isNetto = value;
                OnPropertyChanged(nameof(IsNetto));
            }
        }

        private string _prozent;

        public string Prozent
        {
            get { return _prozent; }
            set
            {
                _prozent = value;
                OnPropertyChanged(nameof(Prozent));
            }
        }

        private string _betrag;

        public string Betrag
        {
            get { return _betrag; }
            set
            {
                _betrag = value;
                OnPropertyChanged(nameof(Betrag));
            }
        }
        #endregion

        #region Command Binding
        private Command _cmdBerechnen { get; set; }
        public Command CmdBerechnen
        {
            get { return _cmdBerechnen; }
            set { _cmdBerechnen = value; }
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
        #endregion

        public MainPageViewModel()
        {
            _cmdBerechnen = new Command(Execute_Berechnen);
            // Setzen von Standardwerten
            Prozent = "8.0 Prozent";
            IsNetto = "True";
            Betrag = string.Empty;
        }

        // Berechnungsmethode
        private async void Execute_Berechnen()
        {
            try
            {
                bool isNetto = Convert.ToBoolean(IsNetto);
                float betrag = Convert.ToSingle(Betrag);
                float prozentsatz = Convert.ToSingle(Prozent.Substring(0, 3));

                Ergebnis ergebnis = new Ergebnis(isNetto, betrag, prozentsatz);
                ergebnis.Berechnen();

                // Register Route in App.xaml.cs
                var state = new ShellNavigationState($"{nameof(ErgebnisPage)}?{nameof(ErgebnisPage.BruttoBetrag)}={ergebnis.BetragBrutto}&{nameof(ErgebnisPage.NettoBetrag)}={ergebnis.BetragNetto}&{nameof(ErgebnisPage.UstBetrag)}={ergebnis.BetragUst}");
                await Shell.Current.GoToAsync(state);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", $"An error occured. {ex.Message}", "OK");
            }
            finally
            {
                Prozent = "8.0 Prozent";
                IsNetto = "True";
                Betrag = string.Empty;
            }

        }

    }
}
