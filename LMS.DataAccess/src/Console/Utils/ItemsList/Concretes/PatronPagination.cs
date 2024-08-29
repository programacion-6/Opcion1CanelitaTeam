using LMS.DataAccess.Console.Utils.ItemsList.Interfaces;
using LMS.DataAccess.Systems.Entities.User;

using Spectre.Console;

namespace LMS.DataAccess.Console.Utils.ItemsList.Concretes;

public class PatronPagination : ListPagination
{
    private List<Patron> _patrons;

    public PatronPagination(List<Patron> patrons)
    {
        this._patrons = patrons;
    }

    public void DisplayList()
    {
        int pageSize = 2;
        int currentPage = 1;
        int totalPages = (int) Math.Ceiling(_patrons.Count / (double) pageSize);

        while (true)
        {
            AnsiConsole.Clear();

            var patronsToShow = _patrons
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var table = new Table();
            table.AddColumn("Name");
            table.AddColumn("Membership Number");
            table.AddColumn("Phone Number");
            table.AddColumn("Direction");

            foreach (var patron in patronsToShow)
            {
                table.AddRow(patron.getName(), patron.getMemberShipNumber().ToString(), patron.getPhoneNumber().ToString(), patron.getDirection());
            }

            AnsiConsole.Write(table);

            var options = new List<string>();

            if (currentPage > 1)
                options.Add("Previous Page");
            if (currentPage < totalPages)
                options.Add("Next Page");

            options.Add("Exit");

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"Page {currentPage} of {totalPages}")
                    .AddChoices(options)
            );

            if (selection == "Previous Page")
            {
                currentPage--;
            }
            else if (selection == "Next Page")
            {
                currentPage++;
            }
            else if (selection == "Exit")
            {
                break;
            }
        }
    }
}
