using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutuphane
{
    public class Books
    {
        //fields
        private string BookName;
        private string Name;
        private string Surname;
        private string PageNumber;
        private string Publisher;
        private string EntryDate;

        //properties
        public string bookName { get { return BookName; } set { BookName = value; } }
public string name { get { return Name; } set { Name = value; } }
public string surname { get { return Surname; } set { Surname = value; } }
public string pageNumber { get { return PageNumber; } set { PageNumber = value; } }
public string publisher { get { return Publisher; } set { Publisher = value; } }
public string entryDate { get { return EntryDate; } set { EntryDate = value; } }


        
        //constructor
        public Books()

        {
            entryDate = DateTime.Today.ToShortDateString();    //parametreless constructor 
           
        }

        public Books(string _bookName, string _name, string _surname, string _pageNumber, string _publisher)
        {
            bookName = _bookName;
            name = _name;
            surname = _surname;
            pageNumber = _pageNumber;                                                            //parametreli constructor
            publisher = _publisher;
            entryDate = DateTime.Today.ToShortDateString(); 
        }

       


    }
}
