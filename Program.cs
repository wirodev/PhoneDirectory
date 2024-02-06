using PhoneBook.Models;
using System;
using System.Text;

namespace PhoneBook
{
    public class Program
    {
        static void Main()
        {
            PhoneBookContext ctx = new();
            ctx.Database.EnsureCreated();

            // Example of initializing entries (r1, r2, ..., r10)
            var r1 = new PhoneBookEntry { PhoneNumber = "123456789", Name = "Alice Johnson", Address = "123 Main St" };
            var r2 = new PhoneBookEntry { PhoneNumber = "234567890", Name = "Bob Smith", Address = "456 Main St" };
            // ... Initialize r3 to r10 similarly

            ctx.Directory.Add(r1);
            ctx.Directory.Add(r2);
            // ... Add r3 to r10 similarly

            ctx.SaveChanges();

            // Update an entry
            UpdatePhoneBookEntry(ctx, "123456789", "Alice Johnson Updated", "123 Main St Updated");

            // Delete an entry
            DeletePhoneBookEntry(ctx, "987654321");

            // Report the full contents of the phone book in name order
            ReportAllEntries(ctx);

            // Report the name and address for a specified phone number
            ReportEntryByPhoneNumber(ctx, "234567890");

            // Report phone numbers and addresses matching a specified name
            ReportEntriesByName(ctx, "Michael Smith");
        }

        static void UpdatePhoneBookEntry(PhoneBookContext ctx, string phoneNumber, string newName, string newAddress)
        {
            var entry = ctx.Directory.Find(phoneNumber);
            if (entry != null)
            {
                entry.Name = newName;
                entry.Address = newAddress;
                ctx.SaveChanges();
                Console.WriteLine($"Entry updated: {entry.PhoneNumber}, {entry.Name}, {entry.Address}");
            }
            else
            {
                Console.WriteLine("Entry not found for update.");
            }
        }

        static void DeletePhoneBookEntry(PhoneBookContext ctx, string phoneNumber)
        {
            var entry = ctx.Directory.Find(phoneNumber);
            if (entry != null)
            {
                ctx.Directory.Remove(entry);
                ctx.SaveChanges();
                Console.WriteLine($"Entry deleted: {entry.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("Entry not found for deletion.");
            }
        }

        static void ReportAllEntries(PhoneBookContext ctx)
        {
            var entries = ctx.Directory.OrderBy(e => e.Name).ToList();
            foreach (var entry in entries)
            {
                Console.WriteLine($"Name: {entry.Name}, Phone Number: {entry.PhoneNumber}, Address: {entry.Address}");
            }
        }

        static void ReportEntryByPhoneNumber(PhoneBookContext ctx, string phoneNumber)
        {
            var entry = ctx.Directory.SingleOrDefault(e => e.PhoneNumber == phoneNumber);
            if (entry != null)
            {
                Console.WriteLine($"Name: {entry.Name}, Address: {entry.Address}");
            }
            else
            {
                Console.WriteLine("Entry not found.");
            }
        }

        static void ReportEntriesByName(PhoneBookContext ctx, string name)
        {
            var entries = ctx.Directory.Where(e => e.Name == name).ToList();
            foreach (var entry in entries)
            {
                Console.WriteLine($"Phone Number: {entry.PhoneNumber}, Address: {entry.Address}");
            }
        }
    }
}
