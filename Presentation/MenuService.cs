

using Business.Services;
using Domain.Factories;
using Dtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Presentation;

public class MenuService
{
    private readonly ContactService _contactService = new();
    
    public void ShowMenuDialog()
    {
        while (true)
        {
            Console.Clear();
            Console.Title = "ASCII Art";
            Console.ForegroundColor = ConsoleColor.Green;
            string title = @"
                 __  __ __   __  _____             _              _   
                |  \/  |\ \ / / | ___ \           (_)            | |  
                | .  . | \ V /  | |_/ /_ __  ___   _   ___   ___ | |_ 
                | |\/| |  \ /   |  __/| '__|/ _ \ | | / _ \ / __|| __|
                | |  | |  | |   | |   | |  | (_) || ||  __/| (__ | |_ 
                \_|  |_/  \_/   \_|   |_|   \___/ | | \___| \___| \__|
                                                  / |                 
                                                |__/                  
            ";

            Console.WriteLine(title);
             Console.ResetColor();
            Console.ForegroundColor=ConsoleColor.Yellow;
            //Console.BackgroundColor=ConsoleColor.Blue;
            Console.WriteLine("------- MENU OPTIONS --------\n");
            Console.WriteLine($" {"1.",-3} CREATE CONTACT");
            Console.WriteLine($" {"2.",-3} VIEW ALL CONTACTS");
            Console.WriteLine($" {"3.",-3} VIEW CONTACT BY NAME");
            Console.WriteLine($" {"4.",-3} REMOVE ALL CONTACTS");
            Console.WriteLine($" {"Q.",-3} QUIT");
            Console.WriteLine("\n----------------------------------\n");
         
            Console.Write("Selected Option: ");
            Console.ResetColor();
            var option = Console.ReadLine()!;
            switch (option.ToLower())
            {

                case "1":
                    CreateContactDialog();
                    break;

                case "2":
                    ViewAllContactsDialog();
                    break;
                case "3":
                    ViewContactByNameDialog();
                    break;
                case "4":
                    RemoveAllContactsDialog();
                    break;
                case "q":
                    QuitApplicationDialog();
                    break;

                default:
                    InvalidOptionDialog();
                    break;



            }
        }

    }

    public void CreateContactDialog()
    {
        Console.Clear();
        Console.WriteLine("------------ CREATE USER --------\n");
        ContactRegistrationForm contact = ContactFactory.Create();

        contact.FirstName = PromtAndValidate("Enter your first name: ", nameof(contact.FirstName));
        contact.LastName = PromtAndValidate("Enter your last name: ", nameof(contact.LastName));
        contact.Email = PromtAndValidate("Enter your email: ", nameof(contact.Email));
        contact.PhoneNumber= PromtAndValidate("Enter your PhoneNumber: ", nameof(contact.PhoneNumber));
        contact.City = PromtAndValidate("Enter your city: ", nameof(contact.City));

        contact.PostalCode = PromtAndValidate("Enter your PostalCode: ", nameof(contact.PostalCode));
        contact.StreetAddress = PromtAndValidate("Enter your StreetAddress: ", nameof(contact.StreetAddress));

       
        _contactService.Add(contact);
    }
    public void ViewAllContactsDialog()
    {
        Console.Clear();
        Console.WriteLine("------------ VIEW ALL USERS --------\n");

        var contacts = _contactService.GetAll();
        foreach (var contact in contacts)
        {

            Console.WriteLine($"{"Id:",-15}{contact.Id}");
            Console.WriteLine($"{"Name:",-15}{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"{"Email:",-15}{contact.Email}");
            Console.WriteLine($"{"PhoneNumber:",-15}{contact.PhoneNumber}");
            Console.WriteLine($"{"city:",-15}{contact.City}");
            Console.WriteLine($"{"PostalCode:",-15}{contact.PostalCode}");
            Console.WriteLine($"{"StreetAddress:",-15}{contact.StreetAddress}");
            Console.WriteLine("");
        }
        Console.ReadKey();
    }
    public void ViewContactByNameDialog()
    {
        Console.Clear();
        Console.WriteLine("------------ VIEW CONTACT BY NAME --------\n");

        Console.Write("Enter the name (first or last) to search: ");
        var name = Console.ReadLine()!;

        var contacts = _contactService.GetContactByName(name);

        if (!contacts.Any())
        {
            Console.WriteLine("\nNo contacts found with the given name.");
        }
        else
        {
            Console.WriteLine("\nFound Contacts:\n");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{"Id:",-15}{contact.Id}");
                Console.WriteLine($"{"Name:",-15}{contact.FirstName} {contact.LastName}");
                Console.WriteLine($"{"Email:",-15}{contact.Email}");
                Console.WriteLine($"{"PhoneNumber:",-15}{contact.PhoneNumber}");
                Console.WriteLine($"{"City:",-15}{contact.City}");
                Console.WriteLine($"{"PostalCode:",-15}{contact.PostalCode}");
                Console.WriteLine($"{"StreetAddress:",-15}{contact.StreetAddress}");
                Console.WriteLine("------------------------------------");
            }
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

   

    public void RemoveAllContactsDialog()
    {
        Console.Clear();
        Console.WriteLine("--------- REMOVE ALL USERS ---------");
        Console.WriteLine("You are about to remov all contacts. \n\nAre sure you want to do that?(y/n)");
        var option = Console.ReadLine()!;
        if (option.ToLower() == "y")
        {
            Console.Clear();
            var result = _contactService.RemoveAll();
            if (result)
                Console.WriteLine("All Contact was successfully removed");
            else
                Console.WriteLine("Something went wrong. Contacts was not removed.");
            Console.ReadKey();
        }
    }

    public void QuitApplicationDialog()
    {
        Console.Clear();
        Console.WriteLine("---------- QUIT APPLICATION ----------\n");
        Console.WriteLine("Are you sure you want to exit?  (y/n): ");
        var option = Console.ReadLine()!;
        if (option.ToLower() == "y")
            Environment.Exit(0);
    }
    public void InvalidOptionDialog()
    {
        Console.WriteLine("");
        Console.WriteLine("Invaild option selected. Please try again.");
        Console.ReadKey();
    }

    public string PromtAndValidate(string prompt, string propertName)
    {
        while (true)
        {
            Console.WriteLine();
            Console.Write(prompt);
            var input = Console.ReadLine() ?? string.Empty;


            var results = new List<ValidationResult>();
            var context = new ValidationContext(new ContactRegistrationForm()) { MemberName = propertName };

            if (Validator.TryValidateProperty(input, context, results))
                return input;
            Console.WriteLine($"{results[0].ErrorMessage}. Please try again. ");

        }
    }
}
