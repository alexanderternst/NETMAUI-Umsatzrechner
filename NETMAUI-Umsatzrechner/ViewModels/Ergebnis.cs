using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETMAUI_Umsatzrechner
{
    public class Ergebnis : INotifyPropertyChanged
    {
        #region Properties
        private float _betrag;

        public float Betrag
        {
            get { return _betrag; }
            set
            {
                _betrag = value;
                OnPropertyChanged(nameof(Betrag));
            }
        }

        private float _betragBrutto;

        public float BetragBrutto
        {
            get { return _betragBrutto; }
            set
            {
                _betragBrutto = value;
                OnPropertyChanged(nameof(BetragBrutto));
            }
        }

        private float _betragNetto;

        public float BetragNetto
        {
            get { return _betragNetto; }
            set
            {
                _betragNetto = value;
                OnPropertyChanged(nameof(BetragNetto));
            }
        }

        private float _betragUst;

        public float BetragUst
        {
            get { return _betragUst; }
            set
            {
                _betragUst = value;
                OnPropertyChanged(nameof(BetragUst));
            }
        }

        private bool _isNetto;

        public bool IsNetto
        {
            get { return _isNetto; }
            set
            {
                _isNetto = value;
                OnPropertyChanged(nameof(IsNetto));
            }
        }

        private float _ustProzent;

        public float UstProzent
        {
            get { return _ustProzent; }
            set
            {
                _ustProzent = value;
                OnPropertyChanged(nameof(UstProzent));
            }
        }
        #endregion
        public Ergebnis()
        {
            
        }

        public Ergebnis(bool isNetto, float betrag, float prozensatz)
        {
            IsNetto = isNetto;
            UstProzent = prozensatz;
            Betrag = betrag;
        }

        public async void Berechnen()
        {
            if (IsNetto) { 
                BetragNetto = Betrag;
                BetragUst = UstProzent;
                BetragBrutto = Betrag + (Betrag / 100 * UstProzent);
            }
            else
            {
                // BetragBrutto: 100, UstProzent: 8, BetragNetto: ?
                // BetragNetto = BetragBrutto * 100 / (100 + UstProzent);
                // BetragNetto = 100 * 100 / (100 + 8);
                // BetragNetto = 100 * 100 / 108;
                // BetragNetto = 10000 / 108
                // BetragNetto = 92,5925925925926

                // BetragBrutto = 92,5925925925926 + (92,5925925925926 / 100 * 8);
                // BetragBrutto = 92,5925925925926 + (7,4074074074074);
                // BetragBrutto = 100,0000000000000

                BetragNetto = Betrag * 100 / (100 + UstProzent);
                BetragUst = UstProzent;
                BetragBrutto = Betrag;
            }
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
