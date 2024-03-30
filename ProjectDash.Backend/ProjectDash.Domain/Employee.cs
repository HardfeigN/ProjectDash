using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectDash.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }        //Имя
        public string Surname { get; set; }     //Фамилия
        public string Patronymic { get; set; }  //Отчество
        public string Email { get; set; }  
    }
}
