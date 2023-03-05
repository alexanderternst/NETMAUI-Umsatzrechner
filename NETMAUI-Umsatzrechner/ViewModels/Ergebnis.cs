namespace NETMAUI_Umsatzrechner
{
    public class Ergebnis
    {
        #region Properties
        public float Betrag { get; set; }

        public float BetragBrutto { get; set; }

        public float BetragNetto { get; set; }

        public float BetragUst { get; set; }

        public bool IsNetto { get; set; }

        public float UstProzent { get; set; }
        #endregion

        #region Konstruktoren
        public Ergebnis()
        {
            
        }

        public Ergebnis(bool isNetto, float betrag, float prozensatz)
        {
            IsNetto = isNetto;
            UstProzent = prozensatz;
            Betrag = betrag;
        }
        #endregion

        public void Berechnen()
        {
            if (IsNetto)
            {
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
    }
}
