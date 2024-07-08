namespace ProyectoResenaApp.Pages;

public partial class OnboardingPage : ContentPage
{
	public OnboardingPage()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        Preferences.Default.Set(UIConstants.OnboardingShown, string.Empty);
	}

    private  void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AllGames));
    }
}