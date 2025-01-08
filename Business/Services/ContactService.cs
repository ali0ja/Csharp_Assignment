

using Business.Helper;
using Data.Services;
using Domain.Factories;
using Domain.Models;
using Dtos;

namespace Business.Services
{
  public class ContactService
    {
        private List<Contact> _contact = [];
        private readonly FileService _fileService = new();

        public void Add(ContactRegistrationForm form)
        {
            Contact contact = ContactFactory.Create(form);
            contact.Id = UniqueIdentifierGenerator.Genrate();
            _contact.Add(contact);
            _fileService.SaveListToFile(_contact);
        }

        public IEnumerable<Contact> GetAll()
        {
            _contact = _fileService.LoadListFromFile();
            return _contact;
        }
        public IEnumerable<Contact> GetContactByName(string name)
        {
            // Läs in den senaste listan från filen
            _contact = _fileService.LoadListFromFile();

            // Filtrera kontakter baserat på namn (case-insensitive)
            return _contact.Where(c =>
                c.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                c.LastName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }


        public bool RemoveAll()
        {
            try
            {
                // Tömmer listan
                _contact.Clear();

                // Uppdaterar filen med en tom lista
                _fileService.SaveListToFile(_contact);

                // Returnerar true som indikation att borttagningen lyckades
                return true;
            }
            catch (Exception ex)
            {
                // Logga eventuella fel om så behövs
                Console.WriteLine($"Error removing all users: {ex.Message}");
                return false;
            }
        }
    }
}
