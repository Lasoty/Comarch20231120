
using Bibliotekarz.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Bibliotekarz.Client.Pages;

public partial class Dashboard
{
    [Inject]
    public HttpClient Client { get; set; }

    [Inject]
    public INotificationService Notifications { get; set; }

    public List<Book> Books { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
		try
		{
            List<Book>? books = await Client.GetFromJsonAsync<List<Book>>("api/Book/GetBooks");

            if (books != null)
            {
                Books = books;
            }
            await Notifications.Success("Pobrano książki.", "Sukces");
        }
        catch (Exception ex)
		{
            await Notifications.Error("Nie udało się pobrać danych książek.", "Błąd aplikacji");
        }

    }
}
