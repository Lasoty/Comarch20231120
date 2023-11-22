using Bibliotekarz.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Bibliotekarz.Client.Pages;

public partial class AddBookPage
{
    public Book Vm { get; set; } = 
        new Book()
            {
                Borrower = new Customer()
            };

    [Inject]
    public HttpClient Client { get; set; }

    [Inject]
    public INotificationService Notifications { get; set; }

    [Inject]
    public NavigationManager Navigation { get; set; }

    public async void OnSaveClicked()
    {
        if (!Vm.IsBorrowed) 
        {
            Vm.Borrower = null;
        }

        try
        {
            await Client.PostAsJsonAsync("api/Book/AddBook", Vm);
            await Notifications.Success("Dodano książkę do bazy.", "Sukces");
            Navigation.NavigateTo("/");
        }
        catch (Exception ex)
        {
            await Notifications.Error("Wystąpił bład podczas dodawania książki.", "Błąd");
        }
    }
}
