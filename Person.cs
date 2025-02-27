using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class Person
    {
        public String Id { get; private set; }
        private int _Password;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public List<Account> Accounts { get; private set; } = new List<Account>();
        public Person(String id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Add();
        }
        public void Add()
        {
            Accounts.Add(new Account(Accounts.Count()));
        }
        public void ChangePassWord(int PassWord, int NewPassword)
        {
            if (PassWord != _Password)
            {
                throw new InvalidOperationException("Wrong PassWord");
            }
            _Password = NewPassword;
        }
    }
}
