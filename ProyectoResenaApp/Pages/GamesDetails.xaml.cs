using ProyectoResenaApp.Data;
using ProyectoResenaApp.Models;
using ProyectoResenaApp.ModelsUpdate;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProyectoResenaApp.Pages;

[QueryProperty(nameof(SelectedGame), "SelectedGame")]
public partial class GamesDetails : ContentPage
{
    private ModelsUpdate.Juego _selectedGame;
    private ResenasData _database;
    private int _selectedRating = 0;
    private Resena _editResena = null;

    public ModelsUpdate.Juego SelectedGame
    {
        get => _selectedGame;
        set
        {
            _selectedGame = value;
            OnPropertyChanged();
            LoadReviews();
            UpdateGameDetails();
        }
    }

    public GamesDetails()
    {
        InitializeComponent();
        _database = new ResenasData();
        BindingContext = this;
    }

    private async void BackBtn(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//OnboardingPage/AllGames");
    }

    private void InfoTab_Tapped(object sender, TappedEventArgs e)
    {
        requerimientosTabIndicator.Color = Colors.White;
        resenasTabIndicator.Color = Colors.White;
        infoTabIndicator.Color = Colors.DarkSlateBlue;
        resenasContent.IsVisible = false;
        reviewList.IsVisible = false;
        tabText.Text = $"Fecha de Lanzamiento: {SelectedGame.fechaCreacion}\n" +
                       $"Descripcion: {SelectedGame.nombre}";
    }

    private void RequerimentosTab_Tapped(object sender, TappedEventArgs e)
    {
        infoTabIndicator.Color = Colors.White;
        resenasTabIndicator.Color = Colors.White;
        requerimientosTabIndicator.Color = Colors.DarkSlateBlue;
        resenasContent.IsVisible = false;
        reviewList.IsVisible = false;
        tabText.Text = $"Descripcion: {SelectedGame.descripcion}";
    }

    private void Resenas_Tapped(object sender, TappedEventArgs e)
    {
        infoTabIndicator.Color = Colors.White;
        requerimientosTabIndicator.Color = Colors.White;
        resenasTabIndicator.Color = Colors.DarkSlateBlue;
        resenasContent.IsVisible = true;
        reviewList.IsVisible = true;
        tabText.Text = string.Empty;
    }

    private void UpdateGameDetails()
    {
        tabText.Text = $"Fecha de Lanzamiento: {SelectedGame.fechaCreacion}\n" +
                       $"Descripcion: {SelectedGame.descripcion}";
        GameImage.Source = $"{SelectedGame.urlImagen}";
    }

    private void StarTapped(object sender, TappedEventArgs e)
    {
        var tappedStar = sender as Image;
        _selectedRating = int.Parse(tappedStar.StyleId);

        SetStarRating(_selectedRating);
    }

    private async void SendReview(object sender, EventArgs e)
    {
        if (!App.AuthService.IsLoggedIn)
        {
            await DisplayAlert("No autenticado", "Debe iniciar sesión para enviar una reseña", "OK");
            return;
        }

        string comentario = reviewEntry.Text;

        if (_editResena == null)
        {
            var resena = new Resena
            {
                Usuario = App.AuthService.CurrentUser.Name,
                Comentario = comentario,
                Rating = _selectedRating,
                GameName = SelectedGame.nombre
            };

            SelectedGame.Resenas.Add(resena);
            _database.SaveResena(resena);
        }
        else
        {
            _editResena.Comentario = comentario;
            _editResena.Rating = _selectedRating;
            _database.UpdateResena(_editResena);
            _editResena = null;
        }

        reviewEntry.Text = string.Empty;
        SetStarRating(0);

        await DisplayAlert("Reseña Enviada", "Tu reseña ha sido enviada", "OK");
    }

    private void SetStarRating(int rating)
    {
        star1.Source = rating >= 1 ? "star_full.svg" : "star_empty.svg";
        star2.Source = rating >= 2 ? "star_full.svg" : "star_empty.svg";
        star3.Source = rating >= 3 ? "star_full.svg" : "star_empty.svg";
        star4.Source = rating >= 4 ? "star_full.svg" : "star_empty.svg";
        star5.Source = rating >= 5 ? "star_full.svg" : "star_empty.svg";
    }

    private void LoadReviews()
    {
        var resenas = _database.GetResenasForGame(SelectedGame.nombre);
        SelectedGame.Resenas = new ObservableCollection<Resena>(resenas);
    }

    private void EditReview(object sender, EventArgs e)
    {
        var button = sender as Button;
        var resena = button.BindingContext as Resena;

        reviewEntry.Text = resena.Comentario;
        SetStarRating(resena.Rating);

        _editResena = resena;
    }

    private void DeleteReview(object sender, EventArgs e)
    {
        var button = sender as Button;
        var resena = button.BindingContext as Resena;

        SelectedGame.Resenas.Remove(resena);
        _database.DeleteResena(resena.Id);
    }
}
