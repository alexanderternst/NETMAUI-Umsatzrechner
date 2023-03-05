using NETMAUI_Umsatzrechner.Views;

namespace NETMAUI_Umsatzrechner;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		Routing.RegisterRoute("ErgebnisPage", typeof(ErgebnisPage));
    }
}
