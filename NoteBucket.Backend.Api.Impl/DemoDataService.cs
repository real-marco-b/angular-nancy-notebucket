using NoteBucket.Backend.Api.Contracts;
using NoteBucket.Backend.Domain;
using NoteBucket.Backend.Persistence.Contracts;
using System;

namespace NoteBucket.Backend.Api.Impl
{
    public class DemoDataService : IDemoDataService
    {
        private IRepositoryCatalog _catalog;

        public DemoDataService(IRepositoryCatalog catalog)
        {
            _catalog = catalog;
        }
        
        public void CreateDemoData()
        {
            CreateGuybrush();
            CreateR2D2();
        }

        private void CreateGuybrush()
        {
            var user = new User("threepwood@note-bucket.io", "Guybrush", "Threepwood");
            user.SetPassword("mightypirate");
            _catalog.Users.Add(user);

            var folder1 = new Folder(user, "About the Scumm Bar");
            var folder2 = new Folder(user, "Elaine");
            var folder3 = new Folder(user, "Papapishu");
            _catalog.Folders.Add(folder1);
            _catalog.Folders.Add(folder2);
            _catalog.Folders.Add(folder3);

            var note1 = new Note(folder1, "About LOOM", "Go out and buy LOOM today");
            var note2 = new Note(folder1, "Very Important Pirate Leaders", "Better ask them about the three trials");
            var note3 = new Note(folder2, "She is my ...", "Plunder Bunny");
            var note4 = new Note(folder3, "Brimstone Beach Club", "The card says: Brimstone Beach Club. Member Since 1632.");

            _catalog.Notes.Add(note1);
            _catalog.Notes.Add(note2);
            _catalog.Notes.Add(note3);
            _catalog.Notes.Add(note4);
        }

        private void CreateR2D2()
        {
            var user = new User("R2D2@note-bucket.io");
            user.SetPassword("beepbeep");
            _catalog.Users.Add(user);

            var folder1 = new Folder(user, "Beep Chirp Beep");
            var folder2 = new Folder(user, "Chirp Chirp Beep");
            _catalog.Folders.Add(folder1);
            _catalog.Folders.Add(folder2);

            var note1 = new Note(folder1, "Important Data Disc", "01010100 01100001 01110100 01101111 01101111 01101001 01101110 01100101");
            var note2 = new Note(folder1, "Well...", "01000011 00110011 01010000 01001111 00100000 01110011 01110101 01100011 01101011 01110011");
            _catalog.Notes.Add(note1);
            _catalog.Notes.Add(note2);
        }
    }
}
