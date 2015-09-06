using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_WPF
{
    //SELECT  tSId, tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId 
    class Student
    {
        private int _sid;
        private string _name;
        private string _gender;
        private string _address;
        private string _phone;
        private int? _age;
        private DateTime? _birthday;
        private string _cardId;
        private int _classId;

        public int Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public int? Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public DateTime? Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        public string CardId
        {
            get { return _cardId; }
            set { _cardId = value; }
        }
        public int ClassId
        {
            get { return _classId; }
            set { _classId = value; }
        }
    }
}
