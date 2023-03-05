using NETMAUI_Umsatzrechner.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETMAUI_Umsatzrechner
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
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

        private Command _cmdBerechnen { get; set; }

        public MainPageViewModel()
        {
            _cmdBerechnen = new Command(Execute_Berechnen);
            Prozent = "8.0 Prozent";
            IsNetto = "True";
        }

        private async void Execute_Berechnen()
        {
            bool isNetto = Convert.ToBoolean(IsNetto);
            float betrag = Convert.ToSingle(Betrag);
            float prozentsatz = Convert.ToSingle(Prozent.Substring(0, 3));

            Ergebnis ergebnis = new Ergebnis(isNetto, betrag, prozentsatz);
            ergebnis.Berechnen();

            // Register Route in App.xaml.cs
            var state = new ShellNavigationState($"{nameof(ErgebnisPage)}?{nameof(ErgebnisPage.Bruttobetrag)}={ergebnis.BetragBrutto}&{nameof(ErgebnisPage.NettoBetrag)}={ergebnis.BetragNetto}&{nameof(ErgebnisPage.UstBetrag)}={ergebnis.BetragUst}");
            await Shell.Current.GoToAsync(state);

            //await Shell.Current.GoToAsync(nameof(ErgebnisPage));
            
        }

        private bool CanExecute_Berechnen()
        {
            return !String.IsNullOrEmpty(Betrag);
        }
        public Command CmdBerechnen
        {
            get { return _cmdBerechnen; }
            set { _cmdBerechnen = value; }
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
}
